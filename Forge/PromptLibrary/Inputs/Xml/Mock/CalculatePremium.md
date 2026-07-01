/// <summary>
/// Calculates a gross premium amount.
/// </summary>
/// <param name="durationOfCoverageDays">How many days will the cover last?</param>
/// <param name="costPerDay">What is the cost of a single day of cover?</param>
/// <param name="adjustmentPercentage">How much to adjust the premium by following calculation.</param>
/// <returns>A gross premium amount, if calculable. Otherwise, null.</returns>
/// <behaviours>
/// Premium is not calculable if:
/// - durationOfCoverageDays is 0.
/// - costPerDay is 0.
/// adjustmentPercentage influences the gross premium value when calculation occurs.
/// </behaviours>
public decimal? CalculatePremium(int durationOfCoverageDays, decimal costPerDay, decimal adjustmentPercentage)