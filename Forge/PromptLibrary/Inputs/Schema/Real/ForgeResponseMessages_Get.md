{
  "version": 1,
  "target": {
    "namespace": "Forge.Responses",
    "class": {
      "name": "ForgeResponseMessages",
      "accessibility": "public",
      "isStatic": true,
      "isAbstract": false,
      "constructors": [
        {
          "parameters": []
        }
      ]
    },
    "method": {
      "name": "Get",
      "accessibility": "public",
      "isStatic": true,
      "returnType": {
        "name": "string",
        "isNullable": false
      },
      "parameters": [
        {
          "name": "responseCode",
          "type": {
            "name": "ForgeResponseCode",
            "isNullable": false
          }
        }
      ]
    }
  },
  "documentation": {
    "summary": "Gets a message for console output based on an internal response code.",
    "remarks": "",
    "parameters": [
      {
        "name": "responseCode",
        "description": "The response code indicating the current operation state."
      }
    ],
    "typeParameters": [],
    "returns": "A human-readable console message.",
    "exceptions": [],
    "examples": []
  }
}