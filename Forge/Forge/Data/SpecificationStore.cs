using Forge.Abstractions.Data;
using Forge.Enums;
using Forge.Infrastructure.Constants;
using Forge.Responses;
using Forge.Results;

namespace Forge.Data
{
    public class SpecificationStore : ISpecificationStore
    {
        public async Task<ForgeResponse<string>> Get(string id)
        {
            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                ForgeConstants.ForgeDirectory,
                ForgeConstants.SpecDirectory,
                id + ForgeConstants.ForgeSpecExtension
            );

            if (File.Exists(filePath) == true)
            {
                return ForgeResponseBuilder.Response<string>(ForgeResponseCode.FileMissing);
            }

            string specificationContent = await File.ReadAllTextAsync(filePath);

            return ForgeResponseBuilder.Response(specificationContent, ForgeResponseCode.Success);
        }

        public async Task<ForgeResponse> Save(string id, string content)
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

            string filePath = Path.Combine(directory, id + ForgeConstants.ForgeSpecExtension);

            if (File.Exists(filePath) == true)
            {
                return ForgeResponseBuilder.Response(ForgeResponseCode.FileExists);
            }

            await File.WriteAllTextAsync(filePath, content);

            return ForgeResponseBuilder.Response(ForgeResponseCode.Success);
        }
    }
}
