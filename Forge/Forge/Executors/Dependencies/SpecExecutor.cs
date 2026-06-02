using Forge.Commands.Models;
using Forge.Handlers.Abstract;

namespace Forge.Handlers.Dependencies
{
    public class SpecExecutor : IExecutor<SpecCommand>
    {
        public bool Execute(SpecCommand command)
        {
            return true;
        }
    }
}
