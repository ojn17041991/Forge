using Forge.Enums;
using Forge.Responses;
using Xunit;

namespace ForgeTest.Spec0_6_Gen0_2.Responses.ForgeResponseMessageTests
{
    public class ForgeResponseCodeTests
    {
        // FORGE_TODO: Replace "ForgeResponseCodeHelper" and "GetMessage" with actual class and method names.

        [Fact]
        public void Get_ReturnsMessage_ForKnownForgeResponseCode()
        {
            // Arrange
            var responseCode = ForgeResponseCode.Success; // FORGE_TODO: Ensure ForgeResponseCode enum is accessible

            // Act
            var message = ForgeResponseMessages.Get(responseCode);

            // Assert
            Assert.False(string.IsNullOrEmpty(message));
            // Optionally, assert exact expected message if known, e.g. Assert.Equal("Success", message);
        }

        [Fact]
        public void Get_ReturnsMessage_ForDifferentForgeResponseCode()
        {
            // Arrange
            var responseCode = ForgeResponseCode.Error; // FORGE_TODO: Ensure ForgeResponseCode enum has Error value

            // Act
            var message = ForgeResponseMessages.Get(responseCode);

            // Assert
            Assert.False(string.IsNullOrEmpty(message));
            // Optionally, assert that message differs from Success message or matches expected
        }

        [Fact]
        public void Get_ReturnsMessage_ForUndefinedForgeResponseCodeValue()
        {
            // Arrange
            var responseCode = (ForgeResponseCode)999; // Undefined / out-of-range value

            // Act
            var message = ForgeResponseMessages.Get(responseCode);

            // Assert
            Assert.NotNull(message);
            // Message may be empty or default fallback, no assumption here
        }
    }
}