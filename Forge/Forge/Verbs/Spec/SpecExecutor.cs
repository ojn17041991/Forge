using Forge.Abstractions.Verbs.Executors;
using Forge.Enums;

namespace Forge.Commands.Spec
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
