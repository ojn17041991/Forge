namespace Forge.Schemas.Context.Target
{
    public class Target
    {
        public required string Namespace { get; init; }

        public required Class Class { get; init; }

        public required Method Method { get; init; }
    }
}
