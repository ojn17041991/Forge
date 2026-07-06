The schema is no longer hard-coded in the prompt. It is derived from the C# DTOs and passed into the prompt as an argument.

The following issues from V0.3 will rollover to V0.6 as they are lower priority than the above:
- See ForgeResponseBuilderTests.ResponseTSuccessTests. Too many tests cases for a simple function.
- See ForgeResponseBuilderTests.ResponseTests.TestCase5. This is violating the prompt rules as it considers context outside of the function itself.
- See ForgeResponseBuilderTests.ResponseTests.TestCase2. Categorization is generally good, but feels arbitrary sometimes. This is Essential, but should be Optional.
- Compare ForgeResponseTests.ConstructorTests and ForgeResponseTests.ConstructorTTests. These are almost identical functions, but one has 2 tests and the other has 7. Most of the 7 are redundant. See point 1.
- Types generated in the output are inconsistent in terms of formatting (5 vs 5.0 vs 5.0m) or stringification (NaN vs "NaN").