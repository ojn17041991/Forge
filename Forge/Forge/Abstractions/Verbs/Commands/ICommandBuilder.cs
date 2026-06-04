namespace Forge.Abstractions.Verbs.Commands
{
    public interface ICommandBuilder : ICommandService
    {
        ICommand Build(string[] args);
    }
}
