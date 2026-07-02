This initial prompt uses the v0.4 Spec Prompt and v0.1 Spec Response schema as an input and produces the v1 Gen Response schema as an output. This is always wrapped in the standard ForgeResponse container for processing.
There are three possible response codes Success, Incomplete & Error. If Incomplete, it means the model had insufficient data to produce a complete result, but produces a result anyway with any gaps highlighted.

Currently, the formatting of the output code is not useable. It should be possible to copy and paste this code directly into a test class.
There are also issues with Success responses missing required information or assuming. Additional Spec context may be required.