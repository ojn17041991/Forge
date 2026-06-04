using Forge.Abstractions.Verbs.Commands;

namespace Forge.Abstractions.Services
{
    public interface ICommandDispatcher
    {
        bool Dispatch(ICommand command);
    }
}
