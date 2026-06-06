using Forge.Abstractions.Verbs.Commands;
using Forge.Results;

namespace Forge.Abstractions.Verbs.Executors
{
    public interface ITypedExecutor<T> : IExecutor where T : ICommand
    {
        Task<ForgeResponse<string>> Execute(T command);
    }
}
