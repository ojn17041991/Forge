using Forge.Enums;
using Forge.Prompts.Abstractions;
using Forge.Responses;
using Forge.Results;
using System.Text.RegularExpressions;

namespace Forge.Prompts
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
