using Forge.Abstractions.Pipeline;
using Forge.Abstractions.Services;
using Forge.Abstractions.Verbs.Commands;
using Forge.Responses;
using Forge.Results;

namespace Forge.Pipeline
{
    public class ForgeRunner(
        ICommandFactory commandFactory,
        ICommandDispatcher commandDispatcher
    ) : IForgeRunner
    {
        private readonly ICommandFactory commandFactory = commandFactory;
        private readonly ICommandDispatcher commandDispatcher = commandDispatcher;

        public ForgeResponse Run(string[] args)
        {
            // Step 1 - Receive input with args.
            // Handled by the framework.

            // Step 2 - Get a command from the factory.
            ForgeResponse<ICommand> commandBuildResponse = commandFactory.Build(args);
            if (commandBuildResponse.Success == false)
            {
                return ForgeResponseBuilder.Response(commandBuildResponse.ResponseCode);
            }

            // Step 3 - Dispatch the command.
            ICommand command = commandBuildResponse.Data!; // OJN: Not safe.
            ForgeResponse commandDispatchResponse = commandDispatcher.Dispatch(command);
            if (commandDispatchResponse.Success == false)
            {
                return ForgeResponseBuilder.Response(commandBuildResponse.ResponseCode);
            }

            // Step 4 - Return the result for output processing.
            return commandDispatchResponse;
        }
    }
}
