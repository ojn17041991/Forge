using Forge.Constants;
using Forge.Data.Abstractions;
using Forge.Enums;
using Forge.OpenAi.Abstractions;
using Forge.Prompts.Abstractions;
using Forge.Responses;
using Forge.Responses.Abstractions;
using Forge.Results;
using Forge.Schemas.Abstractions;
using Forge.Schemas.Spec.Context;
using Forge.Schemas.Spec.Result;
using Forge.Verbs.Abstractions.Executors;
using Forge.Verbs.Abstractions.Schema;
using System.Text.Json;

namespace Forge.Commands.Spec
{
    public class SpecExecutor(
        IPromptRenderer promptRenderer,
        IPromptRepository promptRepository,
        IOpenAiService openAiService,
        IForgeResponseParser forgeResponseValidator,
        ISpecificationRepository dataStore,
        ISchemaTemplateBuilder schemaTemplateBuilder,
        ISchemaBuilder<SpecCommand, SpecContextSchema> contextSchemaBuilder
    ) : TypedExecutor<SpecCommand>
    {
        public override CommandVerb Verb => CommandVerb.Spec;

        public async override Task<ForgeResponse<string>> Execute(SpecCommand command)
        {
            // Read raw prompt.
            ForgeResponse<string> prompt = promptRepository.Read(Verb);
            if (prompt.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(prompt.ResponseCode);
            }

            // Build the context schema.
            ForgeResponse<SpecContextSchema> contextSchema = contextSchemaBuilder.Build(command);
            if (contextSchema.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(prompt.ResponseCode);
            }

            // Serialize the context schema for the prompt.
            string contextSchemaJson = JsonSerializer.Serialize(contextSchema.Data);

            // Build the result schema template.
            ForgeResponse<string> schemaResponse = schemaTemplateBuilder.Build<ForgeResponse<SpecResultSchema>>();
            if (schemaResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(schemaResponse.ResponseCode);
            }

            // Build the wildcard dictionary.
            IDictionary<string, string> renderArguments = new Dictionary<string, string>
            {
                {
                    WildcardConstants.Context,
                    contextSchemaJson
                },
                {
                    WildcardConstants.Schema,
                    schemaResponse.Data!
                }
            };

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
            ForgeResponse<SpecResultSchema> responseValidationResponse = forgeResponseValidator.Parse<SpecResultSchema>(openAiResponse.Data!);
            if (responseValidationResponse.IsUsable == false)
            {
                return ForgeResponseBuilder.Response<string>(responseValidationResponse.ResponseCode);
            }

            // Build a new Specification ID.
            string specificationId = Guid.NewGuid().ToString().Replace("-", string.Empty);

            // OJN: I might need to rethink this as the back-and-forth serialize/deserialize seems a bit wasteful.
            string specificationContent = JsonSerializer.Serialize(
                responseValidationResponse.Data,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            // Store the response with new Specification ID as a .forgespec file.
            ForgeResponse dataStoreResponse = await dataStore.Save(specificationId, specificationContent);
            if (dataStoreResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(dataStoreResponse.ResponseCode);
            }

            // Return the Specification ID.
            // Return the validation response code here, as it will either be Success or Incomplete...
            // ...and that response must propagate back to the console for output.
            return ForgeResponseBuilder.Response(specificationId, responseValidationResponse.ResponseCode);
        }
    }
}

