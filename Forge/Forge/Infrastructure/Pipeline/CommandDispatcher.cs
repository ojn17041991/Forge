using Forge.Abstractions.Services;
using Forge.Abstractions.Verbs.Commands;
using Forge.Abstractions.Verbs.Executors;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Infrastructure.Pipeline
{
    public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public ForgeResponse Dispatch(ICommand command)
        {
            IEnumerable<IExecutor> commandExecutors = serviceProvider.GetServices<IExecutor>();
            if (commandExecutors.Count() == 0)
            {
                return ForgeResponseBuilder.Response(ForgeResponseCode.Error);
            }

            IExecutor? commandExecutor = commandExecutors.SingleOrDefault(x => x.Verb == command.Verb);
            if (commandExecutor == null)
            {
                return ForgeResponseBuilder.Response(ForgeResponseCode.Error);
            }

            ForgeResponse<string> commandExecutionResponse = commandExecutor.Execute(command);
            if (commandExecutionResponse.Success == false)
            {
                // Redundant, but will log here later.
            }

            return ForgeResponseBuilder.Response(commandExecutionResponse.ResponseCode);
        }
    }
}
