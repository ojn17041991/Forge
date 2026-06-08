/// <summary>
/// Builds a Forge response object from a response code.
/// Can only be used with response codes that indicate failure.
/// </summary>
/// <param name="responseCode">The response code.</param>
/// <returns>A Forge response with the specified response code and default value of generic type.</returns>
/// <exception cref="InvalidOperationException">Thrown when a success response is requested.</exception>
public static ForgeResponse<T> Response<T>(ForgeResponseCode responseCode)