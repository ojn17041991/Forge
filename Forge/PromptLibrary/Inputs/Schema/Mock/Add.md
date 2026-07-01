{
  "version": 1,
  "target": {
    "namespace": "FunctionLibrary.Dependencies",
    "class": {
      "name": "FunctionLibrary",
      "accessibility": "public",
      "isStatic": false,
      "isAbstract": false,
      "constructors": [
        {
          "parameters": []
        }
      ]
    },
    "method": {
      "name": "Add",
      "accessibility": "public",
      "isStatic": false,
      "returnType": {
        "name": "double",
        "isNullable": false
      },
      "parameters": [
        {
          "name": "x",
          "type": {
            "name": "double",
            "isNullable": false
          }
        },
	    {
          "name": "y",
          "type": {
            "name": "double",
            "isNullable": false
          }
        }
      ]
    }
  },
  "documentation": {
    "summary": "Returns the sum of two numbers.",
    "remarks": "",
    "parameters": [
      {
        "name": "x",
        "description": "First number."
      },
      {
        "name": "y",
        "description": "Second number."
      }
    ],
    "typeParameters": [],
    "returns": "The sum of x and y.",
    "exceptions": [],
    "examples": []
  }
}