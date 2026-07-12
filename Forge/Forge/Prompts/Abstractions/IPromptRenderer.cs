using Forge.Results;

namespace Forge.Prompts.Abstractions
{
    public interface IPromptRenderer
    {
        ForgeResponse<string> Render(string prompt, IDictionary<string, string> arguments);
    }
}
