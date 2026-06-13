namespace Forge.Schemas.Specification.Result.Metadata
{
    public sealed record Metadata
    {
        public required int Confidence { get; init; }

        public required string Reason { get; init; }
    }
}
