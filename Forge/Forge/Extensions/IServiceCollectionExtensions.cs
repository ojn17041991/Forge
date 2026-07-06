using Forge.Abstractions.Data;
using Forge.Abstractions.Infrastructure.Pipeline;
using Forge.Abstractions.OpenAi;
using Forge.Abstractions.Responses;
using Forge.Abstractions.Schemas;
using Forge.Abstractions.Verbs.Commands;
using Forge.Abstractions.Verbs.Executors;
using Forge.Abstractions.Verbs.Prompts;
using Forge.Commands.Spec;
using Forge.Data;
using Forge.Infrastructure.Pipeline;
using Forge.Infrastructure.Prompts;
using Forge.OpenAi;
using Forge.Responses;
using Forge.Schemas;
using Forge.Verbs.Gen;
using Forge.Verbs.Spec;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.AddSingleton<ICommandFactory, CommandFactory>();
            services.AddSingleton<IForgeResponseParser, ForgeResponseParser>();
            services.AddSingleton<IForgeRunner, ForgeRunner>();
            services.AddSingleton<IOpenAiService, OpenAiService>();
            services.AddSingleton<IPromptRenderer, PromptRenderer>();
            services.AddSingleton<IPromptRepository, PromptRepository>();
            services.AddSingleton<ISchemaSerializer, SchemaSerializer>();
            services.AddSingleton<ISpecificationStore, SpecificationStore>();

            services.AddTransient<ICommand, SpecCommand>();
            services.AddTransient<ICommandBuilder, SpecCommandBuilder>();
            services.AddTransient<IExecutor, SpecExecutor>();
            services.AddTransient<IPrompt, SpecPrompt>();

            services.AddTransient<ICommand, GenCommand>();
            services.AddTransient<ICommandBuilder, GenCommandBuilder>();
            services.AddTransient<IExecutor, GenExecutor>();
            services.AddTransient<IPrompt, GenPrompt>();
        }
    }
}
