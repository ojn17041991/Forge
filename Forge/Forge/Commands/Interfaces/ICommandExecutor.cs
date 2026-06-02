namespace Forge.Commands.Interfaces
{
    public interface ICommandExecutor
    {
        bool Execute<T>(T command) where T : ICommand;
    }
}
