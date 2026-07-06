using Forge.Abstractions.Verbs.Prompts;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;
using System.Text.RegularExpressions;

namespace Forge.Infrastructure.Prompts
{
    public class PromptRenderer : IPromptRenderer
    {
        public ForgeResponse<string> Render(string prompt, IDictionary<string, string> arguments)
        {
            string renderedPrompt = prompt;

            foreach (KeyValuePair<string, string> argument in arguments)
            {
                string pattern = $@"\{{\{{\s*{argument.Key}\s*\}}\}}";

                renderedPrompt = Regex.Replace(renderedPrompt, pattern, argument.Value);
            }

            return ForgeResponseBuilder.Response(renderedPrompt, ForgeResponseCode.Success);
        }
    }
}
