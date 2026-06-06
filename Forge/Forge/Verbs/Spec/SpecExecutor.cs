using Forge.Abstractions.Verbs.Executors;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;

namespace Forge.Commands.Spec
{
    public class SpecExecutor() : TypedExecutor<SpecCommand>
    {
        public override CommandVerb Verb => CommandVerb.Spec;

        public override ForgeResponse Execute(SpecCommand command)
        {
            //using Microsoft.Extensions.Configuration;
            //using OpenAI.Chat;

            //var builder = new ConfigurationBuilder()
            //    .AddUserSecrets<Program>()
            //    .Build();

            //var key = builder["OpenAi:SecretKey"];

            //ChatClient client = new("gpt-4.1-mini", key);

            //ChatCompletion completion = client.CompleteChat("Say 'this is a test.'");

            //Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");

            return ForgeResponseBuilder.Response(ForgeResponseCode.Success);
        }
    }
}
