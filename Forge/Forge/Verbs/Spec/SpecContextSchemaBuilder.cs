using Forge.Commands.Spec;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;
using Forge.Schemas.Spec.Context;
using Forge.Verbs.Abstractions.Schema;
using FunctionLibrary.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Forge.Verbs.Spec
{
    public class SpecContextSchemaBuilder : ISchemaBuilder<SpecCommand, SpecContextSchema>
    {
        public CommandVerb Verb => CommandVerb.Spec;

        public ForgeResponse<SpecContextSchema> Build(SpecCommand command)
        {
            if (File.Exists(command.FilePath) == false)
            {
                return ForgeResponseBuilder.Response<SpecContextSchema>(ForgeResponseCode.FileMissing);
            }

            // OJN: This is an assumption. It should be based on an explicit argument.
            string className = Path.GetFileNameWithoutExtension(command.FilePath);
            string fileContent = File.ReadAllText(command.FilePath);

            SyntaxTree tree = CSharpSyntaxTree.ParseText(fileContent);
            SyntaxNode root = tree.GetRoot();

            ClassDeclarationSyntax? classDeclaration = root
                .DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .FirstOrDefault(x => x.Identifier.ValueText == className);

            if (classDeclaration == null)
            {
                return ForgeResponseBuilder.Response<SpecContextSchema>(ForgeResponseCode.ClassDefinitionMissing);
            }

            // Collect constructors declared on the class. The schema expects an array of constructors.
            var constructorDeclarations = classDeclaration
                .Members
                .OfType<ConstructorDeclarationSyntax>()
                .ToArray();

            // OJN: This doesn't account for overloaded methods. It should probably be based on an explicit argument.
            MethodDeclarationSyntax? functionDeclaration = classDeclaration
                .Members
                .OfType<MethodDeclarationSyntax>()
                .FirstOrDefault(m => m.Identifier.ValueText == command.FunctionName);

            if (functionDeclaration == null)
            {
                return ForgeResponseBuilder.Response<SpecContextSchema>(ForgeResponseCode.FunctionDefinitionMissing);
            }

            DocumentationCommentTriviaSyntax? documentationDeclaration = functionDeclaration
                .GetLeadingTrivia()
                .Select(x => x.GetStructure())
                .OfType<DocumentationCommentTriviaSyntax>()
                .FirstOrDefault();

            if (documentationDeclaration == null)
            {
                return ForgeResponseBuilder.Response<SpecContextSchema>(ForgeResponseCode.DocumentationDefinitionMissing);
            }

            // Build namespace string.
            string targetNamespace = classDeclaration.Ancestors()
                .OfType<BaseNamespaceDeclarationSyntax>()
                .FirstOrDefault() is BaseNamespaceDeclarationSyntax nsDecl
                    ? nsDecl.Name.ToString()
                    : string.Empty;

            // Build class description.
            var classObj = new Forge.Schemas.Spec.Context.Target.Class
            {
                Name = classDeclaration.Identifier.ValueText,
                Accessibility = classDeclaration.Modifiers.ToString(),
                IsStatic = classDeclaration.Modifiers.Any(SyntaxKind.StaticKeyword),
                IsAbstract = classDeclaration.Modifiers.Any(SyntaxKind.AbstractKeyword),
                Constructors = constructorDeclarations
                    .Select(cd => new Forge.Schemas.Spec.Context.Target.Constructor
                    {
                        Parameters = cd.ParameterList.Parameters
                            .Select(p => new Forge.Schemas.Spec.Context.Target.Parameter
                            {
                                Name = p.Identifier.ValueText,
                                Type = new Forge.Schemas.Spec.Context.Target.Type
                                {
                                    Name = p.Type?.ToString() ?? string.Empty,
                                    IsNullable = p.Type is NullableTypeSyntax
                                }
                            })
                            .ToArray()
                    })
                    .ToArray()
            };

            // Build method description.
            var methodObj = new Forge.Schemas.Spec.Context.Target.Method
            {
                Name = functionDeclaration.Identifier.ValueText,
                Accessibility = functionDeclaration.Modifiers.ToString(),
                IsStatic = functionDeclaration.Modifiers.Any(SyntaxKind.StaticKeyword),
                ReturnType = new Forge.Schemas.Spec.Context.Target.Type
                {
                    Name = functionDeclaration.ReturnType.ToString(),
                    IsNullable = functionDeclaration.ReturnType is NullableTypeSyntax
                },
                Parameters = functionDeclaration.ParameterList.Parameters
                    .Select(p => new Forge.Schemas.Spec.Context.Target.Parameter
                    {
                        Name = p.Identifier.ValueText,
                        Type = new Forge.Schemas.Spec.Context.Target.Type
                        {
                            Name = p.Type?.ToString() ?? string.Empty,
                            IsNullable = p.Type is NullableTypeSyntax
                        }
                    })
                    .ToArray()
            };

            // Build target.
            var targetObj = new Forge.Schemas.Spec.Context.Target.Target
            {
                Namespace = targetNamespace,
                Class = classObj,
                Method = methodObj
            };

            // Build documentation.
            var documentationObj = new Forge.Schemas.Spec.Context.Documentation.Documentation
            {
                Summary = (documentationDeclaration?
                    .Content
                    .OfType<XmlElementSyntax>()
                    .FirstOrDefault(x => x.StartTag.Name.LocalName.ValueText == "summary")?
                    .Content
                    .ToFullString() ?? string.Empty)
                    .StripCommentMarkers(),
                Remarks = (documentationDeclaration?
                    .Content
                    .OfType<XmlElementSyntax>()
                    .FirstOrDefault(x => x.StartTag.Name.LocalName.ValueText == "remarks")?
                    .Content
                    .ToFullString() ?? string.Empty)
                    .StripCommentMarkers(),
                Parameters = (documentationDeclaration?
                    .Content
                    .OfType<XmlElementSyntax>()
                    .Where(x => x.StartTag.Name.LocalName.ValueText == "param")
                    .Select(x => new Forge.Schemas.Spec.Context.Documentation.Parameter
                    {
                        Name = x.StartTag.Attributes
                            .OfType<XmlNameAttributeSyntax>()
                            .FirstOrDefault()?.Identifier?.Identifier.ValueText ?? string.Empty,
                        Description = x.Content.ToFullString().Trim()
                    })
                    .ToArray()) ?? Array.Empty<Forge.Schemas.Spec.Context.Documentation.Parameter>(),
                TypeParameters = (documentationDeclaration?
                    .Content
                    .OfType<XmlElementSyntax>()
                    .Where(x => x.StartTag.Name.LocalName.ValueText == "typeparam")
                    .Select(x => new Forge.Schemas.Spec.Context.Documentation.TypeParameter
                    {
                        Name = x.StartTag.Attributes
                            .OfType<XmlNameAttributeSyntax>()
                            .FirstOrDefault()?.Identifier?.Identifier.ValueText ?? string.Empty,
                        Description = x.Content.ToFullString().Trim()
                    })
                    .ToArray()) ?? Array.Empty<Forge.Schemas.Spec.Context.Documentation.TypeParameter>(),
                Returns = documentationDeclaration?
                    .Content
                    .OfType<XmlElementSyntax>()
                    .FirstOrDefault(x => x.StartTag.Name.LocalName.ValueText == "returns")?
                    .Content
                    .ToFullString()
                    .Trim() ?? string.Empty,
                Exceptions = (documentationDeclaration?
                    .Content
                    .OfType<XmlElementSyntax>()
                    .Where(x => x.StartTag.Name.LocalName.ValueText == "exception")
                    .Select(x => new Forge.Schemas.Spec.Context.Documentation.Exception
                    {
                        CRef = x.StartTag.Attributes
                            .OfType<XmlCrefAttributeSyntax>()
                            .FirstOrDefault()?.Cref
                            .ToString() ?? string.Empty,
                        Description = x.Content.ToFullString().Trim()
                    })
                    .ToArray()) ?? Array.Empty<Forge.Schemas.Spec.Context.Documentation.Exception>(),
                Examples = (documentationDeclaration?
                    .Content
                    .OfType<XmlElementSyntax>()
                    .Where(x => x.StartTag.Name.LocalName.ValueText == "example")
                    .Select(x => x.Content.ToFullString().Trim())
                    .ToArray()) ?? Array.Empty<string>()
            };

            // Assemble final schema.
            var schema = new SpecContextSchema
            {
                Target = targetObj,
                Documentation = documentationObj
            };

            return ForgeResponseBuilder.Response(schema, ForgeResponseCode.Success);
        }
    }
}
