namespace Forge.Schemas.Spec.Context.Target
{
    public sealed record Parameter
    {
        public required string Name { get; init; }

        public required Type Type { get; init; }
    }
}
