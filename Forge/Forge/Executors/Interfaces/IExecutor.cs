using Forge.Commands.Interfaces;

namespace Forge.Handlers.Abstract
{
    public interface IExecutor<T> where T : ICommand
    {
        bool Execute(T command);
    }
}
