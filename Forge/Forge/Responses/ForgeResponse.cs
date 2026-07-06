using Forge.Attributes;
using Forge.Enums;

namespace Forge.Results
{
    // OJN: If these returned defaults instead of null, then you wouldn't have to do null forgives throughout the code.

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
    /// Sets <c>IsSuccess</c> flag to true when a successful <see cref="ForgeResponseCode"/> is given. Otherwise false.
    /// Sets <c>IsUsable</c> flag to true when a successful or incomplete <see cref="ForgeResponseCode"/> is given. Otherwise false.
    /// </summary>
    public abstract record BaseForgeResponse
    {
        public required ForgeResponseCode ResponseCode { get; set; }

        [SchemaIgnore]
        public bool IsSuccess => ResponseCode == ForgeResponseCode.Success;

        [SchemaIgnore]
        public bool IsUsable => ResponseCode == ForgeResponseCode.Success || ResponseCode == ForgeResponseCode.Incomplete;
    }
}
