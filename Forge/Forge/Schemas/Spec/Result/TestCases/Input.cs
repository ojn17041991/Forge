namespace Forge.Schemas.Spec.Result.TestCases
{
    public sealed record Input
    {
        public required string Name { get; init; }

        public required object Value { get; init; }
    }
}
