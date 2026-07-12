using Forge.Enums;
using Forge.Verbs.Abstractions.Commands;

namespace Forge.Commands.Spec
{
    public sealed record SpecCommand : ICommand
    {
        public CommandVerb Verb => CommandVerb.Spec;

        public required string FilePath;

        public required string FunctionName;
    }
}
