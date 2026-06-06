using Forge.Abstractions.Verbs.Commands;
using Forge.Results;

namespace Forge.Abstractions.Services
{
    public interface ICommandDispatcher
    {
        Task<ForgeResponse> Dispatch(ICommand command);
    }
}
