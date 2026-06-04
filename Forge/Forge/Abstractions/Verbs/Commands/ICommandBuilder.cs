using Forge.Results;

namespace Forge.Abstractions.Verbs.Commands
{
    public interface ICommandBuilder : ICommandService
    {
        ForgeResponse<ICommand> Build(string[] args);
    }
}
