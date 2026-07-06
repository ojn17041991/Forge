namespace Forge.Schemas.Spec.Context.Target
{
    public sealed record Constructor
    {
        public required Parameter[] Parameters { get; init; }
    }
}
