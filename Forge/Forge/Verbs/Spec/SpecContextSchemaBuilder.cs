using Forge.Commands.Spec;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;
using Forge.Schemas.Spec.Context;
using Forge.Verbs.Abstractions.Schema;

namespace Forge.Verbs.Spec
{
    public class SpecContextSchemaBuilder : ISchemaBuilder<SpecCommand, SpecContextSchema>
    {
        public CommandVerb Verb => CommandVerb.Spec;

        public ForgeResponse<SpecContextSchema> Build(SpecCommand command)
        {
            if (File.Exists(command.FilePath) == false)
            {
                return ForgeResponseBuilder.Response<SpecContextSchema>(ForgeResponseCode.FileMissing);
            }

            string fileContent = File.ReadAllText(command.FilePath);

            throw new NotImplementedException();
        }
    }
}
