using Forge.Enums;

namespace Forge.Results
{
    /// <summary>
    /// A container for an internal response code.
    /// Base record sets internal Success flag to true when a successful <see cref="ForgeResponseCode"/> is given. Otherwise false.
    /// </summary>
    public sealed record ForgeResponse : BaseForgeResponse
    {
    }

    /// <summary>
    /// A container for some generic data and an internal response code.
    /// Base record sets internal Success flag to true when a successful <see cref="ForgeResponseCode"/> is given. Otherwise false.
    /// </summary>
    public sealed record ForgeResponse<T> : BaseForgeResponse
    {
        public required T? Data { get; init; }
    }

    /// <summary>
    /// A base container for an internal response code.
    /// Sets internal Success flag to true when a successful <see cref="ForgeResponseCode"/> is given. Otherwise false.
    /// </summary>
    public abstract record BaseForgeResponse
    {
        public required ForgeResponseCode ResponseCode { get; set; }

        public bool Success => ResponseCode == ForgeResponseCode.Success;
    }
}
