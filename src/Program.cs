using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Dunwich
{
    class Program
    {
        static void Main(string[] args)
        {
            RFuncs r = new RFuncs();
            //RVector v = new RVector();

            //r.StreamResultsToFileOn("C:\\\\Users\\\\Joshua\\\\Documents\\\\Visual Studio 2010\\\\Projects\\\\Dunwich\\\\Dunwich\\\\output\\\\test_output.txt");
            //r.WriteLine("Hello World!");
            //r.StreamResultsToFileOff();
            //r.WriteLine("foo");

            //RVector rVector = new RVector();
            //rVector.Init(() => rVector);

            //r.WriteBDCommand("x <- c(1,2,3,4,5)");
            //r.WriteBDCommand("y <- c(35,14,32,14,15)");
            //r.WriteBDCommand("X11()");
            //r.WriteBDCommand("plot(x,y)");
            //r.WriteBDCommand("print(\"Press Return to Continue\")");
            //r.WriteBDCommand("invisible(readLines(\"stdin\", n=1))");

            //v.Add(3);
            //r.print(v);
            
            //r.ExecuteRFile();

            // Test array multiplication
            RVector v1 = new RVector(1, 2, 3);
            RVector v2 = new RVector(1, 2, 3);
            int v3 = v1 * v2;
            Console.WriteLine("v3 = " + v3.ToString());

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
