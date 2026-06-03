using Forge.Commands.Interfaces;
using Forge.Executors.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Commands.Dependencies
{
    public class CommandExecutor(IServiceProvider serviceProvider) : ICommandExecutor
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public bool Execute(ICommand command)
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
