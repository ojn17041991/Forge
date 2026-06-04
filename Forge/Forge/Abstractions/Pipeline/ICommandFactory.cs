using Forge.Abstractions.Verbs.Commands;
using Forge.Results;

namespace Forge.Abstractions.Services
{
    public interface ICommandFactory
    {
        ForgeResponse<ICommand> Build(string[] args);
    }
}
