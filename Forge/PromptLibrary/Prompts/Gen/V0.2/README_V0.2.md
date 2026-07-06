The schema is no longer hard-coded in the prompt. It is derived from the C# DTOs and passed into the prompt as an argument.

The following issues from V0.1 will rollover to V0.3 as they are lower priority than the above:
Currently, the formatting of the output code is not useable. It should be possible to copy and paste this code directly into a test class.
There are also issues with Success responses missing required information or assuming. Additional Spec context may be required.