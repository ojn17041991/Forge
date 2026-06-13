using Forge.Schemas.Context.Documentation;
using Forge.Schemas.Context.Target;

namespace Forge.Schemas.ForgeContext
{
    public sealed record Context
    {
        public required string SchemaVersion { get; init; }

        public required Target Target { get; init; }

        public required Documentation Documentation { get; init; }
    }
}
