using Forge.Abstractions.Verbs.Commands;
using Forge.Enums;

namespace Forge.Commands.Spec
{
    public sealed record SpecCommand : ICommand
    {
        public CommandVerb Verb => CommandVerb.Spec;

        public required string FilePath;
    }
}
