using Forge.Results;

namespace Forge.OpenAi.Abstractions
{
    public interface IOpenAiService
    {
        Task<ForgeResponse<string>> Speak(string prompt);
    }
}
