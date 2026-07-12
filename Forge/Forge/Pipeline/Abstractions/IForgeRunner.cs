using Forge.Results;

namespace Forge.Pipeline.Abstractions
{
    public interface IForgeRunner
    {
        Task<ForgeResponse<string>> Run(string[] args);
    }
}
