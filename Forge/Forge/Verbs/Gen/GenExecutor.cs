using Forge.Abstractions.Data;
using Forge.Abstractions.OpenAi;
using Forge.Abstractions.Responses;
using Forge.Abstractions.Schemas;
using Forge.Abstractions.Verbs.Executors;
using Forge.Abstractions.Verbs.Prompts;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;
using Forge.Schemas.Gen.Result;

namespace Forge.Verbs.Gen
{
    public class GenExecutor(
        IPromptRenderer promptRenderer,
        IPromptRepository promptRepository,
        IOpenAiService openAiService,
        IForgeResponseParser forgeResponseValidator,
        ISpecificationStore dataStore,
        ISchemaSerializer schemaSerializer
    ) : TypedExecutor<GenCommand>
    {
        public override CommandVerb Verb => CommandVerb.Gen;

        // OJN: These are responsibilities of the prompts. Do they belong here?
        private const string contextWildcard = "CONTEXT";
        private const string schemaWildcard = "SCHEMA";

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

            ForgeResponse<string> schemaResponse = schemaSerializer.Serialize<ForgeResponse<GenResultSchema>>();
            if (schemaResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(schemaResponse.ResponseCode);
            }

            IDictionary<string, string> renderArguments = new Dictionary<string, string>
            {
                {
                    contextWildcard,
                    specificationResponse.Data!
                },
                {
                    schemaWildcard,
                    schemaResponse.Data!
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

            ForgeResponse<GenResultSchema> responseValidationResponse = forgeResponseValidator.Parse<GenResultSchema>(openAiResponse.Data!);
            if (responseValidationResponse.IsUsable == false)
            {
                return ForgeResponseBuilder.Response<string>(responseValidationResponse.ResponseCode);
            }

            return ForgeResponseBuilder.Response(responseValidationResponse.Data!.Code, ForgeResponseCode.Success);
        }
    }
}
