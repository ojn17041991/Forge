namespace Forge.Schemas.Spec.Context.Target
{
    public sealed record Target
    {
        public required string Namespace { get; init; }

        public required Class Class { get; init; }

        public required Method Method { get; init; }
    }
}
