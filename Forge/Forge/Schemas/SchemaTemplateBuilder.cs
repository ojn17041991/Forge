using Forge.Attributes;
using Forge.Enums;
using Forge.Extensions;
using Forge.Responses;
using Forge.Results;
using Forge.Schemas.Abstractions;
using System.Text.Json;

namespace Forge.Schemas
{
    public class SchemaTemplateBuilder : ISchemaTemplateBuilder
    {
        /// <summary>
        /// Builds a serialized JSON template containing all properties and types of a generic schema.
        /// </summary>
        /// <typeparam name="T">The generic schema type.</typeparam>
        /// <returns>A serialized JSON schema template.</returns>
        public ForgeResponse<string> Build<T>()
        {
            var type = typeof(T);

            var schema = GenerateForType(type);

            string json = JsonSerializer.Serialize(
                schema,
                Forge.Utilities.JsonSerializerOptionsProvider.Options
            );

            return ForgeResponseBuilder.Response(json, ForgeResponseCode.Success);
        }

        /// <summary>
        /// Recurses the generic schema to reach all nodes and return the property names and types of each.
        /// </summary>
        /// <param name="type">The type of the property currently being recursed as a <c>Type</c>.</param>
        /// <returns>The type of the property currently being recursed as an <c>object</c>.</returns>
        private object GenerateForType(Type type)
        {
            if (type.IsSimpleType() == true)
            {
                return type.Name.ToLowerInvariant();
            }

            if (type.IsEnum == true)
            {
                return "string";
            }

            if (type.IsArray == true)
            {
                return new object[]
                {
                    GenerateForType(type.GetElementType()!)
                };
            }

            if (type.IsClass == true)
            {
                var props = type.GetProperties();

                var dict = new Dictionary<string, object>();

                foreach (var prop in props)
                {
                    if (Attribute.IsDefined(prop, typeof(SchemaIgnoreAttribute)))
                    {
                        continue;
                    }

                    dict[prop.Name] = GenerateForType(prop.PropertyType);
                }

                return dict;
            }

            return "any";
        }
    }
}
