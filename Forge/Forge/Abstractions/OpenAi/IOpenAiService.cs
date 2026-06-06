using Forge.Results;

namespace Forge.Abstractions.OpenAi
{
    public interface IOpenAiService
    {
        Task<ForgeResponse<string>> Speak(string prompt);
    }
}
