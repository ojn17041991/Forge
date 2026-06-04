using Forge.Abstractions.Services;
using Forge.Abstractions.Verbs.Commands;
using Forge.Abstractions.Verbs.Executors;
using Forge.Commands.Spec;
using Forge.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<ICommandFactory, CommandFactory>();
builder.Services.AddSingleton<ICommandDispatcher, CommandDispatcher>();

builder.Services.AddTransient<ICommand, SpecCommand>();
builder.Services.AddTransient<ICommandBuilder, SpecCommandBuilder>();
builder.Services.AddTransient<IExecutor, SpecExecutor>();

var host = builder.Build();

ICommandFactory commandFactory = host.Services.GetRequiredService<ICommandFactory>();
ICommandDispatcher commandExecutor = host.Services.GetRequiredService<ICommandDispatcher>();

// Step 1 - Receive input with args.
// Handled by the framework.

// Step 2 - Use the CommandFactory to convert the input data into a Command model.
ICommand? command = commandFactory.Build(args);
if (command == null)
{
    return;
}

// Step 3 - Use the CommandExecutor to execute the Command.
bool result = commandExecutor.Dispatch(command);
if (result == true)
{
    return;
}
else
{
    return;
}

// TODO:
// - Seperate the workflow out into its own service?
// - Use extension method for DI registration.
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