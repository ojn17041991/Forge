using global::Forge.Enums;
using global::Forge.Responses;
using System;
using Xunit;

namespace ForgeTest.Spec1._3_Gen1._0.ForgeResponseMessagesTests
{
    public class ForgeResponseMessagesTests
    {
        [Fact]
        public void ReturnsMessageForValidResponseCode()
        {
            // Arrange
            ForgeResponseCode responseCode = ForgeResponseCode.FileExists; // FORGE_TODO: ValidResponseCode

            // Act
            string result = ForgeResponseMessages.Get(responseCode);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void DistinctResponseCodesProduceDifferentMessages()
        {
            // Arrange
            ForgeResponseCode responseCode1 = ForgeResponseCode.ResponseUnparsable; // FORGE_TODO: DifferentValidResponseCode_1
            ForgeResponseCode responseCode2 = ForgeResponseCode.Incomplete; // FORGE_TODO: DifferentValidResponseCode_2

            // Act
            string result1 = ForgeResponseMessages.Get(responseCode1);
            string result2 = ForgeResponseMessages.Get(responseCode2);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotEqual(result1, result2);
        }

        [Fact]
        public void HandlesLowestEnumValue()
        {
            // Arrange
            ForgeResponseCode responseCode = ForgeResponseCode.ArgumentInvalid; // FORGE_TODO: LowestDefinedResponseCode

            // Act
            string result = ForgeResponseMessages.Get(responseCode);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void HandlesHighestEnumValue()
        {
            // Arrange
            ForgeResponseCode responseCode = ForgeResponseCode.VerbNotRecognized; // FORGE_TODO: HighestDefinedResponseCode

            // Act
            string result = ForgeResponseMessages.Get(responseCode);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
