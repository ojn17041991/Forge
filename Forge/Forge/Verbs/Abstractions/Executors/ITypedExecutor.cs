using Forge.Results;
using Forge.Verbs.Abstractions.Commands;

namespace Forge.Verbs.Abstractions.Executors
{
    public interface ITypedExecutor<T> : IExecutor where T : ICommand
    {
        Task<ForgeResponse<string>> Execute(T command);
    }
}
