using Forge.Abstractions.Data;
using Forge.Abstractions.OpenAi;
using Forge.Abstractions.Responses;
using Forge.Abstractions.Verbs.Executors;
using Forge.Abstractions.Verbs.Prompts;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;
using Forge.Schemas.Specification.Result;

namespace Forge.Commands.Spec
{
    public class SpecExecutor(
        IPromptRenderer promptRenderer,
        IPromptRepository promptRepository,
        IOpenAiService openAiService,
        IForgeResponseParser forgeResponseValidator,
        ISpecificationStore dataStore
    ) : TypedExecutor<SpecCommand>
    {
        private const string promptCodeWildcard = "CONTEXT";

        public override CommandVerb Verb => CommandVerb.Spec;

        public async override Task<ForgeResponse<string>> Execute(SpecCommand command)
        {
            ForgeResponse<string> prompt = promptRepository.Read(Verb);
            if (prompt.IsSuccess == false)
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
            if (promptRenderResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(promptRenderResponse.ResponseCode);
            }

            ForgeResponse<string> openAiResponse = await openAiService.Speak(promptRenderResponse.Data!);
            if (openAiResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(openAiResponse.ResponseCode);
            }

            ForgeResponse<SpecificationResultSchema> responseValidationResponse = forgeResponseValidator.Parse<SpecificationResultSchema>(openAiResponse.Data!);
            if (responseValidationResponse.IsUsable == false)
            {
                return ForgeResponseBuilder.Response<string>(responseValidationResponse.ResponseCode);
            }

            string specificationId = Guid.NewGuid().ToString().Replace("-", string.Empty);

            ForgeResponse dataStoreResponse = await dataStore.Save(specificationId, openAiResponse.Data!);
            if (dataStoreResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(dataStoreResponse.ResponseCode);
            }

            // Return the validation response code here, as it will either be Success or Incomplete...
            // ...and that response must propagate back to the console for output.
            return ForgeResponseBuilder.Response(specificationId, responseValidationResponse.ResponseCode);
        }
    }
}
