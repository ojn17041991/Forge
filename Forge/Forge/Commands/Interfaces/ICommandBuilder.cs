namespace Forge.Commands.Interfaces
{
    public interface ICommandBuilder : ICommandService
    {
        ICommand Build(string[] args);
    }
}
