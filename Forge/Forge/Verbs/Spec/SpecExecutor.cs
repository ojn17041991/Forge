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
        IOpenAiService openAiService
    ) : TypedExecutor<SpecCommand>
    {
        private readonly IPromptReader promptReader = promptReader;
        private readonly IOpenAiService openAiService = openAiService;

        public override CommandVerb Verb => CommandVerb.Spec;

        public async override Task<ForgeResponse<string>> Execute(SpecCommand command)
        {
            ForgeResponse<string> prompt = promptReader.Read(Verb);
            if (prompt.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.Error);
            }

            ForgeResponse<string> openAiResponse = await openAiService.Speak(prompt.Data!);
            if (openAiResponse.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.Error);
            }

            return ForgeResponseBuilder.Response(openAiResponse.Data!, ForgeResponseCode.Success);
        }
    }
}
