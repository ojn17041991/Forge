using Forge.Abstractions.Verbs.Commands;
using Forge.Enums;

namespace Forge.Verbs.Gen
{
    public class GenCommand : ICommand
    {
        public CommandVerb Verb => CommandVerb.Gen;

        public required string SpecificationId;

        public required TestCategory Category;
    }
}
