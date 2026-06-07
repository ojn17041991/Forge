using Forge.Results;

namespace Forge.Abstractions.Verbs.Prompts
{
    public interface IPromptRenderer
    {
        ForgeResponse<string> Render(string prompt, IDictionary<string, string> arguments);
    }
}
