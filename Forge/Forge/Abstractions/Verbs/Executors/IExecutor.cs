using Forge.Abstractions.Verbs.Commands;

namespace Forge.Abstractions.Verbs.Executors
{
    public interface IExecutor : ICommandService
    {
        bool Execute(ICommand command);
    }
}
