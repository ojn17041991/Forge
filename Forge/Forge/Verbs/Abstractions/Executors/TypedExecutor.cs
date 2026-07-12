using Forge.Enums;
using Forge.Results;
using Forge.Verbs.Abstractions.Commands;

namespace Forge.Verbs.Abstractions.Executors
{
    public abstract class TypedExecutor<T> : ITypedExecutor<T> where T : ICommand
    {
        public abstract CommandVerb Verb { get; }

        public abstract Task<ForgeResponse<string>> Execute(T command);

        public Task<ForgeResponse<string>> Execute(ICommand command)
        {
            return Execute((T)command);
        }
    }
}
