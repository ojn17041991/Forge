using Forge.Results;

namespace Forge.Abstractions.Infrastructure.Pipeline
{
    public interface IForgeRunner
    {
        Task<ForgeResponse<string>> Run(string[] args);
    }
}
