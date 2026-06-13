namespace Forge.Schemas.Context.Target
{
    public record Constructor
    {
        public required IDictionary<string, string> Parameters { get; init; }
    }
}
