Dunwich

A lightweight C# wrapper that encapsulates the R programming language.

ToDo:

1.  Fix RFuncs to read from config file.
2.  Build backdoor for testing straight R code. (DONE)
3.  Possibly refactor the RVector generation back to using a Factory in order to abstract away the initalization function which is needed to programatically retain the C# RVector name as the vector's actual name in R. (LAME IDEA COMPLETED IN A DIFFERNT WAY)
4.  Fix the RVector enumeration and add indexing (DONE)
5.  Abstract out RFile access (writing/reading) since it will need to be accessed by more than just the functions class.  RVector currently having difficult time writing to Rfile without additional layer of abstraction.
6.  Decide whether vector arithmatic should be occurring in c# or directly in R (separation of duties)