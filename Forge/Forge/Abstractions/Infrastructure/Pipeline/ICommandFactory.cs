using Forge.Abstractions.Verbs.Commands;
using Forge.Results;

namespace Forge.Abstractions.Infrastructure.Pipeline
{
    public interface ICommandFactory
    {
        ForgeResponse<ICommand> Build(string[] args);
    }
}
