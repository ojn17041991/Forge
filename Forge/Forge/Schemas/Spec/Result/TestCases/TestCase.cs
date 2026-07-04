using Forge.Enums;

namespace Forge.Schemas.Spec.Result.TestCases
{
    public class TestCase
    {
        public required string Name { get; init; }

        public required string Description { get; init; }

        public required TestCategory Category { get; init; }

        public required IList<Input> Inputs { get; init; }

        public required string ExpectedResult { get; init; }
    }
}
