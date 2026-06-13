namespace Forge.Schemas.Specification.Result.TestCases
{
    public sealed record Input
    {
        public required string Name { get; init; }

        public required object Value { get; init; }
    }
}
