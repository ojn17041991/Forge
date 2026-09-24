using Forge.Data.Abstractions;
using Forge.Enums;
using Forge.OpenAi.Abstractions;
using Forge.Prompts.Abstractions;
using Forge.Responses;
using Forge.Responses.Abstractions;
using Forge.Results;
using Forge.Schemas.Abstractions;
using Forge.Schemas.Gen.Result;
using Forge.Verbs.Abstractions.Executors;

namespace Forge.Verbs.Gen
{
    public class GenExecutor(
        IPromptRenderer promptRenderer,
        IPromptRepository promptRepository,
        IOpenAiService openAiService,
        IForgeResponseParser forgeResponseValidator,
        ISpecificationRepository dataStore,
        ISchemaTemplateBuilder schemaSerializer
    ) : TypedExecutor<GenCommand>
    {
        public override CommandVerb Verb => CommandVerb.Gen;

        // OJN: These are responsibilities of the prompts. Do they belong here?
        private const string contextWildcard = "CONTEXT";
        private const string schemaWildcard = "SCHEMA";

        public override async Task<ForgeResponse<string>> Execute(GenCommand command)
        {
            // Read raw prompt.
            ForgeResponse<string> prompt = promptRepository.Read(Verb);
            if (prompt.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(prompt.ResponseCode);
            }

            // Read the requested .forgespec file content.
            ForgeResponse<string> specificationResponse = await dataStore.Get(command.SpecificationId);
            if (specificationResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(specificationResponse.ResponseCode);
            }

            // Build the result schema template.
            ForgeResponse<string> schemaResponse = schemaSerializer.Build<ForgeResponse<GenResultSchema>>();
            if (schemaResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(schemaResponse.ResponseCode);
            }

            // Build the wildcard dictionary.
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

            // OJN: See item #11 in GitHub. The Gen context schema needs both the Spec context and result schemas to generate accurate test results.

            // Insert the schemas into the raw prompt as wildcards.
            ForgeResponse<string> promptRenderResponse = promptRenderer.Render(prompt.Data!, renderArguments);
            if (promptRenderResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(promptRenderResponse.ResponseCode);
            }

            // Make the request to Open AI.
            ForgeResponse<string> openAiResponse = await openAiService.Speak(promptRenderResponse.Data!);
            if (openAiResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(openAiResponse.ResponseCode);
            }

            // Confirm the response structure is as expected.
            ForgeResponse<GenResultSchema> responseValidationResponse = forgeResponseValidator.Parse<GenResultSchema>(openAiResponse.Data!);
            if (responseValidationResponse.IsUsable == false)
            {
                return ForgeResponseBuilder.Response<string>(responseValidationResponse.ResponseCode);
            }

            // Return the resulting test code.
            return ForgeResponseBuilder.Response(responseValidationResponse.Data!.Code, ForgeResponseCode.Success);
        }
    }
}
