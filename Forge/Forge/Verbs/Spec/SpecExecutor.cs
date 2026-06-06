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
        IPromptReader promptReader,
        IOpenAiService openAiService,
        IDataStore dataStore
    ) : TypedExecutor<SpecCommand>
    {
        private readonly IPromptReader promptReader = promptReader;
        private readonly IOpenAiService openAiService = openAiService;
        private readonly IDataStore dataStore = dataStore;

        public override CommandVerb Verb => CommandVerb.Spec;

        public async override Task<ForgeResponse<string>> Execute(SpecCommand command)
        {
            ForgeResponse<string> prompt = promptReader.Read(Verb);
            if (prompt.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(prompt.ResponseCode);
            }

            // OJN: The input data needs to be read using command.FilePath, then appended into the prompt. DataStore?

            ForgeResponse<string> openAiResponse = await openAiService.Speak(prompt.Data!);
            if (openAiResponse.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(openAiResponse.ResponseCode);
            }

            string specificationId = Guid.NewGuid().ToString().Replace("-", string.Empty);

            ForgeResponse dataStoreResponse = await dataStore.SaveSpecification(specificationId, openAiResponse.Data!);
            if (dataStoreResponse.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(dataStoreResponse.ResponseCode);
            }

            return ForgeResponseBuilder.Response(specificationId, ForgeResponseCode.Success);
        }
    }
}
