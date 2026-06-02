using Forge.Commands.Dependencies;
using Forge.Commands.Interfaces;
//using Microsoft.Extensions.Configuration;
//using OpenAI.Chat;

//var builder = new ConfigurationBuilder()
//    .AddUserSecrets<Program>()
//    .Build();

//var key = builder["OpenAi:SecretKey"];

//ChatClient client = new("gpt-4.1-mini", key);

//ChatCompletion completion = client.CompleteChat("Say 'this is a test.'");

//Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");

// Step 1 - Receive input with args.
// Handled by the framework.

// Step 2 - Use the CommandFactory to convert the input data into a Command model.
CommandFactory commandFactory = new CommandFactory();
ICommand command = commandFactory.Build(args);

// Step 3 - Use the CommandExecutor to execute the Command.
CommandExecutor commandExecutor = new CommandExecutor();
bool result = commandExecutor.Execute(command);

// TODO:
// - Need to setup DI to properly pull down the factory classes and the commands and executors within the factories.
// - Need to plug in the API and make things asynchronous.