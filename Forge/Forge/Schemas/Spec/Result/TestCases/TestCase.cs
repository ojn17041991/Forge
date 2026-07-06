using Forge.Enums;

namespace Forge.Schemas.Spec.Result.TestCases
{
    public sealed record TestCase
    {
        public required string Name { get; init; }

        public required string Description { get; init; }

        public required TestCategory Category { get; init; }

        public required Input[] Inputs { get; init; }

        public required string ExpectedResult { get; init; }
    }
}
