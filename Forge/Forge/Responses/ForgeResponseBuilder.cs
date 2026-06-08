using Forge.Enums;
using Forge.Results;

namespace Forge.Responses
{
    public static class ForgeResponseBuilder
    {
        /// <summary>
        /// Builds a Forge response object from a response code.
        /// </summary>
        /// <param name="responseCode">The response code.</param>
        /// <returns>A Forge response with the specified response code.</returns>
        public static ForgeResponse Response(ForgeResponseCode responseCode) => new ForgeResponse
        {
            ResponseCode = responseCode
        };

        /// <summary>
        /// Builds a Forge response object from a response code.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="responseCode">The response code.</param>
        /// <returns>A Forge response with the specified response code and data.</returns>
        /// <exception cref="InvalidOperationException">Thrown when a success response is requested without valid data.</exception>
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

        /// <summary>
        /// Builds a Forge response object from a response code.
        /// Can only be used with response codes that indicate failure.
        /// </summary>
        /// <param name="responseCode">The response code.</param>
        /// <returns>A Forge response with the specified response code and default value of generic type.</returns>
        /// <exception cref="InvalidOperationException">Thrown when a success response is requested.</exception>
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
