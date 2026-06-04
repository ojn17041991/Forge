using Forge.Abstractions.Pipeline;
using Forge.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Build the host with required dependencies.
var builder = Host.CreateApplicationBuilder(args);
builder.Services.RegisterDependencies();
var host = builder.Build();

// Get the pipeline entry point and run Forge.
IForgeRunner forgeRunner = host.Services.GetRequiredService<IForgeRunner>();
bool result = forgeRunner.Run(args);

// Process the result (Build out later).
if (result == true)
{
    Console.WriteLine("Worked.");
}
else
{
    Console.WriteLine("Didn't work.");
}