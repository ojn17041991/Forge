using Forge.Enums;

namespace Forge.Results
{
    public sealed record ForgeResponse : BaseForgeResponse
    {

    }

    public sealed record ForgeResponse<T> : BaseForgeResponse
    {
        public required T? Data { get; init; }
    }

    public abstract record BaseForgeResponse
    {
        public required ForgeResponseCode ResponseCode { get; set; }

        public bool Success => ResponseCode == ForgeResponseCode.Success;
    }
}
