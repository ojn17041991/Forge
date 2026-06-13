namespace Forge.Schemas.Specification.Context.Target
{
    public sealed record Type
    {
        public required string Name { get; init; }

        public required bool IsNullable { get; init; }
    }
}
