using Forge.Abstractions.Verbs.Executors;
using Forge.Abstractions.Verbs.Prompts;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;

namespace Forge.Commands.Spec
{
    public class SpecExecutor(IPromptReader promptReader) : TypedExecutor<SpecCommand>
    {
        private readonly IPromptReader promptReader = promptReader;

        public override CommandVerb Verb => CommandVerb.Spec;

        public override ForgeResponse<string> Execute(SpecCommand command)
        {
            ForgeResponse<string> prompt = promptReader.Read(Verb);
            if (prompt.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.Error);
            }

            //using Microsoft.Extensions.Configuration;
            //using OpenAI.Chat;

            //var key = builder["OpenAi:SecretKey"];

            //ChatClient client = new("gpt-4.1-mini", key);

            //ChatCompletion completion = client.CompleteChat("Say 'this is a test.'");

            //Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");

            return ForgeResponseBuilder.Response<string>(string.Empty, ForgeResponseCode.Success); // OJN: Need OpenAiService to return actual data.
        }
    }
}
