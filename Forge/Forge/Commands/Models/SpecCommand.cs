using Forge.Commands.Enums;
using Forge.Commands.Interfaces;

namespace Forge.Commands.Models
{
    public record SpecCommand : ICommand
    {
        public CommandVerb Verb => CommandVerb.Spec;

        public required string FileName;
    }
}
