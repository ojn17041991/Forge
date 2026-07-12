using Forge.Results;

namespace Forge.Responses.Abstractions
{
    public interface IForgeResponseParser
    {
        ForgeResponse<T> Parse<T>(string response);
    }
}
