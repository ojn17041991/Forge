using Forge.Enums;

namespace Forge.Abstractions.Verbs.Commands
{
    public interface ICommandService
    {
        CommandVerb Verb { get; }
    }
}
