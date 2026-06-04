using Forge.Abstractions.Verbs.Commands;
using Forge.Enums;

namespace Forge.Commands.Spec
{
    public class SpecCommandBuilder : ICommandBuilder
    {
        public CommandVerb Verb => CommandVerb.Spec;

        public ICommand Build(string[] args)
        {
            return new SpecCommand
            {
                FileName = args[2]
            };
        }
    }
}
