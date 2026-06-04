using Forge.Abstractions.Pipeline;
using Forge.Extensions;
using Forge.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Build the host with required dependencies.
var builder = Host.CreateApplicationBuilder(args);
builder.Services.RegisterDependencies();
var host = builder.Build();

// Get the pipeline entry point and run Forge.
IForgeRunner forgeRunner = host.Services.GetRequiredService<IForgeRunner>();
ForgeResponse forgeRunResponse = forgeRunner.Run(args);

// Process the result (Build out later).
if (forgeRunResponse.Success == true)
{
    Console.WriteLine("Worked.");
}
else
{
    Console.WriteLine("Didn't work.");
}