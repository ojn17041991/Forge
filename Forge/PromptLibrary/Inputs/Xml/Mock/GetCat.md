/// <summary>
/// Retrieves a cat with the specified <c>id</c>.
/// </summary>
/// <param name="id">The unique identifier of the cat to retrieve.</param>
/// <returns>
/// The matching <see cref="CatDto"/> if a cat with the specified ID exists; otherwise, <c>null</c>.
/// </returns>
public CatDto? GetCat(Guid id)