using Forge.Commands.Abstractions;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;
using Forge.Verbs.Abstractions.Commands;
using Forge.Verbs.Abstractions.Executors;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Commands
{
    public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
    {
        public async Task<ForgeResponse<string>> Dispatch(ICommand command)
        {
            IEnumerable<IExecutor> commandExecutors = serviceProvider.GetServices<IExecutor>();
            if (commandExecutors.Count() == 0)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.Error);
            }

            IExecutor? commandExecutor = commandExecutors.SingleOrDefault(x => x.Verb == command.Verb);
            if (commandExecutor == null)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.Error);
            }

            ForgeResponse<string> commandExecutionResponse = await commandExecutor.Execute(command);
            if (commandExecutionResponse.IsSuccess == false)
            {
                // Redundant, but will log here later.
            }

            return ForgeResponseBuilder.Response(commandExecutionResponse.Data!, commandExecutionResponse.ResponseCode);
        }
    }
}
