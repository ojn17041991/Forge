using Forge.Abstractions.Schemas;
using Forge.Attributes;
using Forge.Enums;
using Forge.Extensions;
using Forge.Responses;
using Forge.Results;
using System.Text.Json;

namespace Forge.Schemas
{
    public class SchemaSerializer : ISchemaSerializer
    {
        public ForgeResponse<string> Serialize<T>()
        {
            var type = typeof(T);

            var schema = GenerateForType(type);

            string json = JsonSerializer.Serialize(
                schema,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            return ForgeResponseBuilder.Response(json, ForgeResponseCode.Success);
        }

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
