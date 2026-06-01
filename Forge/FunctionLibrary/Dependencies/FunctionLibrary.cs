namespace FunctionLibrary.Dependencies
{
    public class FunctionLibrary : IFunctionLibrary
    {
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
    }
}
