In the previous version, the model was tested with progressively low-value inputs, to the point that, by the end, the input had no XML comments, parameters or a descriptive name.
In such cases, the model would produce test cases that were outside the scope of the function itself. This has now been limited, and in such a way as to not interfere with the results that were being generated when useful input data was provided.

In addition, this version also provides a confidence score and its reasoning for that confidence.