using Forge.Abstractions.Verbs.Commands;

namespace Forge.Abstractions.Services
{
    public interface ICommandFactory
    {
        ICommand? Build(string[] args);
    }
}
