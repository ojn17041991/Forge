using Forge.Abstractions.Services;
using Forge.Abstractions.Verbs.Commands;
using Forge.Abstractions.Verbs.Executors;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Services
{
    public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public bool Dispatch(ICommand command)
        {
            try
            {
                var commandExecutors = serviceProvider.GetServices<IExecutor>();
                if (commandExecutors == null || commandExecutors.Count() == 0)
                {
                    return false;
                }

                var commandExecutor = commandExecutors.SingleOrDefault(x => x.Verb == command.Verb);
                if (commandExecutor == null)
                {
                    return false;
                }

                return commandExecutor.Execute(command);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}
