using Forge.Commands.Interfaces;

namespace Forge.Executors.Interfaces
{
    public interface IExecutor : ICommandService
    {
        bool Execute(ICommand command);
    }
}
