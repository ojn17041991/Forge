/// <summary>
/// Builds a Forge response object from a response code.
/// </summary>
/// <param name="data">The data.</param>
/// <param name="responseCode">The response code.</param>
/// <returns>A Forge response with the specified response code and data.</returns>
/// <exception cref="InvalidOperationException">Thrown when a success response is requested without valid data.</exception>
public static ForgeResponse<T> Response<T>(T data, ForgeResponseCode responseCode)