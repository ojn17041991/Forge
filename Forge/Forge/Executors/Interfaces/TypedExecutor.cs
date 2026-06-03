using Forge.Commands.Enums;
using Forge.Commands.Interfaces;
using Forge.Handlers.Abstract;

namespace Forge.Executors.Interfaces
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
