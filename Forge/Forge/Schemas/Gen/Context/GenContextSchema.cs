using Forge.Schemas.Spec.Context;
using Forge.Schemas.Spec.Result;

namespace Forge.Schemas.Generation.Context
{
    public class GenContextSchema
    {
        public required string SchemaVersion { get; init; }

        public required SpecContextSchema Context { get; init; }

        public required SpecResultSchema Specification { get; init; }
    }
}
