using Forge.Results;

namespace Forge.Abstractions.Responses
{
    public interface IForgeResponseValidator
    {
        ForgeResponse Validate<T>(string response);
    }
}
