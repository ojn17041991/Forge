using Forge.Abstractions.Verbs.Commands;

namespace Forge.Abstractions.Verbs.Executors
{
    public interface ITypedExecutor<T> : IExecutor where T : ICommand
    {
        bool Execute(T command);
    }
}
