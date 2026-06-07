using Forge.Abstractions.Verbs.Commands;
using Forge.Results;

namespace Forge.Abstractions.Infrastructure.Pipeline
{
    public interface ICommandDispatcher
    {
        Task<ForgeResponse<string>> Dispatch(ICommand command);
    }
}
