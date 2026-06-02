using Forge.Commands.Interfaces;

namespace Forge.Commands.Dependencies
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand Build(string[] args)
        {
            // Use DI to find all ICommands and then pick the one with the correct Enum value.
            throw new NotImplementedException();
        }
    }
}
