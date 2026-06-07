using Forge.Enums;
using Forge.Results;

namespace Forge.Abstractions.Verbs.Prompts
{
    public interface IPromptRepository
    {
        ForgeResponse<string> Read(CommandVerb verb);
    }
}
