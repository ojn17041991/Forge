using Forge.Abstractions.Data;
using Forge.Enums;
using Forge.Infrastructure.Constants;
using Forge.Responses;
using Forge.Results;

namespace Forge.Data
{
    public class DataStore : IDataStore
    {
        public async Task<ForgeResponse<string>> GetSpecification(string specificationId)
        {
            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                ForgeConstants.ForgeDirectory,
                ForgeConstants.SpecDirectory,
                specificationId + ForgeConstants.ForgeSpecExtension
            );

            if (File.Exists(filePath) == true)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.FileMissing);
            }

            string specificationContent = await File.ReadAllTextAsync(filePath);

            return ForgeResponseBuilder.Response(specificationContent, ForgeResponseCode.Success);
        }

        public async Task<ForgeResponse> SaveSpecification(string specificationId, string specificationContent)
        {
            string directory = Directory.GetCurrentDirectory();

            if (Directory.Exists(directory) == false)
            {
                return ForgeResponseBuilder.Response(ForgeResponseCode.Error);
            }

            directory = Path.Combine(directory, ForgeConstants.ForgeDirectory);

            if (Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            directory = Path.Combine(directory, ForgeConstants.SpecDirectory);

            if (Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            string filePath = Path.Combine(directory, specificationId + ForgeConstants.ForgeSpecExtension);

            if (File.Exists(filePath) == true)
            {
                return ForgeResponseBuilder.Response(ForgeResponseCode.FileExists);
            }

            await File.WriteAllTextAsync(specificationContent, filePath);

            return ForgeResponseBuilder.Response(ForgeResponseCode.Success);
        }
    }
}
