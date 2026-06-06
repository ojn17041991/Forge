using Forge.Abstractions.Services;
using Forge.Abstractions.Verbs.Commands;
using Forge.Enums;
using Forge.Extensions;
using Forge.Responses;
using Forge.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Infrastructure.Pipeline
{
    public class CommandFactory(IServiceProvider serviceProvider) : ICommandFactory
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public ForgeResponse<ICommand> Build(string[] args)
        {
            if (args.Length < 1)
            {
                return ForgeResponseBuilder.Response<ICommand>(ForgeResponseCode.VerbMissing);
            }

            var verb = args[0].ToEnum<CommandVerb>();
            if (verb == null)
            {
                return ForgeResponseBuilder.Response<ICommand>(ForgeResponseCode.VerbNotRecognized);
            }

            var commandBuilders = serviceProvider.GetServices<ICommandBuilder>();
            if (commandBuilders == null || commandBuilders.Count() == 0)
            {
                return ForgeResponseBuilder.Response<ICommand>(ForgeResponseCode.Error);
            }

            var commandBuilder = commandBuilders.SingleOrDefault(x => x.Verb == verb);
            if (commandBuilder == null)
            {
                return ForgeResponseBuilder.Response<ICommand>(ForgeResponseCode.Error);
            }

            var commandBuildResponse = commandBuilder.Build(args);
            if (commandBuildResponse.Success == false)
            {
                return ForgeResponseBuilder.Response<ICommand>(commandBuildResponse.ResponseCode);
            }

            return commandBuildResponse;
        }
    }
}
