using Forge.Abstractions.Verbs.Prompts;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Infrastructure.Prompts
{
    public class PromptRepository(IServiceProvider serviceProvider) : IPromptRepository
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

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

            if (File.Exists(commandPrompt.Path) == false)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.Error);
            }

            string fileContent = File.ReadAllText(commandPrompt.Path);

            return ForgeResponseBuilder.Response(fileContent, ForgeResponseCode.Success);
        }
    }
}
