namespace Forge.Schemas.Spec.Context
{
    public sealed record SpecContextSchema
    {
        public required string SchemaVersion { get; init; }

        public required Target.Target Target { get; init; }

        public required Documentation.Documentation Documentation { get; init; }
    }
}
