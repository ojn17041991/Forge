The schema is no longer hard-coded in the prompt. It is derived from the C# DTOs and passed into the prompt as an argument.
After experimenting with code formatting, it has been decided that the code should be stored as an escaped JSON string and deserialized later.

Issues:
- The code structure is inconsistent in some places. Using statements are often not required or placed both inside and/or outside the namespace.
- Even though a class is static, there has been an attempt made to instantiate the class for testing.
- Test namespaces are repeated and generic.