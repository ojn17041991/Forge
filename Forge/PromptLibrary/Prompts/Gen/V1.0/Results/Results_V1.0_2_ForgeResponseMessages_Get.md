### Grade:

Fail.
Code not usable without reformatting.
Metadata missing in the input data, but the model provided a usable test class replacing unknownable references with wildcards for the developer to replace.
The model also flagged this state correctly in the response code.

### Given input:

{
  "ResponseCode": "Success",
  "Data": {
    "SchemaVersion": "1",
    "TestCases": [
      {
        "Name": "Get_ReturnsMessage_ForDefinedResponseCode",
        "Description": "Returns a human-readable console message when called with a valid ForgeResponseCode value.",
        "Category": "Essential",
        "Inputs": [
          {
            "Name": "responseCode",
            "Value": "ForgeResponseCode (any valid enum member)"
          }
        ],
        "ExpectedResult": "A non-null, non-empty string containing a human-readable console message."
      },
      {
        "Name": "Get_ReturnsDistinctMessages_ForDifferentResponseCodes",
        "Description": "Returns different console messages when called with different distinct ForgeResponseCode values.",
        "Category": "Valuable",
        "Inputs": [
          {
            "Name": "responseCode",
            "Value": "ForgeResponseCode (distinct valid enum member from first test)"
          }
        ],
        "ExpectedResult": "A human-readable console message string that is distinct from messages returned for other response code values."
      },
      {
        "Name": "Get_ConsistentlyReturnsSameMessage_ForSameResponseCode",
        "Description": "Returns the same human-readable console message when called multiple times with the same ForgeResponseCode value.",
        "Category": "Optional",
        "Inputs": [
          {
            "Name": "responseCode",
            "Value": "ForgeResponseCode (specific valid enum member)"
          }
        ],
        "ExpectedResult": "The exact same human-readable console message string returned on every call."
      }
    ],
    "Metadata": {
      "Confidence": 90,
      "Reason": "Test cases cover the interaction of different possible enum values with output messages as implied by the method signature and documentation. No internal implementation details or error handling are specified, limiting coverage depth."
    }
  }
}

### Produced output:

{"SchemaVersion":"1","Code":"using Xunit;\n\nnamespace Forge.Tests\n{\n    // FORGE_TODO: Replace \u0027ForgeResponseCode\u0027 with the actual enum type from the production code\n    // FORGE_TODO: Replace \u0027ResponseMessageProvider\u0027 with the actual class containing the method under test\n\n    public class ResponseMessageProviderTests\n    {\n        private readonly ResponseMessageProvider _provider = new ResponseMessageProvider();\n\n        [Fact]\n        public void Get_ReturnsMessage_ForDefinedResponseCode()\n        {\n            // Arrange\n            // FORGE_TODO: Select an actual valid enum member for testing\n            ForgeResponseCode responseCode = FORGE_TODO_SelectValidResponseCode();\n\n            // Act\n            string message = _provider.Get(responseCode);\n\n            // Assert\n            Assert.False(string.IsNullOrEmpty(message));\n        }\n\n        [Fact]\n        public void Get_ReturnsDistinctMessages_ForDifferentResponseCodes()\n        {\n            // Arrange\n            // FORGE_TODO: Select two distinct valid enum members different from each other\n            ForgeResponseCode firstCode = FORGE_TODO_SelectDistinctValidResponseCode1();\n            ForgeResponseCode secondCode = FORGE_TODO_SelectDistinctValidResponseCode2();\n\n            // Act\n            string firstMessage = _provider.Get(firstCode);\n            string secondMessage = _provider.Get(secondCode);\n\n            // Assert\n            Assert.False(string.IsNullOrEmpty(firstMessage));\n            Assert.False(string.IsNullOrEmpty(secondMessage));\n            Assert.NotEqual(firstMessage, secondMessage);\n        }\n\n        [Fact]\n        public void Get_ConsistentlyReturnsSameMessage_ForSameResponseCode()\n        {\n            // Arrange\n            // FORGE_TODO: Select a specific valid enum member for this test\n            ForgeResponseCode responseCode = FORGE_TODO_SelectValidResponseCodeForConsistencyTest();\n\n            // Act\n            string firstCallMessage = _provider.Get(responseCode);\n            string secondCallMessage = _provider.Get(responseCode);\n            string thirdCallMessage = _provider.Get(responseCode);\n\n            // Assert\n            Assert.False(string.IsNullOrEmpty(firstCallMessage));\n            Assert.Equal(firstCallMessage, secondCallMessage);\n            Assert.Equal(secondCallMessage, thirdCallMessage);\n        }\n    }\n}\n"}