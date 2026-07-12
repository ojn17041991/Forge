using Forge.Commands.Abstractions;
using Forge.Pipeline.Abstractions;
using Forge.Responses;
using Forge.Results;
using Forge.Verbs.Abstractions.Commands;

namespace Forge.Pipeline
{
    public class ForgeRunner(
        ICommandFactory commandFactory,
        ICommandDispatcher commandDispatcher
    ) : IForgeRunner
    {
        public async Task<ForgeResponse<string>> Run(string[] args)
        {
            // Step 1 - Receive input with args.
            // Handled by the framework.

            // Step 2 - Get a command from the factory.
            ForgeResponse<ICommand> commandBuildResponse = commandFactory.Build(args);
            if (commandBuildResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(commandBuildResponse.ResponseCode);
            }

            // Step 3 - Dispatch the command.
            ICommand command = commandBuildResponse.Data!;
            ForgeResponse<string> commandDispatchResponse = await commandDispatcher.Dispatch(command);
            if (commandDispatchResponse.IsSuccess == false)
            {
                return ForgeResponseBuilder.Response<string>(commandDispatchResponse.ResponseCode);
            }

            // Step 4 - Return the result for output processing.
            return commandDispatchResponse;
        }
    }
}
