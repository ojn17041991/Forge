using Forge.Commands.Enums;

namespace Forge.Commands.Interfaces
{
    public interface ICommand
    {
        CommandVerb Verb { get; }
    }
}
