After experimenting with variations of the previous version, this version, instead of attempting to refine down a list of valuable test cases, instead asks the model to generate a larger number of tests cases and then to categorise them by value.
This means that the model will not exclude test cases that it deems to be low value. Instead, it will include them, and allow a developer to make an informed decision.

In addition, this version benefits from a <behaviours> section in the XML, in which a developer can provide high-level business logic without explicitely exposing IP.
This is not required input, however will produce stronger results.