Dunwich

A lightweight C# wrapper that encapsulates the R programming language.

ToDo:

1.  Decouple the actual R code generation from the R and batch file initalization.
2.  Possibly refactor the RVector generation back to using a Factory in order to abstract away
the initalization function which is needed to programatically retain the C# RVector name as the vector's actual name in R.