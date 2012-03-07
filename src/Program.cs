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
            //RFuncs r = new RFuncs();
            //r.StreamResultsToFileOn("C:\\\\Users\\\\Joshua\\\\Documents\\\\Visual Studio 2010\\\\Projects\\\\Dunwich\\\\Dunwich\\\\output\\\\test_output.txt");
            //r.WriteLine("this shit should be working");
            //r.StreamResultsToFileOff();
            //r.WriteLine("WTF");
            //r.ExecuteRFile();

            RFuncs r = new RFuncs();
            RVector rVector = new RVector();
            rVector.Init(() => rVector);
            //Console.WriteLine(rVector.size);
            rVector.Add("Rawr");
            //Console.WriteLine(rVector.size);
            rVector.Add("HOLY SHIT IT WORKS");
            foreach (object o in rVector)
            {
                Console.WriteLine(o.ToString());
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
