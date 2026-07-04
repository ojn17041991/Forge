using Forge.Schemas.Spec.Result.TestCases;

namespace Forge.Schemas.Spec.Result
{
    public sealed record SpecResultSchema
    {
        public required string SchemaVersion { get; init; }

        public required IList<TestCase> TestCases { get; init; }

        public required Metadata.Metadata Metadata { get; init; }
    }
}
