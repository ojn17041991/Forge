using FunctionLibrary.Enums;

namespace FunctionLibrary.Models
{
    public class CatDto
    {
        public required Guid Id;

        public required CatBreed Breed;

        public required string FurColorHashCode;

        public required int Age;
    }
}
