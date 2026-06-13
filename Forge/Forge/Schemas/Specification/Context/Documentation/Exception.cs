namespace Forge.Schemas.Specification.Context.Documentation
{
    public sealed record Exception
    {
        public required string CRef { get; init; }

        public required string Description { get; init; }
    }
}
