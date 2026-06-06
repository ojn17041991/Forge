using Forge.Enums;
using Forge.Results;

namespace Forge.Abstractions.Verbs.Prompts
{
    public interface IPromptReader
    {
        ForgeResponse<string> Read(CommandVerb verb);
    }
}
