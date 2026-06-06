using Forge.Abstractions.Verbs.Verbs;
using Forge.Results;

namespace Forge.Abstractions.Verbs.Commands
{
    public interface ICommandBuilder : IVerb
    {
        ForgeResponse<ICommand> Build(string[] args);
    }
}
