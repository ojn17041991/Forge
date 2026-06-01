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
    }
}
