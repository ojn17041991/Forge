using Forge.Results;
using Forge.Verbs.Abstractions.Verbs;

namespace Forge.Verbs.Abstractions.Commands
{
    public interface ICommandBuilder : IVerb
    {
        ForgeResponse<ICommand> Build(string[] args);
    }
}
