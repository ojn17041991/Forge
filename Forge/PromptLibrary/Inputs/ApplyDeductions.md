/// <summary>
/// Applies deductions.
/// </summary>
/// <param name="grossPremium">Gross premium.</param>
/// <param name="deductions">Dictionary of deduction.</param>
/// <returns>The premium with deductions.</returns>
public decimal? ApplyDeductions(decimal grossPremium, IDictionary<string, decimal> deductions)