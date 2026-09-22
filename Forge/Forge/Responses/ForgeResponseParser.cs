using Forge.Enums;
using Forge.Responses.Abstractions;
using Forge.Results;
using System.Text.Json;
using Forge.Utilities;

namespace Forge.Responses
{
    public class ForgeResponseParser : IForgeResponseParser
    {
        public ForgeResponse<T> Parse<T>(string response)
        {
            try
            {
                ForgeResponse<T>? deserializedResponse = JsonSerializer.Deserialize<ForgeResponse<T>>(response, JsonSerializerOptionsProvider.Options);

                if (deserializedResponse == null)
                {
                    return ForgeResponseBuilder.Response<T>(ForgeResponseCode.ResponseCouldNotBeParsed);
                }

                return deserializedResponse;
            }
            catch (JsonException)
            {
                return ForgeResponseBuilder.Response<T>(ForgeResponseCode.ResponseCouldNotBeParsed);
            }
        }
    }
}
