/// <summary>
/// A container for some generic data and an internal response code.
/// Base record sets internal Success flag to true when a successful <see cref="ForgeResponseCode"/> is given. Otherwise false.
/// </summary>
public sealed record ForgeResponse<T>