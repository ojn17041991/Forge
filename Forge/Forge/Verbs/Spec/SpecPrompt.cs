using Forge.Abstractions.Verbs.Prompts;
using Forge.Enums;

namespace Forge.Verbs.Spec
{
    public class SpecPrompt : IPrompt
    {
        public CommandVerb Verb => CommandVerb.Spec;

        public string Path => "SpecPrompt.md";
    }
}
