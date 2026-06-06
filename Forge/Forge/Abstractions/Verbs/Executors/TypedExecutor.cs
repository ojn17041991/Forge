using Forge.Abstractions.Verbs.Commands;
using Forge.Enums;
using Forge.Results;

namespace Forge.Abstractions.Verbs.Executors
{
    public abstract class TypedExecutor<T> : ITypedExecutor<T> where T : ICommand
    {
        public abstract CommandVerb Verb { get; }

        public abstract ForgeResponse<string> Execute(T command);

        public ForgeResponse<string> Execute(ICommand command)
        {
            return Execute((T)command);
        }
    }
}
