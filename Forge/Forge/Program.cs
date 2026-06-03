using Forge.Commands.Dependencies;
using Forge.Commands.Interfaces;
using Forge.Commands.Models;
using Forge.Executors.Interfaces;
using Forge.Handlers.Dependencies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<ICommandFactory, CommandFactory>();
builder.Services.AddSingleton<ICommandExecutor, CommandExecutor>();

builder.Services.AddTransient<ICommand, SpecCommand>();
builder.Services.AddTransient<ICommandBuilder, SpecCommandBuilder>();
builder.Services.AddTransient<IExecutor, SpecExecutor>();

var host = builder.Build();

ICommandFactory commandFactory = host.Services.GetRequiredService<ICommandFactory>();
ICommandExecutor commandExecutor = host.Services.GetRequiredService<ICommandExecutor>();

// Step 1 - Receive input with args.
// Handled by the framework.

// Step 2 - Use the CommandFactory to convert the input data into a Command model.
ICommand? command = commandFactory.Build(args);
if (command == null)
{
    return;
}

// Step 3 - Use the CommandExecutor to execute the Command.
bool result = commandExecutor.Execute(command);
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
// - Review project structure.
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