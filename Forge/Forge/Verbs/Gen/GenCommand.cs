using Forge.Enums;
using Forge.Verbs.Abstractions.Commands;

namespace Forge.Verbs.Gen
{
    public class GenCommand : ICommand
    {
        public CommandVerb Verb => CommandVerb.Gen;

        public required string SpecificationId;

        public required TestCategory Category;
    }
}
