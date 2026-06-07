using Forge.Abstractions.Infrastructure.Pipeline;
using Forge.Abstractions.Verbs.Commands;
using Forge.Responses;
using Forge.Results;

namespace Forge.Infrastructure.Pipeline
{
    public class ForgeRunner(
        ICommandFactory commandFactory,
        ICommandDispatcher commandDispatcher
    ) : IForgeRunner
    {
        private readonly ICommandFactory commandFactory = commandFactory;
        private readonly ICommandDispatcher commandDispatcher = commandDispatcher;

        public async Task<ForgeResponse<string>> Run(string[] args)
        {
            // Step 1 - Receive input with args.
            // Handled by the framework.

            // Step 2 - Get a command from the factory.
            ForgeResponse<ICommand> commandBuildResponse = commandFactory.Build(args);
            if (commandBuildResponse.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(commandBuildResponse.ResponseCode);
            }

            // Step 3 - Dispatch the command.
            ICommand command = commandBuildResponse.Data!;
            ForgeResponse<string> commandDispatchResponse = await commandDispatcher.Dispatch(command);
            if (commandDispatchResponse.Success == false)
            {
                return ForgeResponseBuilder.Response<string>(commandDispatchResponse.ResponseCode);
            }

            // Step 4 - Return the result for output processing.
            return commandDispatchResponse;
        }
    }
}
