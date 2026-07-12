using Forge.Results;
using Forge.Verbs.Abstractions.Commands;

namespace Forge.Commands.Abstractions
{
    public interface ICommandFactory
    {
        ForgeResponse<ICommand> Build(string[] args);
    }
}
