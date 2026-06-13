namespace Forge.Schemas.Specification.Context
{
    public sealed record SpecificationContextSchema
    {
        public required string SchemaVersion { get; init; }

        public required Target.Target Target { get; init; }

        public required Documentation.Documentation Documentation { get; init; }
    }
}
