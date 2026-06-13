using Forge.Abstractions.Responses;
using Forge.Enums;
using Forge.Results;
using System.Text.Json;

namespace Forge.Responses
{
    public class ForgeResponseValidator : IForgeResponseValidator
    {
        public ForgeResponse Validate<T>(string response)
        {
            ForgeResponse<T>? deserializedResponse = JsonSerializer.Deserialize<ForgeResponse<T>>(response);
            if (deserializedResponse == null)
            {
                return ForgeResponseBuilder.Response(ForgeResponseCode.ResponseUnparsable);
            }

            return ForgeResponseBuilder.Response(deserializedResponse.ResponseCode);
        }
    }
}
