### Grade:

Fail.
Code not usable without reformatting.

### Given input:

{
  "SchemaVersion": "0.1",
  "TestCases": [
    {
      "Name": "Add_TwoPositiveNumbers_ReturnsCorrectSum",
      "Description": "Tests that adding two positive numbers returns their correct sum.",
      "Category": "Essential",
      "Inputs": [
        {
          "Name": "x",
          "Value": 5.0
        },
        {
          "Name": "y",
          "Value": 3.0
        }
      ],
      "ExpectedResult": "8.0"
    },
    {
      "Name": "Add_PositiveAndNegativeNumber_ReturnsCorrectSum",
      "Description": "Tests that adding a positive number and a negative number returns their correct sum.",
      "Category": "Essential",
      "Inputs": [
        {
          "Name": "x",
          "Value": 7.0
        },
        {
          "Name": "y",
          "Value": -2.0
        }
      ],
      "ExpectedResult": "5.0"
    },
    {
      "Name": "Add_TwoNegativeNumbers_ReturnsCorrectSum",
      "Description": "Tests that adding two negative numbers returns their correct sum.",
      "Category": "Essential",
      "Inputs": [
        {
          "Name": "x",
          "Value": -4.0
        },
        {
          "Name": "y",
          "Value": -6.0
        }
      ],
      "ExpectedResult": "-10.0"
    },
    {
      "Name": "Add_NumberAndZero_ReturnsSameNumber",
      "Description": "Tests that adding zero to a number returns the original number.",
      "Category": "Valuable",
      "Inputs": [
        {
          "Name": "x",
          "Value": 9.0
        },
        {
          "Name": "y",
          "Value": 0.0
        }
      ],
      "ExpectedResult": "9.0"
    },
    {
      "Name": "Add_ZeroAndNumber_ReturnsSameNumber",
      "Description": "Tests that adding a number to zero returns the original number.",
      "Category": "Valuable",
      "Inputs": [
        {
          "Name": "x",
          "Value": 0.0
        },
        {
          "Name": "y",
          "Value": 11.0
        }
      ],
      "ExpectedResult": "11.0"
    },
    {
      "Name": "Add_DecimalNumbers_ReturnsCorrectSum",
      "Description": "Tests that adding two fractional numbers returns the correct sum including decimals.",
      "Category": "Valuable",
      "Inputs": [
        {
          "Name": "x",
          "Value": 2.5
        },
        {
          "Name": "y",
          "Value": 3.75
        }
      ],
      "ExpectedResult": "6.25"
    },
    {
      "Name": "Add_LargeNumbers_ReturnsCorrectSum",
      "Description": "Tests that adding two large numbers returns the correct sum without overflow.",
      "Category": "Optional",
      "Inputs": [
        {
          "Name": "x",
          "Value": 1.0E+308
        },
        {
          "Name": "y",
          "Value": 1.0E+308
        }
      ],
      "ExpectedResult": "Infinity"
    },
    {
      "Name": "Add_SmallNumbers_ReturnsCorrectSum",
      "Description": "Tests that adding two very small numbers returns the correct sum without underflow.",
      "Category": "Optional",
      "Inputs": [
        {
          "Name": "x",
          "Value": 1.0E-308
        },
        {
          "Name": "y",
          "Value": 2.0E-308
        }
      ],
      "ExpectedResult": "3.0E-308"
    },
    {
      "Name": "Add_PlusInfinityAndNegativeInfinity_ReturnsNaN",
      "Description": "Tests that adding positive infinity and negative infinity returns NaN.",
      "Category": "Optional",
      "Inputs": [
        {
          "Name": "x",
          "Value": "Infinity"
        },
        {
          "Name": "y",
          "Value": "-Infinity"
        }
      ],
      "ExpectedResult": "NaN"
    }
  ],
  "Metadata": {
    "Confidence": 95,
    "Reason": "Test cases cover positive, negative, zero, fractional, large and small values plus special floating-point cases without inferring extra logic."
  }
}

### Produced output:

using System;\nusing Xunit;\n\nnamespace MyApp.Tests\n{\n public class CalculatorTests\n {\n private readonly Calculator _calculator = new Calculator();\n\n [Fact]\n public void Add_TwoPositiveNumbers_ReturnsCorrectSum()\n {\n // Arrange\n double x = 5.0;\n double y = 3.0;\n\n // Act\n double result = _calculator.Add(x, y);\n\n // Assert\n Assert.Equal(8.0, result);\n }\n\n [Fact]\n public void Add_PositiveAndNegativeNumber_ReturnsCorrectSum()\n {\n // Arrange\n double x = 7.0;\n double y = -2.0;\n\n // Act\n double result = _calculator.Add(x, y);\n\n // Assert\n Assert.Equal(5.0, result);\n }\n\n [Fact]\n public void Add_TwoNegativeNumbers_ReturnsCorrectSum()\n {\n // Arrange\n double x = -4.0;\n double y = -6.0;\n\n // Act\n double result = _calculator.Add(x, y);\n\n // Assert\n Assert.Equal(-10.0, result);\n }\n\n [Fact]\n public void Add_NumberAndZero_ReturnsSameNumber()\n {\n // Arrange\n double x = 9.0;\n double y = 0.0;\n\n // Act\n double result = _calculator.Add(x, y);\n\n // Assert\n Assert.Equal(9.0, result);\n }\n\n [Fact]\n public void Add_ZeroAndNumber_ReturnsSameNumber()\n {\n // Arrange\n double x = 0.0;\n double y = 11.0;\n\n // Act\n double result = _calculator.Add(x, y);\n\n // Assert\n Assert.Equal(11.0, result);\n }\n\n [Fact]\n public void Add_DecimalNumbers_ReturnsCorrectSum()\n {\n // Arrange\n double x = 2.5;\n double y = 3.75;\n\n // Act\n double result = _calculator.Add(x, y);\n\n // Assert\n Assert.Equal(6.25, result, 5); // precision of 5 digits\n }\n\n [Fact]\n public void Add_LargeNumbers_ReturnsCorrectSum()\n {\n // Arrange\n double x = 1.0E\u002B308;\n double y = 1.0E\u002B308;\n\n // Act\n double result = _calculator.Add(x, y);\n\n // Assert\n Assert.Equal(double.PositiveInfinity, result);\n }\n\n [Fact]\n public void Add_SmallNumbers_ReturnsCorrectSum()\n {\n // Arrange\n double x = 1.0E-308;\n double y = 2.0E-308;\n\n // Act\n double result = _calculator.Add(x, y);\n\n // Assert\n Assert.Equal(3.0E-308, result, 5); // precision of 5 digits\n }\n\n [Fact]\n public void Add_PlusInfinityAndNegativeInfinity_ReturnsNaN()\n {\n // Arrange\n double x = double.PositiveInfinity;\n double y = double.NegativeInfinity;\n\n // Act\n double result = _calculator.Add(x, y);\n\n // Assert\n Assert.True(double.IsNaN(result));\n }\n }\n\n // Stub of Calculator class to illustrate usage.\n // In a real scenario, Calculator would be part of the production code.\n public class Calculator\n {\n public double Add(double x, double y)\n {\n return x \u002B y;\n }\n }\n}\n