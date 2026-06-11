using Forge.Abstractions.Verbs.Prompts;
using Forge.Enums;

namespace Forge.Verbs.Gen
{
    public class GenPrompt : IPrompt
    {
        public CommandVerb Verb => CommandVerb.Gen;

        public string Path => "GenPrompt.md";
    }
}
