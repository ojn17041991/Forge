using Forge.Results;

namespace Forge.Abstractions.Data
{
    public interface IDataStore
    {
        Task<ForgeResponse<string>> GetSpecification(string specificationId);

        Task<ForgeResponse> SaveSpecification(string specificationId, string specificationContent);
    }
}
