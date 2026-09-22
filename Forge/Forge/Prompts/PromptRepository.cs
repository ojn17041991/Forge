using Forge.Enums;
using Forge.Prompts.Abstractions;
using Forge.Responses;
using Forge.Results;
using Forge.Verbs.Abstractions.Prompts;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Prompts
{
    public class PromptRepository(IServiceProvider serviceProvider) : IPromptRepository
    {
        private const string promptDirectory = "Prompts/Files";

        public ForgeResponse<string> Read(CommandVerb verb)
        {
            IEnumerable<IPrompt> commandPrompts = serviceProvider.GetServices<IPrompt>();
            if (commandPrompts.Count() == 0)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.Error);
            }

            IPrompt? commandPrompt = commandPrompts.SingleOrDefault(x => x.Verb == verb);
            if (commandPrompt == null)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.Error);
            }

            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                promptDirectory,
                commandPrompt.Path
            );

            if (File.Exists(filePath) == false)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.Error);
            }

            string fileContent = File.ReadAllText(filePath);

            return ForgeResponseBuilder.Response(fileContent, ForgeResponseCode.Success);
        }
    }
}
