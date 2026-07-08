using Forge.Enums;
using Forge.Responses;
using Xunit;

namespace ForgeTest.Spec0_5_Gen0_2.Responses.ForgeResponseMessageTests
{
    // FORGE_TODO: Replace 'ForgeResponseCode' with the actual Enum or type representing response codes.
    // FORGE_TODO: Replace 'YourNamespace' with the actual namespace containing the class under test.
    using Forge.Responses;

    public class ForgeResponseCodeMessageProviderTests
    {
        [Fact]
        public void Get_ShouldReturnNonNullString_ForValidResponseCode()
        {
            // Arrange
            // FORGE_TODO: Provide an actual valid ForgeResponseCode value here for the test
            ForgeResponseCode responseCode = ForgeResponseCode.ArgumentInvalid; // FORGE_TODO: Assign a valid enum value
            //var messageProvider = ForgeResponseMessages; // FORGE_TODO: Replace with actual class name if different

            // Act
            string result = ForgeResponseMessages.Get(responseCode);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}