using Forge.Abstractions.Verbs.Executors;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;

namespace Forge.Commands.Spec
{
    public class SpecExecutor() : TypedExecutor<SpecCommand>
    {
        public override CommandVerb Verb => CommandVerb.Spec;

        public override ForgeResponse Execute(SpecCommand command)
        {
            return ForgeResponseBuilder.Response(ForgeResponseCode.Success);
        }
    }
}
