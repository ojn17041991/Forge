namespace Forge.Schemas.Specification.Context.Target
{
    public sealed record Constructor
    {
        public required IList<Parameter> Parameters { get; init; }
    }
}
