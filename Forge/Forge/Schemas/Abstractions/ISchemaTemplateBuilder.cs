using Forge.Results;

namespace Forge.Schemas.Abstractions
{
    public interface ISchemaTemplateBuilder
    {
        /// <summary>
        /// Builds a serialized JSON template containing all properties and types of a generic schema.
        /// </summary>
        /// <typeparam name="T">The generic schema type.</typeparam>
        /// <returns>A serialized JSON schema template.</returns>
        ForgeResponse<string> Build<T>();
    }
}
