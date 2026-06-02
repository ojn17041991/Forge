using Forge.Commands.Interfaces;

namespace Forge.Commands.Dependencies
{
    public class CommandExecutor : ICommandExecutor
    {
        public bool Execute<T>(T command) where T : ICommand
        {
            throw new NotImplementedException();
        }
    }
}
