/// <summary>
/// Creates a new cat using the provided details.
/// </summary>
/// <param name="dto">The details of the cat to create.</param>
/// <returns>
/// A new <see cref="CatDto"/> if validation passes. Otherwise null.
/// </returns>
/// <behaviours>
/// Validation fails if:
/// - <see cref="CatDto.FurColorHashCode"/> is not a valid color hash code.
/// - <see cref="CatDto.Breed"/> is <see cref="CatBreed.Siamese"/>.
/// Otherwise:
/// - The cat is created with the provided details and a unique identifier.
/// - The cat is stored in memory.
/// </behaviours>
public CatDto? CreateCat(CreateCatDto dto)