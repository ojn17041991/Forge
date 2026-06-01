namespace FunctionLibrary
{
    public interface IFunctionLibrary
    {
        /// <summary>
        /// Returns the sum of two numbers.
        /// </summary>
        /// <param name="x">First number.</param>
        /// <param name="y">Second number.</param>
        /// <returns>The sum of x and y.</returns>
        public double Add(double x, double y);

        /// <summary>
        /// Returns a gross premium amount.
        /// </summary>
        /// <param name="durationOfCoverageDays">How many days will the cover last?</param>
        /// <param name="costPerDay">What is the cost of a single day of cover?</param>
        /// <param name="adjustmentPercentage">How much to adjust the premium by following calculation.</param>
        /// <returns>A gross premium amount if calculable. Otherwise, null.</returns>
        public decimal? CalculatePremium(int durationOfCoverageDays, decimal costPerDay, decimal adjustmentPercentage);

        /// <summary>
        /// Applies deductions.
        /// </summary>
        /// <param name="grossPremium">Gross premium.</param>
        /// <param name="deductions">Dictionary of deduction.</param>
        /// <returns>The premium with deductions.</returns>
        public decimal? ApplyDeductions(decimal grossPremium, IDictionary<string, decimal> deductions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grossPremium"></param>
        /// <returns></returns>
        public int GetNumberOfIssuesWithPremium(decimal grossPremium);

        public void Engage();

        /// <summary>
        /// Retrieves a <see cref="CatDto"/> with the specified <c>id</c>.
        /// </summary>
        /// <param name="id">The unique identifier of the cat to retrieve.</param>
        /// <returns>
        /// The matching <see cref="CatDto"/> if a cat with the specified <c>id</c> exists; otherwise, <c>null</c>.
        /// </returns>
        public CatDto? GetCat(Guid id);

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
        public CatDto? CreateCat(CreateCatDto dto);
    }
}
