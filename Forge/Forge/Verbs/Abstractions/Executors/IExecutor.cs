using Forge.Results;
using Forge.Verbs.Abstractions.Commands;
using Forge.Verbs.Abstractions.Verbs;

namespace Forge.Verbs.Abstractions.Executors
{
    public interface IExecutor : IVerb
    {
        Task<ForgeResponse<string>> Execute(ICommand command);
    }
}
