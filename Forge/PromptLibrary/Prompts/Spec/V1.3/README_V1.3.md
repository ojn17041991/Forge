The data structure that was being used for the Spec inputs was lacking information required by the Gen command. This has been replaced with a structured JSON schema named Context.
The data structure that was being outputted by the Spec command has also been replaced with a structured JSON schema named Spec.

The following issues from V1.2 will rollover to V1.4 as they are lower priority than the above:
- See ForgeResponseBuilderTests.ResponseTSuccessTests. Too many tests cases for a simple function.
- See ForgeResponseBuilderTests.ResponseTests.TestCase5. This is violating the prompt rules as it considers context outside of the function itself.
- See ForgeResponseBuilderTests.ResponseTests.TestCase2. Categorization is generally good, but feels arbitrary sometimes. This is Essential, but should be Optional.
- Compare ForgeResponseTests.ConstructorTests and ForgeResponseTests.ConstructorTTests. These are almost identical functions, but one has 2 tests and the other has 7. Most of the 7 are redundant. See point 1.
- Types generated in the output are inconsistent in terms of formatting (5 vs 5.0 vs 5.0m) or stringification (NaN vs "NaN").