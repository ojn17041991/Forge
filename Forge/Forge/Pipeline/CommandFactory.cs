using Forge.Abstractions.Services;
using Forge.Abstractions.Verbs.Commands;
using Forge.Enums;
using Forge.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Forge.Services
{
    public class CommandFactory(IServiceProvider serviceProvider) : ICommandFactory
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public ICommand? Build(string[] args)
        {
            if (args.Length < 1)
            {
                return null;
            }

            var verb = args[0].ToEnum<CommandVerb>();
            if (verb == null)
            {
                return null;
            }

            var commandBuilders = serviceProvider.GetServices<ICommandBuilder>();
            if (commandBuilders == null || commandBuilders.Count() == 0)
            {
                return null;
            }

            var commandBuilder = commandBuilders.SingleOrDefault(x => x.Verb == verb);
            if (commandBuilder == null)
            {
                return null;
            }

            var command = commandBuilder.Build(args);
            if (command == null)
            {
                return null;
            }

            return command;
        }
    }
}
