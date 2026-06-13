namespace Forge.Schemas.Context.Target
{
    public sealed record Method
    {
        public required string Name { get; init; }

        public required string Accessibility { get; init; }

        public required bool IsStatic { get; init; }

        public required Type ReturnType { get; init; }

        public required IList<Parameter> Parameters { get; init; }
    }
}
