### Grade:

Pass.
Covered major cases.
Missing some minor cases. For example, test of negative duration, but not negative cost. No test for negative adjustment.

### Given input:

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

### Produced output:

TEST CASE 1
Category: Essential
Name: Calculates gross premium for valid inputs
Description: Verifies that a gross premium is calculated when all inputs are valid and non-zero, and that adjustmentPercentage is applied during calculation.
Inputs:
durationOfCoverageDays: 10
costPerDay: 5.00
adjustmentPercentage: 10
Expected Result: Returns a non-null decimal representing the calculated gross premium, including adjustment based on adjustmentPercentage.

TEST CASE 2
Category: Essential
Name: Returns null when duration is zero
Description: Verifies that no premium is calculated when durationOfCoverageDays is 0.
Inputs:
durationOfCoverageDays: 0
costPerDay: 5.00
adjustmentPercentage: 10
Expected Result: null

TEST CASE 3
Category: Essential
Name: Returns null when cost per day is zero
Description: Verifies that no premium is calculated when costPerDay is 0.
Inputs:
durationOfCoverageDays: 10
costPerDay: 0
adjustmentPercentage: 10
Expected Result: null

TEST CASE 4
Category: Valuable
Name: Handles negative input values in calculation
Description: Verifies behaviour when durationOfCoverageDays or costPerDay are negative values. No validation rule is specified, so calculation proceeds using standard numeric handling.
Inputs:
durationOfCoverageDays: -5
costPerDay: 10.00
adjustmentPercentage: 10
Expected Result: Returns a non-null decimal result produced by the calculation using the provided inputs.

TEST CASE 5
Category: Optional
Name: Returns null when both duration and cost are zero
Description: Verifies combined boundary condition where both durationOfCoverageDays and costPerDay are 0.
Inputs:
durationOfCoverageDays: 0
costPerDay: 0
adjustmentPercentage: 10
Expected Result: null