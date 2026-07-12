using Forge.Enums;
using Forge.Responses;
using Forge.Results;
using Forge.Verbs.Abstractions.Commands;

namespace Forge.Commands.Spec
{
    // OJN: Surely this should take a generic on the class like SpecCommandBuilder : ICommandBuilder<SpecCommand> then return a solid type.

    public class SpecCommandBuilder : ICommandBuilder
    {
        public CommandVerb Verb => CommandVerb.Spec;

        public ForgeResponse<ICommand> Build(string[] args)
        {
            if (args.Length < 5)
            {
                return ForgeResponseBuilder.Response<ICommand>(ForgeResponseCode.ArgumentsMissing);
            }

            // OJN: This definitely needs better handling. Not safe at all.

            ICommand command = new SpecCommand
            {
                FilePath = args[2],
                FunctionName = args[4],
            };

            return ForgeResponseBuilder.Response(command, ForgeResponseCode.Success);
        }
    }
}
