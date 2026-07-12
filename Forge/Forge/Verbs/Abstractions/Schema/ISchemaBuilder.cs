using Forge.Results;
using Forge.Verbs.Abstractions.Verbs;

namespace Forge.Verbs.Abstractions.Schema
{
    public interface ISchemaBuilder<TCommand, TSchema> : IVerb
    {
        /// <summary>
        /// Builds a generic context schema instance using a generic command instance.
        /// </summary>
        /// <typeparam name="T">The generic command type.</typeparam>
        /// <param name="command">The command instance</param>
        /// <returns>A generic context schema instance.</returns>
        ForgeResponse<TSchema> Build(TCommand command);
    }
}
