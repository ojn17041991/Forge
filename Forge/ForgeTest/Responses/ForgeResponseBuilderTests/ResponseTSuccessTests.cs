namespace ForgeTest.Responses.ForgeResponseBuilderTests
{
    public class ResponseTSuccessTests
    {
        /*
TEST CASE 1  
Category: Essential  
Name: Success response with valid data  
Description: Verify that invoking Response with a success response code and valid non-null data returns a ForgeResponse with the provided data and response code without exceptions.  
Inputs: validData (non-null), ForgeResponseCode.Success  
Expected Result: Returns a ForgeResponse containing the provided data and the Success response code; no exception is thrown.

TEST CASE 2  
Category: Essential  
Name: Success response with null data throws InvalidOperationException  
Description: Verify that invoking Response with a success response code and null data throws an InvalidOperationException.  
Inputs: null, ForgeResponseCode.Success  
Expected Result: Throws InvalidOperationException.

TEST CASE 3  
Category: Essential  
Name: Non-success response with null data returns ForgeResponse  
Description: Verify that invoking Response with a non-success response code and null data returns a ForgeResponse containing the null data and the specified response code without exceptions.  
Inputs: null, nonSuccessResponseCode (any ForgeResponseCode other than Success)  
Expected Result: Returns a ForgeResponse containing null data and the specified non-success response code; no exception is thrown.

TEST CASE 4  
Category: Essential  
Name: Non-success response with valid data returns ForgeResponse  
Description: Verify that invoking Response with a non-success response code and valid non-null data returns a ForgeResponse containing that data and response code without exceptions.  
Inputs: validData (non-null), nonSuccessResponseCode (any ForgeResponseCode other than Success)  
Expected Result: Returns a ForgeResponse containing the provided data and specified non-success response code; no exception is thrown.

TEST CASE 5  
Category: Valuable  
Name: Response with default value data and success response code  
Description: Verify that invoking Response with a default value of T (e.g., 0 for int, null for reference types) and a success response code behaves correctly: throws InvalidOperationException if considered invalid data.  
Inputs: default(T), ForgeResponseCode.Success  
Expected Result: Throws InvalidOperationException if default(T) is treated as invalid data; otherwise, returns ForgeResponse with default(T) and Success.

TEST CASE 6  
Category: Valuable  
Name: Response with default value data and non-success response code  
Description: Verify that invoking Response with the default value of T (e.g., 0, null) and a non-success response code returns a ForgeResponse without exceptions.  
Inputs: default(T), nonSuccessResponseCode  
Expected Result: Returns ForgeResponse with default(T) and specified non-success response code without exceptions.

TEST CASE 7  
Category: Optional  
Name: Response with complex type data and various response codes  
Description: Verify that invoking Response with a complex type as data and various response codes returns the correct ForgeResponse instance.  
Inputs: complexObject, any ResponseCode  
Expected Result: Returns ForgeResponse containing complexObject and specified response code without exceptions.

---

Confidence: 90%  
Reason: The essential cases comprehensively cover the main behavioural branch points indicated by the documented exception and response code logic, specifically the interaction between success response code and validity of data. Valuable cases explore default(T) scenarios which can behave subtly depending on T, adding depth to coverage without redundancy. Optional cases extend to complex types, which does not add new behavioural branches but may inform about data handling. No other behaviours are explicitly or implicitly indicated in the documentation or signature to be tested.
         */
    }
}
