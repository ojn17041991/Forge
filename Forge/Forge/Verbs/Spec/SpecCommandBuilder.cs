using Forge.Abstractions.Verbs.Commands;
using Forge.Enums;
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
                return new ForgeResponse<ICommand>
                {
                    ResponseCode = ForgeResponseCode.ArgumentsMissing,
                    Data = null
                };
            }

            return new ForgeResponse<ICommand>
            {
                ResponseCode = ForgeResponseCode.Success,
                Data = new SpecCommand
                {
                    FileName = args[2]
                }
            };
        }
    }
}
