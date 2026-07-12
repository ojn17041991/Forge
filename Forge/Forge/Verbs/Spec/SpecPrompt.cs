using Forge.Enums;
using Forge.Verbs.Abstractions.Prompts;

namespace Forge.Verbs.Spec
{
    public class SpecPrompt : IPrompt
    {
        public CommandVerb Verb => CommandVerb.Spec;

        public string Path => "SpecPrompt.md";
    }
}
