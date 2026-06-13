namespace Forge.Schemas.Specification.Context.Documentation
{
    public sealed record Documentation
    {
        public required string Summary { get; init; }

        public required string Remarks { get; init; }

        public required IList<Parameter> Parameters { get; init; }

        public required IList<TypeParameter> TypeParameters { get; init; }

        public required string Returns { get; init; }

        public required IList<Exception> Exceptions { get; init; }

        public required IList<string> Examples { get; init; }
    }
}
