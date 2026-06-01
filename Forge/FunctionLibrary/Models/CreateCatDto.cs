using FunctionLibrary.Enums;

namespace FunctionLibrary.Models
{
    public class CreateCatDto
    {
        public required CatBreed Breed;

        public required string FurColorHashCode;

        public required int Age;
    }
}
