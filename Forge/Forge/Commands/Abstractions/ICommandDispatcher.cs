using Forge.Results;
using Forge.Verbs.Abstractions.Commands;

namespace Forge.Commands.Abstractions
{
    public interface ICommandDispatcher
    {
        Task<ForgeResponse<string>> Dispatch(ICommand command);
    }
}
