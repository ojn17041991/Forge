namespace Forge.Schemas.Gen.Result
{
    public sealed record GenResultSchema
    {
        public required string SchemaVersion { get; init; }

        public required string Code { get; init; }
    }
}
