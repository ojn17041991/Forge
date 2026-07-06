namespace Forge.Schemas.Spec.Context.Documentation
{
    public sealed record Documentation
    {
        public required string Summary { get; init; }

        public required string Remarks { get; init; }

        public required Parameter[] Parameters { get; init; }

        public required TypeParameter[] TypeParameters { get; init; }

        public required string Returns { get; init; }

        public required Exception[] Exceptions { get; init; }

        public required string[] Examples { get; init; }
    }
}
