using Forge.Abstractions.Verbs.Verbs;

namespace Forge.Abstractions.Verbs.Prompts
{
    public interface IPrompt : IVerb
    {
        string Path { get; }
    }
}
