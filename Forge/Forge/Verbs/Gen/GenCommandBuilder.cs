using Forge.Abstractions.Verbs.Commands;
using Forge.Enums;
using Forge.Extensions;
using Forge.Responses;
using Forge.Results;

namespace Forge.Verbs.Gen
{
    public class GenCommandBuilder : ICommandBuilder
    {
        public CommandVerb Verb => CommandVerb.Gen;

        public ForgeResponse<ICommand> Build(string[] args)
        {
            // OJN: Order completely ruins this. If you put specId after category, it wouldn't work at all.

            // Due to the optionality of the Category argument, there should always be 2 or 4 arguments in total.
            // 2 if Category is not provided. 4 if it is.
            if (args.Length != 2 && args.Length != 4)
            {
                return ForgeResponseBuilder.Response<ICommand>(ForgeResponseCode.ArgumentsMissing);
            }

            TestCategory? category = args.Length == 2 ? TestCategory.All : EnumExtensions.ToEnum<TestCategory>(args[3]);
            if (category == null)
            {
                return ForgeResponseBuilder.Response<ICommand>(ForgeResponseCode.ArgumentInvalid);
            }

            ICommand command = new GenCommand
            {
                SpecificationId = args[1],
                Category = category.Value
            };

            return ForgeResponseBuilder.Response(command, ForgeResponseCode.Success);
        }
    }
}
