using Forge.Schemas.Specification.Context;
using Forge.Schemas.Specification.Result;

namespace Forge.Schemas.Generation.Context
{
    public class GenerationContextSchema
    {
        public required string SchemaVersion { get; init; }

        public required SpecificationContextSchema Context { get; init; }

        public required SpecificationResultSchema Specification { get; init; }
    }
}
