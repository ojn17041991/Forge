using Forge.Commands.Enums;
using Forge.Commands.Interfaces;
using Forge.Commands.Models;

namespace Forge.Commands.Dependencies
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
