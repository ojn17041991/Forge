using Forge.Results;

namespace Forge.Abstractions.Responses
{
    public interface IForgeResponseParser
    {
        ForgeResponse<T> Parse<T>(string response);
    }
}
