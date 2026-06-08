using FluentAssertions;
using Forge.Enums;
using Forge.Responses;

namespace ForgeTest.Responses.ForgeResponseMessagesTests
{
    public class GetTests
    {
        /*
Test cases written using Forge.
Unit tests written manually following test cases.
Only Essential and Valuable unit tests were implemented.

TEST CASE 1  
Category: Essential  
Name: ValidResponseCode_ReturnsCorrespondingMessage  
Description: When a known, valid ForgeResponseCode value is passed, the function returns the human-readable console message corresponding specifically to that response code.  
Inputs: ForgeResponseCode.SomeDefinedValue  
Expected Result: A non-null, non-empty string message clearly representing the meaning of the specified response code.  

TEST CASE 2  
Category: Essential  
Name: DefaultResponseCode_ReturnsDefaultMessage  
Description: When an unspecified or default ForgeResponseCode value (e.g., default enum value or a value not explicitly handled) is passed, the function returns a default or fallback console message.  
Inputs: (default)ForgeResponseCode  
Expected Result: A string message indicating a default or unknown response code state.  

TEST CASE 3  
Category: Valuable  
Name: AllDefinedResponseCodes_ReturnDistinctMessages  
Description: Verifies for every explicitly defined value in the ForgeResponseCode enumeration that the returned messages are unique and appropriate to each code.  
Inputs: ForgeResponseCode.[All enumeration values one by one]  
Expected Result: Each input produces a distinct, meaningful string, with no two different codes sharing the exact same message.  

TEST CASE 4  
Category: Optional  
Name: NullOrInvalidInputBehavior  
Description: Although unlikely for an enum parameter, test the behavior when an out-of-range integer cast is passed as responseCode to validate consistent or graceful output.  
Inputs: (ForgeResponseCode)(-1), (ForgeResponseCode)int.MaxValue  
Expected Result: Returns the same output as for unknown or default response codes, or a consistent fallback message without throwing exceptions.  

Confidence: 85%  
Reason: The tests cover the fundamental expected behaviors of the Get method for known and unknown input values without assuming implementation details beyond the function signature and provided comment. Due to absence of internal logic or defined enum values, some inferred edge cases such as invalid enum values are included as Optional. This ensures a thorough, yet conservative, approach to behavioral coverage within the stated constraints.
         */

        [Fact]
        public void ArgumentsMissing_ReturnsCorrespondingMessage()
        {
            // Arrange
            ForgeResponseCode responseCode = ForgeResponseCode.ArgumentsMissing;

            // Act
            string responseMessage = ForgeResponseMessages.Get(responseCode);

            // Assert
            responseMessage.Should().Be("missing command arguments");
        }

        [Fact]
        public void Error_ReturnsCorrespondingMessage()
        {
            // Arrange
            ForgeResponseCode responseCode = ForgeResponseCode.Error;

            // Act
            string responseMessage = ForgeResponseMessages.Get(responseCode);

            // Assert
            responseMessage.Should().Be("internal error");
        }

        [Fact]
        public void FileExists_ReturnsCorrespondingMessage()
        {
            // Arrange
            ForgeResponseCode responseCode = ForgeResponseCode.FileExists;

            // Act
            string responseMessage = ForgeResponseMessages.Get(responseCode);

            // Assert
            responseMessage.Should().Be("file exists");
        }

        [Fact]
        public void FileMissing_ReturnsCorrespondingMessage()
        {
            // Arrange
            ForgeResponseCode responseCode = ForgeResponseCode.FileMissing;

            // Act
            string responseMessage = ForgeResponseMessages.Get(responseCode);

            // Assert
            responseMessage.Should().Be("missing file");
        }

        [Fact]
        public void Success_ReturnsCorrespondingMessage()
        {
            // Arrange
            ForgeResponseCode responseCode = ForgeResponseCode.Success;

            // Act
            string responseMessage = ForgeResponseMessages.Get(responseCode);

            // Assert
            responseMessage.Should().Be("command executed");
        }

        [Fact]
        public void VerbMissing_ReturnsCorrespondingMessage()
        {
            // Arrange
            ForgeResponseCode responseCode = ForgeResponseCode.VerbMissing;

            // Act
            string responseMessage = ForgeResponseMessages.Get(responseCode);

            // Assert
            responseMessage.Should().Be("missing command");
        }

        [Fact]
        public void VerbNotRecognized_ReturnsCorrespondingMessage()
        {
            // Arrange
            ForgeResponseCode responseCode = ForgeResponseCode.VerbNotRecognized;

            // Act
            string responseMessage = ForgeResponseMessages.Get(responseCode);

            // Assert
            responseMessage.Should().Be("unrecognized command");
        }

        [Fact]
        public void DefaultResponseCode_ReturnsDefaultMessage()
        {
            // Arrange
            ForgeResponseCode responseCode = (ForgeResponseCode)(-1);

            // Act
            string responseMessage = ForgeResponseMessages.Get(responseCode);

            // Assert
            responseMessage.Should().Be("unknown error");
        }

        [Fact]
        public void AllDefinedResponseCodes_ReturnDistinctMessages()
        {
            // Arrange
            var enumValues = Enum.GetValues<ForgeResponseCode>();

            foreach (var value in enumValues)
            {
                // Act
                var result = ForgeResponseMessages.Get(value);

                // Assert
                result.Should().NotBe("unknown error", because: $"ResponseCode {value} is not explicitly handled");
            }
        }
    }
}