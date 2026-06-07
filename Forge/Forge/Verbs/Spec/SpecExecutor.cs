using Forge.Abstractions.Data;
using Forge.Abstractions.OpenAi;
using Forge.Abstractions.Verbs.Executors;
using Forge.Abstractions.Verbs.Prompts;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;

namespace Forge.Commands.Spec
{
    public class SpecExecutor(
        IPromptRenderer promptRenderer,
        IPromptRepository promptRepository,
        IOpenAiService openAiService,
        ISpecificationStore dataStore
    ) : TypedExecutor<SpecCommand>
    {
        private readonly IPromptRenderer promptRenderer = promptRenderer;
        private readonly IPromptRepository promptRepository = promptRepository;
        private readonly IOpenAiService openAiService = openAiService;
        private readonly ISpecificationStore dataStore = dataStore;

        private const string promptCodeWildcard = "CODE";

        public override CommandVerb Verb => CommandVerb.Spec;

        public async override Task<ForgeResponse<string>> Execute(SpecCommand command)
        {
            ForgeResponse<string> prompt = promptRepository.Read(Verb);
            if (prompt.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(prompt.ResponseCode);
            }

            if (File.Exists(command.FilePath) == false)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.FileMissing);
            }

            string fileContent = File.ReadAllText(command.FilePath);

            IDictionary<string, string> renderArguments = new Dictionary<string, string>
            {
                {
                    promptCodeWildcard,
                    fileContent
                }
            };

            ForgeResponse<string> promptRenderResponse = promptRenderer.Render(prompt.Data!, renderArguments);
            if (promptRenderResponse.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(promptRenderResponse.ResponseCode);
            }

            ForgeResponse<string> openAiResponse = await openAiService.Speak(promptRenderResponse.Data!);
            if (openAiResponse.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(openAiResponse.ResponseCode);
            }

            string specificationId = Guid.NewGuid().ToString().Replace("-", string.Empty);

            ForgeResponse dataStoreResponse = await dataStore.Save(specificationId, openAiResponse.Data!);
            if (dataStoreResponse.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(dataStoreResponse.ResponseCode);
            }

            return ForgeResponseBuilder.Response(specificationId, ForgeResponseCode.Success);
        }
    }
}
