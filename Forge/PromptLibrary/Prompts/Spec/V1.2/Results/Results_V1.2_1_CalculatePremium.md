### Grade:

Pass.
Covered major cases.

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
Name: Valid inputs produce calculable premium
Description: Verifies that the function returns a premium when all inputs are non-zero.
Inputs: 10, 5.0m, 10
Expected Result: A non-null decimal value is returned.

TEST CASE 2
Category: Essential
Name: Zero duration results in non-calculable premium
Description: Verifies that a zero duration makes the premium not calculable.
Inputs: 0, 5.0m, 10
Expected Result: null is returned.

TEST CASE 3
Category: Essential
Name: Zero cost per day results in non-calculable premium
Description: Verifies that a zero cost per day makes the premium not calculable.
Inputs: 10, 0m, 10
Expected Result: null is returned.

TEST CASE 4
Category: Valuable
Name: Zero adjustment still produces calculable premium
Description: Verifies that a valid calculation still occurs when adjustment percentage is zero.
Inputs: 10, 5.0m, 0
Expected Result: A non-null decimal value is returned.

TEST CASE 5
Category: Valuable
Name: Adjustment percentage affects resulting premium value
Description: Verifies that changing the adjustment percentage changes the resulting premium value for otherwise identical valid inputs.
Inputs: 10, 5.0m, 20
Expected Result: A non-null decimal value is returned and the result differs from an equivalent calculation where the adjustment percentage is 0.

Confidence: 86%
Reason: Core nullability rules (zero duration or cost) are directly specified and well covered. The main uncertainty is the exact mathematical effect of adjustmentPercentage, so only relationship-based behavioural testing (rather than formula-specific assertions) is used, which slightly reduces completeness confidence.