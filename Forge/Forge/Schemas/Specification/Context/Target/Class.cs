namespace Forge.Schemas.Specification.Context.Target
{
    public sealed record Class
    {
        public required string Name { get; init; }

        public required string Accessibility { get; init; }

        public required bool IsStatic { get; init; }

        public required bool IsAbstract { get; init; }

        public required IList<Constructor> Constructors { get; init; }
    }
}
