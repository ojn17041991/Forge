using Forge.Abstractions.Verbs.Commands;
using Forge.Enums;

namespace Forge.Abstractions.Verbs.Executors
{
    public abstract class TypedExecutor<T> : ITypedExecutor<T> where T : ICommand
    {
        public abstract CommandVerb Verb { get; }

        public abstract bool Execute(T command);

        public bool Execute(ICommand command)
        {
            return Execute((T)command);
        }
    }
}
