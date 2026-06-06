using Forge.Abstractions.Verbs.Commands;
using Forge.Abstractions.Verbs.Verbs;
using Forge.Results;

namespace Forge.Abstractions.Verbs.Executors
{
    public interface IExecutor : IVerb
    {
        ForgeResponse<string> Execute(ICommand command);
    }
}
