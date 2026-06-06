using Forge.Abstractions.Verbs.Commands;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;

namespace Forge.Commands.Spec
{
    public class SpecCommandBuilder : ICommandBuilder
    {
        public CommandVerb Verb => CommandVerb.Spec;

        public ForgeResponse<ICommand> Build(string[] args)
        {
            if (args.Length < 3)
            {
                return ForgeResponseBuilder.Response<ICommand>(ForgeResponseCode.ArgumentsMissing);
            }

            ICommand command = new SpecCommand
            {
                FileName = args[2]
            };

            return ForgeResponseBuilder.Response(command, ForgeResponseCode.Success);
        }
    }
}
