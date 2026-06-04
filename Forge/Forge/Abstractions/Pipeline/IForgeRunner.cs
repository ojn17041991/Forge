using Forge.Results;

namespace Forge.Abstractions.Pipeline
{
    public interface IForgeRunner
    {
        ForgeResponse Run(string[] args);
    }
}
