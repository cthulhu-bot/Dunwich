using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Dunwich
{
    class Program
    {
        static void Main(string[] args)
        {
            RFuncs r = new RFuncs();

            //r.StreamResultsToFileOn("C:\\\\Users\\\\Joshua\\\\Documents\\\\Visual Studio 2010\\\\Projects\\\\Dunwich\\\\Dunwich\\\\output\\\\test_output.txt");
            //r.WriteLine("Hello World!");
            //r.StreamResultsToFileOff();
            //r.WriteLine("foo");

            RVector rVector = new RVector();
            rVector.Init(() => rVector);
            r.WriteLine(rVector.Name);

            //r.WriteCommand("x <- c(1,2,3,4,5)");
            //r.WriteCommand("y <- c(1,2,3,4,5)");
            //r.WriteCommand("X11()");
            //r.WriteCommand("plot(x)");
            //r.WriteCommand("print(\"Press Return to Continue\")");
            //r.WriteCommand("invisible(readLines(\"stdin\", n=1))");

            r.ExecuteRFile();
            //Console.WriteLine("Press enter to continue...");
            //Console.ReadLine();
        }
    }
}
