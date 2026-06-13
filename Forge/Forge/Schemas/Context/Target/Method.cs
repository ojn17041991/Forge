namespace Forge.Schemas.Context.Target
{
    public class Method
    {
        public required string Name { get; init; }

        public required string Accessibility { get; init; }

        public required bool IsStatic { get; init; }

        public required string ReturnType { get; init; }

        public required IDictionary<string, string> Parameters { get; init; }
    }
}
