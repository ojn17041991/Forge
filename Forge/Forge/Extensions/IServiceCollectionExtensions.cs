using Forge.Commands;
using Forge.Commands.Abstractions;
using Forge.Commands.Spec;
using Forge.Data;
using Forge.Data.Abstractions;
using Forge.OpenAi;
using Forge.OpenAi.Abstractions;
using Forge.Pipeline;
using Forge.Pipeline.Abstractions;
using Forge.Prompts;
using Forge.Prompts.Abstractions;
using Forge.Responses;
using Forge.Responses.Abstractions;
using Forge.Schemas;
using Forge.Schemas.Abstractions;
using Forge.Schemas.Spec.Context;
using Forge.Verbs.Abstractions.Commands;
using Forge.Verbs.Abstractions.Executors;
using Forge.Verbs.Abstractions.Prompts;
using Forge.Verbs.Abstractions.Schema;
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
            services.AddSingleton<ISchemaTemplateBuilder, SchemaTemplateBuilder>();
            services.AddSingleton<ISpecificationRepository, SpecificationRepository>();

            services.AddTransient<ICommand, SpecCommand>();
            services.AddTransient<ICommandBuilder, SpecCommandBuilder>();
            services.AddTransient<ISchemaBuilder<SpecCommand, SpecContextSchema>, SpecContextSchemaBuilder>();
            services.AddTransient<IExecutor, SpecExecutor>();
            services.AddTransient<IPrompt, SpecPrompt>();

            services.AddTransient<ICommand, GenCommand>();
            services.AddTransient<ICommandBuilder, GenCommandBuilder>();
            services.AddTransient<IExecutor, GenExecutor>();
            services.AddTransient<IPrompt, GenPrompt>();
        }
    }
}
