Dunwich

A lightweight C# wrapper that encapsulates the R programming language.

ToDo:

1.  Fix RFuncs to read from config file.
2.  Build backdoor for testing straight R code.
3.  Possibly refactor the RVector generation back to using a Factory in order to abstract away
the initalization function which is needed to programatically retain the C# RVector name as the vector's actual name in R.