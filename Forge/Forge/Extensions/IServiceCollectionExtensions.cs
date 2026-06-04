using Forge.Abstractions.Pipeline;
using Forge.Abstractions.Services;
using Forge.Abstractions.Verbs.Commands;
using Forge.Abstractions.Verbs.Executors;
using Forge.Commands.Spec;
using Forge.Pipeline;
using Forge.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IForgeRunner, ForgeRunner>();
            services.AddSingleton<ICommandFactory, CommandFactory>();
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            
            services.AddTransient<ICommand, SpecCommand>();
            services.AddTransient<ICommandBuilder, SpecCommandBuilder>();
            services.AddTransient<IExecutor, SpecExecutor>();
        }
    }
}
