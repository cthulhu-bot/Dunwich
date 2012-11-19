using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Data.SqlTypes;

namespace Dunwich
{
    class RFuncs
    {
        private string RPath = "C:\\Users\\Joshua\\Documents\\Visual Studio 2010\\Projects\\Dunwich\\Dunwich\\output\\";
        private string RFile = "test.R";
        private string RLogFile = "test.log";
        private string BatchFile = "test.bat";
        private RFileWriter rw;

        /**
         * Public constuctor instantiating RFileWriter
         * */
        public RFuncs() {
            rw = new RFileWriter();
        }

        /**
         * Function:     plot
         * Description:  Plot a single vector
         * Parameters:
         * Returns:
         * */
        public void plot(RVector r)
        {
            rw.WriteToRFile("X11()\n");
            rw.WriteToRFile("plot(" + r.Name + ")");
        }

        /**
         * Function:     plot
         * Description:  Plot 2 vectors against each other
         * Parameters:
         * Returns:
         * */
        public void plot(RVector r1, RVector r2)
        {
            rw.WriteToRFile("X11()\n");
            rw.WriteToRFile("plot(" + r1.Name + ", " + r2.Name + ")");
        }

        //public void buildVector(RVector r)
        //{
        //    rw.WriteToRFile(r.Name + " <- ");
        //    foreach (object o in r)
        //    {
        //    }
        //}

        /**
         * Function:     WriteLine
         * Description:  Create batch files used to execute any generated .R files
         * Parameters:
         * Returns:
         * */
        public void WriteLine(string command)
        {
            rw.WriteToRFile("cat('" + command + "')\n");
        }


        /**
         * Function:     StreamResultsToFile
         * Description:  For now the file that wants to get written must be fully qualified.  
         * Later implementations should use Path objects to write to the appropriate directory
         * Parameters:
         * Returns:
         * */
        public void StreamResultsToFileOn(string file)
        {
            rw.WriteToRFile("sink(\"" + file + "\")\n");
        }

        /**
         * Function:     StreamResultsToFile
         * Description:  For now the file that wants to get written must be fully qualified.  
         * Later implementations should use Path objects to write to the appropriate directory
         * Parameters:
         * Returns:
         * */
        public void StreamResultsToFileOff()
        {
            rw.WriteToRFile("sink()\n");
        }

        /**
         * Function:    Print
         * Description: 
         * Parameters:  
         * Returns:     null
         * */
        public void print(RVector v)
        {
            rw.WriteToRFile(v.Name + "\n");
        }



        /**
         * Function:     ExecuteRFile
         * Description:  Create batch files used to execute any generated .R files
         * Parameters:
         * Returns:
         * */
        public void ExecuteRFile()
        {
            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = this.RPath + this.BatchFile;
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();

                File.AppendAllText(RPath + RLogFile, "ExecuteRFile:  " + System.DateTime.Now + ":  " + RPath + RFile + "\n");
                File.AppendAllText(RPath + RLogFile, "ExecuteRFile:  " + System.DateTime.Now + ":  " + output.ToString() + "\n");
                Console.WriteLine("Output:  " + output);
                Console.WriteLine("... press any key to continue");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                File.AppendAllText(RPath + RLogFile, "ExecuteRFile:  " + System.DateTime.Now);
                File.AppendAllText(RPath + RLogFile, e.Message + "\n");
                Console.WriteLine("Exception Caught: " + e.Message);
                Console.WriteLine("... press any key to continue");
                Console.ReadLine();
            }
        }

        /**
         * Backdoor to write R code directly to an R File executable
         * */
        public void WriteBDCommand(string rCode)
        {
            rw.WriteBDCommand(rCode);
        }
    }

    //class RVectorAssembler
    //{
    //    public RVector newRVector(RVectorFactory factory)
    //    {
    //        RVector rVector = (RVector)factory.GetRVector();
    //        return rVector;
    //    }
    //}
}
