namespace Forge.Commands.Interfaces
{
    public interface ICommandFactory
    {
        ICommand Build(string[] args);
    }
}
