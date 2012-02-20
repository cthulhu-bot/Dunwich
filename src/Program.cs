using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RTranscompiler
{
    class Program
    {

        static void Main(string[] args)
        {
            R r = new R();
            //r.WriteOutputToFile("test_output.txt");
            r.WriteLine("gotta be kidding me");
        }
    }
}
