namespace Forge.Schemas.Context.Target
{
    public sealed record Parameter
    {
        public required string Name { get; init; }

        public required string Type { get; init; }
    }
}
