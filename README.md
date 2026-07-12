### Forge

Forge is a unit test generation engine that uses OpenAI to produce behavioural test cases and executable unit test code. It is intentionally blind to function implementation, instead relying solely on function contract to ensure high-quality, resilient test cases that validate behaviour instead of implementation details.

### Forge CLI

Forge CLI is the command line interface for the Forge engine.

### Quick Start

Generate a specification:

`forge spec -filepath "path/to/my/file/TestClass.cs" -functionname "TestFunction"`

Receive a specification ID:

`f31a89477b2d4fb2b80567420bc41998`

Generate unit tests from specification:

`forge gen -specId "f31a89477b2d4fb2b80567420bc41998"`

Receive executable unit test code:

```
namespace ForgeTest
{
    public class TestFunction
    {
        [Fact]
        public void TestFunction_Should_Return_True()
        {
            // Arrange
            bool expected = true;

            // Act
            bool actual = TestClass.TestFunction();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
```

### Process Flow

Forge follows a simple command pipeline:

1. User enters a command into the Forge CLI.

2. Forge CLI invokes the Forge Runner.

3. Forge Runner performs the following actions:
   
   - Receives the raw CLI input.
   
   - Builds a strongly-typed command model using the CLI arguments.
   
   - Dispatches the command to its corresponding executor. See the **Execution Process** sections below for a detailed breakdown of each command.
   
   - Receives the execution result.

4. Forge Runner returns the execution result to the Forge CLI.

5. Forge CLI processes the result for display back to the user.

See the <u>Overview</u> section of the attached [Figma](https://embed.figma.com/design/CMQ3KnXCvxL5igU6W00QZv/Forge?node-id=0-1&embed-host=share) for diagram.

### Commands

##### Spec

###### Execution Process

The `spec` command produces a unit test specification for an input function.

It does this by executing the following pipeline:

1. Receives a strongly-typed command model from the Forge Runner.

2. Builds the prompt:
   
   - Reads the raw prompt.
   
   - Produces a context schema by using Roslyn to analyse the function metadata.
   
   - Produces a result schema template for the OpenAI model.
   
   - Inserts the schemas into the raw prompt as wildcards.

3. Sends the prompt to the OpenAI model.

4. Validates the structure and content of the OpenAI response.

5. Produces a new specification:
   
   - Generates a new specification ID.
   
   - Serializes the OpenAI response.
   
   - Stores the Specification ID and response as a `.forgespec` file.

6. Returns the Specification ID.

See the <u>Spec Execution</u> section of the attached [Figma](https://embed.figma.com/design/CMQ3KnXCvxL5igU6W00QZv/Forge?node-id=0-1&embed-host=share) for diagram.

###### Usage

To invoke the `spec` command use the following syntax:

`forge spec -filePath <filePath> -functionName <functionName>`

- `<filePath>` is the path to the `.cs` file containing the input function.

- `<functionName>` is the name of the input function.

This produces an output with the following syntax:

`<specId>`

* `<specId>` is the ID of the new specification.

##### Gen

###### Execution Process

The `gen` command produces executable unit test code for a specification.

It does this by executing the following pipeline:

1. Receives a strongly-typed command model from the Forge Runner.

2. Builds the prompt:
   
   - Reads the raw prompt.
   
   - Produces a context schema by reading the requested Specification.
   
   - Produces a result schema for the OpenAI model.
   
   - Inserts the schemas into the raw prompt as wildcards.

3. Sends the prompt to the OpenAI model.

4. Validates the structure and content of the OpenAI response.

5. Returns the generated unit test code.

See the <u>Gen Execution</u> section of the attached [Figma](https://embed.figma.com/design/CMQ3KnXCvxL5igU6W00QZv/Forge?node-id=0-1&embed-host=share) for diagram.

###### Usage

To invoke the `gen` command use the following syntax:

`forge gen -specId <specId>`

- `<specId>` is the ID produced by the `spec` command.

This produces an output with the following syntax:

`<code>`

* `<code>` is the executable unit test code.