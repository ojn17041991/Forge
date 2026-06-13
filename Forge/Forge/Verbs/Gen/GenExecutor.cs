using Forge.Abstractions.Data;
using Forge.Abstractions.OpenAi;
using Forge.Abstractions.Verbs.Executors;
using Forge.Abstractions.Verbs.Prompts;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;

namespace Forge.Verbs.Gen
{
    public class GenExecutor(
        IPromptRenderer promptRenderer,
        IPromptRepository promptRepository,
        IOpenAiService openAiService,
        ISpecificationStore dataStore
    ) : TypedExecutor<GenCommand>
    {
        public override CommandVerb Verb => CommandVerb.Gen;

        private const string testCasesWildcard = "TEST_CASES";

        public override async Task<ForgeResponse<string>> Execute(GenCommand command)
        {
            ForgeResponse<string> prompt = promptRepository.Read(Verb);
            if (prompt.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(prompt.ResponseCode);
            }

            ForgeResponse<string> specificationResponse = await dataStore.Get(command.SpecificationId);
            if (specificationResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(specificationResponse.ResponseCode);
            }

            IDictionary<string, string> renderArguments = new Dictionary<string, string>
            {
                {
                    testCasesWildcard,
                    specificationResponse.Data!
                }
            };

            ForgeResponse<string> promptRenderResponse = promptRenderer.Render(prompt.Data!, renderArguments);
            if (promptRenderResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(promptRenderResponse.ResponseCode);
            }

            ForgeResponse<string> openAiResponse = await openAiService.Speak(promptRenderResponse.Data!);
            if (openAiResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(openAiResponse.ResponseCode);
            }

            return ForgeResponseBuilder.Response(openAiResponse.Data!, ForgeResponseCode.Success);
        }
    }
}
