using Forge.Results;

namespace Forge.Data.Abstractions
{
    public interface ISpecificationRepository
    {
        Task<ForgeResponse<string>> Get(string id);

        Task<ForgeResponse> Save(string id, string content);
    }
}
