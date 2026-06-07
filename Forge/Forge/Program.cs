using Forge.Abstractions.Infrastructure.Pipeline;
using Forge.Extensions;
using Forge.Responses;
using Forge.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Build the host with required dependencies.
var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.AddUserSecrets<Program>(optional: true);
builder.Services.RegisterDependencies();
var host = builder.Build();

// Get the pipeline entry point and run Forge.
IForgeRunner forgeRunner = host.Services.GetRequiredService<IForgeRunner>();
ForgeResponse<string> forgeRunResponse = await forgeRunner.Run(args);

// Print the result to console.
if (forgeRunResponse.Success == false)
{
    Console.Write(ForgeResponseMessages.Get(forgeRunResponse.ResponseCode));
}
else
{
    Console.Write(forgeRunResponse.Data!);
}