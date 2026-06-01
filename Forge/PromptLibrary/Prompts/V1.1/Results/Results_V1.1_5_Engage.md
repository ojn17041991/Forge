### Grade:

Fail.
Created TCs outside of function scope.

### Grade:

Pass.
Covered major cases.
Categorization somewhat arbitrary. For example, TC3 should be Essential.

### Given input:

public void Engage()

### Produced output:

TEST CASE 1
Category: Essential
Name: Successful invocation on valid instance
Description: Verify that the Engage method can be called on a properly instantiated object without runtime errors.
Inputs: Valid instance of the containing class; no parameters
Expected Result: Method completes execution without throwing any exception

TEST CASE 2
Category: Essential
Name: Invocation on null instance
Description: Verify behaviour when attempting to call Engage on a null reference.
Inputs: Null reference of the containing class type
Expected Result: NullReferenceException is thrown

TEST CASE 3
Category: Valuable
Name: Multiple sequential invocations on same instance
Description: Verify that repeated calls to Engage on the same object instance do not cause errors.
Inputs: Valid instance of the containing class; Engage called multiple times sequentially
Expected Result: Each invocation completes execution without throwing any exception

TEST CASE 4
Category: Optional
Name: Concurrent invocation across multiple threads
Description: Verify behaviour of Engage when invoked concurrently from multiple threads on the same instance.
Inputs: Valid instance of the containing class; multiple threads calling Engage simultaneously
Expected Result: Each invocation completes execution without unhandled exceptions or crashes