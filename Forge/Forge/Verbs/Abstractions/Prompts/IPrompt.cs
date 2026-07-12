using Forge.Verbs.Abstractions.Verbs;

namespace Forge.Verbs.Abstractions.Prompts
{
    public interface IPrompt : IVerb
    {
        string Path { get; }
    }
}
