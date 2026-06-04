using Forge.Abstractions.Services;
using Forge.Abstractions.Verbs.Commands;
using Forge.Abstractions.Verbs.Executors;
using Forge.Enums;
using Forge.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Services
{
    public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public ForgeResponse Dispatch(ICommand command)
        {
            IEnumerable<IExecutor> commandExecutors = serviceProvider.GetServices<IExecutor>();
            if (commandExecutors.Count() == 0)
            {
                return new ForgeResponse
                {
                    ResponseCode = ForgeResponseCode.Error
                };
            }

            IExecutor? commandExecutor = commandExecutors.SingleOrDefault(x => x.Verb == command.Verb);
            if (commandExecutor == null)
            {
                return new ForgeResponse
                {
                    ResponseCode = ForgeResponseCode.Error
                };
            }

            ForgeResponse commandExecutionResponse = commandExecutor.Execute(command);
            if (commandExecutionResponse.Success == false)
            {
                // OJN: Redundant, but logging will be added later.
            }

            return commandExecutionResponse;
        }
    }
}
