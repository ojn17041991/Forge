using Forge.Enums;
using Forge.Verbs.Abstractions.Prompts;

namespace Forge.Verbs.Gen
{
    public class GenPrompt : IPrompt
    {
        public CommandVerb Verb => CommandVerb.Gen;

        public string Path => "GenPrompt.md";
    }
}
