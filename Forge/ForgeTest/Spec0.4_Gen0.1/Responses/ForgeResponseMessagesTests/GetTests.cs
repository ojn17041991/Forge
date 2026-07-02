using Forge.Enums;
using Forge.Responses;
using Xunit;

namespace Forge.Tests
{
    // FORGE_TODO: Replace 'ForgeResponseCode' with the actual enum type from the production code.
    // FORGE_TODO: Replace 'ResponseMessageProvider' with the actual class containing the method under test.

    public class ResponseMessageProviderTests
    {
        [Fact]
        public void Get_ReturnsMessage_ForDefinedResponseCode()
        {
            // Arrange
            // FORGE_TODO: Select an actual valid enum member for testing.
            ForgeResponseCode responseCode = ForgeResponseCode.FileMissing;

            // Act
            string message = ForgeResponseMessages.Get(responseCode);

            // Assert
            Assert.False(string.IsNullOrEmpty(message));
        }

        [Fact]
        public void Get_ReturnsDistinctMessages_ForDifferentResponseCodes()
        {
            // Arrange
            // FORGE_TODO: Select two distinct valid enum members different from each other.
            ForgeResponseCode firstCode = ForgeResponseCode.FileMissing;
            ForgeResponseCode secondCode = ForgeResponseCode.VerbMissing;

            // Act
            string firstMessage = ForgeResponseMessages.Get(firstCode);
            string secondMessage = ForgeResponseMessages.Get(secondCode);

            // Assert
            Assert.False(string.IsNullOrEmpty(firstMessage));
            Assert.False(string.IsNullOrEmpty(secondMessage));
            Assert.NotEqual(firstMessage, secondMessage);
        }

        [Fact]
        public void Get_ConsistentlyReturnsSameMessage_ForSameResponseCode()
        {
            // Arrange
            // FORGE_TODO: Select a specific valid enum member for this test.
            ForgeResponseCode responseCode = ForgeResponseCode.ArgumentInvalid;

            // Act
            string firstCallMessage = ForgeResponseMessages.Get(responseCode);
            string secondCallMessage = ForgeResponseMessages.Get(responseCode);
            string thirdCallMessage = ForgeResponseMessages.Get(responseCode);

            // Assert
            Assert.False(string.IsNullOrEmpty(firstCallMessage));
            Assert.Equal(firstCallMessage, secondCallMessage);
            Assert.Equal(secondCallMessage, thirdCallMessage);
        }
    }
}