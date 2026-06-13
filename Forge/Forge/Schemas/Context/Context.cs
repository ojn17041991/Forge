using Forge.Schemas.Context.Target;

namespace Forge.Schemas.ForgeContext
{
    public class Context
    {
        public required string SchemaVersion { get; init; }

        public required Target Target { get; init; }
    }
}
