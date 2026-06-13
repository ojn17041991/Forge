### Grade:

Fail.
Inferred business logic.

### Given input:

/// <summary>
/// Returns a gross premium amount.
/// </summary>
/// <param name="durationOfCoverageDays">How many days will the cover last?</param>
/// <param name="costPerDay">What is the cost of a single day of cover?</param>
/// <param name="adjustmentPercentage">How much to adjust the premium by following calculation.</param>
/// <returns>A gross premium amount if calculable. Otherwise, null.</returns>
public decimal? CalculatePremium(int durationOfCoverageDays, decimal costPerDay, decimal adjustmentPercentage);

### Produced output:

TEST CASE 1
Name: Standard calculable premium with positive inputs and adjustment
Description: Verifies that a gross premium is calculated when all inputs are valid and positive, including a non-zero adjustment percentage.
Inputs:
 durationOfCoverageDays: 10
 costPerDay: 50.00
 adjustmentPercentage: 10
Expected Result: Calculated gross premium amount

TEST CASE 2
Name: Calculable premium with zero adjustment
Description: Verifies that a gross premium is calculated when no adjustment is applied, ensuring base calculation still occurs.
Inputs:
 durationOfCoverageDays: 10
 costPerDay: 50.00
 adjustmentPercentage: 0
Expected Result: Calculated gross premium amount

TEST CASE 3
Name: Non-calculable premium due to zero duration
Description: Verifies that the function returns null when coverage duration is zero, making premium calculation not possible.
Inputs:
 durationOfCoverageDays: 0
 costPerDay: 50.00
 adjustmentPercentage: 10
Expected Result: null

TEST CASE 4
Name: Zero cost per day results in boundary premium calculation
Description: Verifies behaviour when cost per day is zero, representing a boundary case for premium calculation.
Inputs:
 durationOfCoverageDays: 10
 costPerDay: 0.00
 adjustmentPercentage: 10
Expected Result: Calculated gross premium amount

TEST CASE 5
Name: Non-core case - negative duration of coverage
Description: Verifies behaviour when duration is negative, representing invalid or unsupported input.
Inputs:
 durationOfCoverageDays: -5
 costPerDay: 50.00
 adjustmentPercentage: 10
Expected Result: null or non-calculable result

TEST CASE 6
Name: Non-core case - negative cost and adjustment values
Description: Verifies behaviour when cost per day and adjustment percentage are negative, testing handling of invalid financial inputs.
Inputs:
 durationOfCoverageDays: 10
 costPerDay: -50.00
 adjustmentPercentage: -10
Expected Result: null or non-calculable result