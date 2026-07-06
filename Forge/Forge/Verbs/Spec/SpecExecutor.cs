using Forge.Abstractions.Data;
using Forge.Abstractions.OpenAi;
using Forge.Abstractions.Responses;
using Forge.Abstractions.Schemas;
using Forge.Abstractions.Verbs.Executors;
using Forge.Abstractions.Verbs.Prompts;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;
using Forge.Schemas.Spec.Result;
using System.Text.Json;

namespace Forge.Commands.Spec
{
    public class SpecExecutor(
        IPromptRenderer promptRenderer,
        IPromptRepository promptRepository,
        IOpenAiService openAiService,
        IForgeResponseParser forgeResponseValidator,
        ISpecificationStore dataStore,
        ISchemaSerializer schemaSerializer
    ) : TypedExecutor<SpecCommand>
    {
        // OJN: These are responsibilities of the prompts. Do they belong here?
        private const string promptCodeWildcard = "CONTEXT";
        private const string outputSchemaWildcard = "SCHEMA";

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

            ForgeResponse<string> schemaResponse = schemaSerializer.Serialize<ForgeResponse<SpecResultSchema>>();
            if (schemaResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(schemaResponse.ResponseCode);
            }

            IDictionary<string, string> renderArguments = new Dictionary<string, string>
            {
                {
                    promptCodeWildcard,
                    fileContent
                },
                {
                    outputSchemaWildcard,
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

            ForgeResponse<SpecResultSchema> responseValidationResponse = forgeResponseValidator.Parse<SpecResultSchema>(openAiResponse.Data!);
            if (responseValidationResponse.IsUsable == false)
            {
                return ForgeResponseBuilder.Response<string>(responseValidationResponse.ResponseCode);
            }

            string specificationId = Guid.NewGuid().ToString().Replace("-", string.Empty);

            // OJN: I might need to rethink this as the back-and-forth serialize/deserialize seems a bit wasteful.
            string specificationContent = JsonSerializer.Serialize(
                responseValidationResponse.Data,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            ForgeResponse dataStoreResponse = await dataStore.Save(specificationId, specificationContent);
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

