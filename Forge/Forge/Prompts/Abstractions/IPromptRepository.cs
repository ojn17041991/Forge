using Forge.Enums;
using Forge.Results;

namespace Forge.Prompts.Abstractions
{
    public interface IPromptRepository
    {
        ForgeResponse<string> Read(CommandVerb verb);
    }
}
