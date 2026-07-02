using Forge.Abstractions.Responses;
using Forge.Enums;
using Forge.Results;
using System.Text.Json;

namespace Forge.Responses
{
    public class ForgeResponseParser : IForgeResponseParser
    {
        public ForgeResponse<T> Parse<T>(string response)
        {
            try
            {
                ForgeResponse<T>? deserializedResponse = JsonSerializer.Deserialize<ForgeResponse<T>>(response);

                if (deserializedResponse == null)
                {
                    return ForgeResponseBuilder.Response<T>(ForgeResponseCode.ResponseUnparsable);
                }

                return deserializedResponse;
            }
            catch (JsonException)
            {
                return ForgeResponseBuilder.Response<T>(ForgeResponseCode.ResponseUnparsable);
            }
        }
    }
}
