using Forge.Abstractions.Pipeline;
using Forge.Abstractions.Services;
using Forge.Abstractions.Verbs.Commands;

namespace Forge.Pipeline
{
    public class ForgeRunner(
        ICommandFactory commandFactory,
        ICommandDispatcher commandDispatcher
    ) : IForgeRunner
    {
        private readonly ICommandFactory commandFactory = commandFactory;
        private readonly ICommandDispatcher commandDispatcher = commandDispatcher;

        public bool Run(string[] args)
        {
            // Step 1 - Receive input with args.
            // Handled by the framework.

            // Step 2 - Get a command from the factory.
            ICommand? command = commandFactory.Build(args);
            if (command == null)
            {
                return false;
            }

            // Step 3 - Dispatch the command.
            bool result = commandDispatcher.Dispatch(command);
            if (result == false)
            {
                return false;
            }

            // Step 4 - Return the result for output processing.
            return true;

            // TODO:
            // - Need to plug in the API and make things asynchronous. Needs its own service.
            // - Add logging.
            // - Return dataResponse from services?

            //using Microsoft.Extensions.Configuration;
            //using OpenAI.Chat;

            //var builder = new ConfigurationBuilder()
            //    .AddUserSecrets<Program>()
            //    .Build();

            //var key = builder["OpenAi:SecretKey"];

            //ChatClient client = new("gpt-4.1-mini", key);

            //ChatCompletion completion = client.CompleteChat("Say 'this is a test.'");

            //Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
        }
    }
}
