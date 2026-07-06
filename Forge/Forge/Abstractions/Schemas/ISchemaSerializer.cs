using Forge.Results;

namespace Forge.Abstractions.Schemas
{
    public interface ISchemaSerializer
    {
        ForgeResponse<string> Serialize<T>();
    }
}
