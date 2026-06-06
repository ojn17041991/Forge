using Forge.Results;

namespace Forge.Abstractions.Pipeline
{
    public interface IForgeRunner
    {
        Task<ForgeResponse> Run(string[] args);
    }
}
