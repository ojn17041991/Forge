using Forge.Constants;
using Forge.Data.Abstractions;
using Forge.Enums;
using Forge.Responses;
using Forge.Results;

namespace Forge.Data
{
    public class SpecificationRepository : ISpecificationRepository
    {
        public async Task<ForgeResponse<string>> Get(string id)
        {
            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                FileConstants.ForgeDirectory,
                FileConstants.SpecDirectory,
                id + FileConstants.ForgeSpecExtension
            );

            if (File.Exists(filePath) == false)
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

            directory = Path.Combine(directory, FileConstants.ForgeDirectory);

            if (Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            directory = Path.Combine(directory, FileConstants.SpecDirectory);

            if (Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            string filePath = Path.Combine(directory, id + FileConstants.ForgeSpecExtension);

            if (File.Exists(filePath) == true)
            {
                return ForgeResponseBuilder.Response(ForgeResponseCode.FileExists);
            }

            await File.WriteAllTextAsync(filePath, content);

            return ForgeResponseBuilder.Response(ForgeResponseCode.Success);
        }
    }
}
