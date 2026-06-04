using Forge.Abstractions.Services;
using Forge.Abstractions.Verbs.Commands;
using Forge.Enums;
using Forge.Extensions;
using Forge.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Services
{
    public class CommandFactory(IServiceProvider serviceProvider) : ICommandFactory
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public ForgeResponse<ICommand> Build(string[] args)
        {
            if (args.Length < 1)
            {
                return new ForgeResponse<ICommand>
                {
                    ResponseCode = ForgeResponseCode.VerbMissing,
                    Data = null
                };
            }

            var verb = args[0].ToEnum<CommandVerb>();
            if (verb == null)
            {
                return new ForgeResponse<ICommand>
                {
                    ResponseCode = ForgeResponseCode.VerbNotRecognized,
                    Data = null
                };
            }

            var commandBuilders = serviceProvider.GetServices<ICommandBuilder>();
            if (commandBuilders == null || commandBuilders.Count() == 0)
            {
                return new ForgeResponse<ICommand>
                {
                    ResponseCode = ForgeResponseCode.Error,
                    Data = null
                };
            }

            var commandBuilder = commandBuilders.SingleOrDefault(x => x.Verb == verb);
            if (commandBuilder == null)
            {
                return new ForgeResponse<ICommand>
                {
                    ResponseCode = ForgeResponseCode.Error,
                    Data = null
                };
            }

            var commandBuildResponse = commandBuilder.Build(args);
            if (commandBuildResponse.Success == false)
            {
                return new ForgeResponse<ICommand>
                {
                    ResponseCode = commandBuildResponse.ResponseCode,
                    Data = null
                };
            }

            return commandBuildResponse;
        }
    }
}
