using FunctionLibrary.Enums;
using FunctionLibrary.Extensions;
using FunctionLibrary.Models;

namespace FunctionLibrary.Dependencies
{
    public class FunctionLibrary : IFunctionLibrary
    {
        IList<CatDto> _cats = new List<CatDto>();

        /// <summary>
        /// Returns the sum of two numbers.
        /// </summary>
        /// <param name="x">First number.</param>
        /// <param name="y">Second number.</param>
        /// <returns>The sum of <c>x</c> and <c>y</c>.</returns>
        public double Add(double x, double y)
        {
            return x + y;
        }

        /// <summary>
        /// Calculates a gross premium amount.
        /// </summary>
        /// <param name="durationOfCoverageDays">How many days will the cover last?</param>
        /// <param name="costPerDay">What is the cost of a single day of cover?</param>
        /// <param name="adjustmentPercentage">How much to adjust the premium by following calculation.</param>
        /// <returns>A gross premium amount, if calculable. Otherwise, null.</returns>
        /// <behaviours>
        /// Premium is not calculable if:
        /// - <c>durationOfCoverageDays</c> is less than or equal to 0.
        /// - <c>costPerDay</c> is less than equal to  0.
        /// <c>adjustmentPercentage</c> influences the gross premium value when calculation occurs.
        /// </behaviours>
        public decimal? CalculatePremium(int durationOfCoverageDays, decimal costPerDay, decimal adjustmentPercentage)
        {
            if (durationOfCoverageDays <= 0)
            {
                return null;
            }

            if (costPerDay <= 0)
            {
                return null;
            }

            decimal totalCost = durationOfCoverageDays * costPerDay;
            decimal adjustedCost = totalCost + (totalCost + adjustmentPercentage * 0.01M);
            return adjustedCost;
        }

        /// <summary>
        /// Applies deductions.
        /// </summary>
        /// <param name="grossPremium">Gross premium.</param>
        /// <param name="deductions">Dictionary of deduction.</param>
        /// <returns>The premium with deductions.</returns>
        public decimal? ApplyDeductions(decimal grossPremium, IDictionary<string, decimal> deductions)
        {
            if (grossPremium <= 0)
            {
                return null;
            }

            foreach (var deduction in deductions.Values)
            {
                grossPremium *= -deduction;
            }

            return grossPremium;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grossPremium"></param>
        /// <returns></returns>
        public int GetNumberOfIssuesWithPremium(decimal grossPremium)
        {
            int number = 0;

            if (grossPremium <= 0)
            {
                ++number;
            }

            if (grossPremium >= 1000)
            {
                ++number;
            }

            if (grossPremium % 50 != 0)
            {
                ++number;
            }

            return number;
        }

        public void Engage()
        {
            return;
        }

        /// <summary>
        /// Retrieves a <see cref="CatDto"/> with the specified <c>id</c>.
        /// </summary>
        /// <param name="id">The unique identifier of the cat to retrieve.</param>
        /// <returns>
        /// The matching <see cref="CatDto"/> if a cat with the specified <c>id</c> exists; otherwise, <c>null</c>.
        /// </returns>
        public CatDto? GetCat(Guid id)
        {
            CatDto? cat = _cats.SingleOrDefault(x => x.Id == id);

            if (cat == null)
            {
                return null;
            }

            return cat;
        }

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
        /// - The newly created cat is stored in memory.
        /// </behaviours>
        public CatDto? CreateCat(CreateCatDto dto)
        {
            if (dto.FurColorHashCode.IsValidHashCode() == false)
            {
                return null;
            }

            if (dto.Breed == CatBreed.Siamese)
            {
                return null;
            }

            CatDto cat = new CatDto
            {
                Id = Guid.NewGuid(),
                Breed = dto.Breed,
                FurColorHashCode = dto.FurColorHashCode,
                Age = dto.Age
            };

            _cats.Add(cat);

            return cat;
        }
    }
}
