using Forge.Abstractions.OpenAi;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;

namespace Forge.OpenAi
{
    public class OpenAiService : IOpenAiService
    {
        private readonly ChatClient client;

        public OpenAiService(IConfiguration configuration)
        {
            string? apiVersion = configuration["OpenAi:Version"] ?? throw new InvalidOperationException("OpenAi:Version must be present in configuration.");
            string? apiKey = configuration["OpenAi:SecretKey"] ?? throw new InvalidOperationException("OpenAi:SecretKey must be present in configuration.");

            if (apiKey == "IN SECRETS")
            {
                throw new InvalidOperationException("OpenAi:SecretKey must be present in secret provider.");
            }

            client = new ChatClient(apiVersion, apiKey);
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
