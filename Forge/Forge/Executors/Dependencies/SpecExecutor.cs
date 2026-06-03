using Forge.Commands.Enums;
using Forge.Commands.Models;
using Forge.Executors.Interfaces;

namespace Forge.Handlers.Dependencies
{
    public class SpecExecutor() : TypedExecutor<SpecCommand>
    {
        public override CommandVerb Verb => CommandVerb.Spec;

        public override bool Execute(SpecCommand command)
        {
            return true;
        }
    }
}
