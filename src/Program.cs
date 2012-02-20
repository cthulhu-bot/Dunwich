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
            R r = new R();
            r.WriteToFileOn("C:\\\\Users\\\\Joshua\\\\Documents\\\\Visual Studio 2010\\\\Projects\\\\Dunwich\\\\Dunwich\\\\output\\\\test_output.txt");
            r.WriteLine("this shit should be working");
            r.WriteToFileOff();
            r.WriteLine("WTF");
            r.ExecuteRFile();
        }
    }
}
