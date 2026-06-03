using Forge.Commands.Interfaces;
using Forge.Executors.Interfaces;

namespace Forge.Handlers.Abstract
{
    public interface ITypedExecutor<T> : IExecutor where T : ICommand
    {
        bool Execute(T command);
    }
}
