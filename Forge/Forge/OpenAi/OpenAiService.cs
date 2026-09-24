using Forge.Enums;
using Forge.OpenAi.Abstractions;
using Forge.Responses;
using Forge.Results;
using Forge.Utilities;
using Microsoft.Extensions.Options;
using OpenAI.Chat;

namespace Forge.OpenAi
{
    public class OpenAiService : IOpenAiService
    {
        private readonly ChatClient client;

        public OpenAiService(IOptions<OpenAiOptions> options)
        {
            OpenAiOptions openAiOptions = options.Value ?? throw new InvalidOperationException("OpenAiOptions must be configured.");

            string version = openAiOptions.Version ?? throw new InvalidOperationException("OpenAi:Version must be present in configuration.");
            string secretKey = openAiOptions.SecretKey ?? throw new InvalidOperationException("OpenAi:SecretKey must be present in configuration.");

            if (secretKey == "IN SECRETS")
            {
                throw new InvalidOperationException("OpenAi:SecretKey must be present in secret provider.");
            }

            client = new ChatClient(version, secretKey);
        }

        public async Task<ForgeResponse<string>> Speak(string prompt)
        {
            ChatCompletion completion = await client.CompleteChatAsync(prompt);

            return ForgeResponseBuilder.Response(
                completion.Content[0].Text,
                ForgeResponseCode.Success
            );
        }
    }
}
