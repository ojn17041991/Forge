using Forge.Schemas.Specification.Result.TestCases;

namespace Forge.Schemas.Specification.Result
{
    public sealed record SpecificationResultSchema
    {
        public required string SchemaVersion { get; init; }

        public required IList<TestCase> TestCases { get; init; }

        public required Metadata.Metadata Metadata { get; init; }
    }
}
