using Forge.Enums;
using Forge.Results;

namespace Forge.Responses
{
    public static class ForgeResponseBuilder
    {
        public static ForgeResponse Response(ForgeResponseCode responseCode) => new ForgeResponse
        {
            ResponseCode = responseCode
        };

        public static ForgeResponse<T> Response<T>(T data, ForgeResponseCode responseCode)
        {
            if (data == null && responseCode == ForgeResponseCode.Success)
            {
                throw new InvalidOperationException("Success responses must contain data.");
            }

            return new ForgeResponse<T>
            {
                Data = data,
                ResponseCode = responseCode
            };
        }

        public static ForgeResponse<T> Response<T>(ForgeResponseCode responseCode)
        {
            if (responseCode == ForgeResponseCode.Success)
            {
                throw new InvalidOperationException("Success responses must contain data.");
            }

            return new ForgeResponse<T>
            {
                Data = default,
                ResponseCode = responseCode
            };
        }
    }
}
