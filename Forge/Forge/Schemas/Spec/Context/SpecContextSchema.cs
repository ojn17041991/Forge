namespace Forge.Schemas.Spec.Context
{
    public sealed record SpecContextSchema
    {
        public string SchemaVersion { get; init; } = "0.6"; // OJN: This needs to either be removed, or come from somewhere centralized. May be removed anyway.

        public required Target.Target Target { get; init; }

        public required Documentation.Documentation Documentation { get; init; }
    }
}
