using Forge.Abstractions.Verbs.Commands;
using Forge.Results;

namespace Forge.Abstractions.Verbs.Executors
{
    public interface IExecutor : ICommandService
    {
        ForgeResponse Execute(ICommand command);
    }
}
