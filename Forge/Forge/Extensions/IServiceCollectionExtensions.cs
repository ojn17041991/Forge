using Forge.Abstractions.Pipeline;
using Forge.Abstractions.Services;
using Forge.Abstractions.Verbs.Commands;
using Forge.Abstractions.Verbs.Executors;
using Forge.Abstractions.Verbs.Prompts;
using Forge.Commands.Spec;
using Forge.Infrastructure.Pipeline;
using Forge.Infrastructure.Prompts;
using Forge.Verbs.Spec;
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
            services.AddSingleton<IPromptReader, PromptReader>();
            
            services.AddTransient<ICommand, SpecCommand>();
            services.AddTransient<ICommandBuilder, SpecCommandBuilder>();
            services.AddTransient<IExecutor, SpecExecutor>();
            services.AddTransient<IPrompt, SpecPrompt>();
        }
    }
}
