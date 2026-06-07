using Forge.Results;

namespace Forge.Abstractions.Data
{
    public interface ISpecificationStore
    {
        Task<ForgeResponse<string>> Get(string id);

        Task<ForgeResponse> Save(string id, string content);
    }
}
