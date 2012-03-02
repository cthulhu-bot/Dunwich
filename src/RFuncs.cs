using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Dunwich
{
    class RFuncs
    {
        private string RPath = "C:\\Users\\Joshua\\Documents\\Visual Studio 2010\\Projects\\Dunwich\\Dunwich\\output\\";
        private string RFile = "test.R";
        private string RLogFile = "test.log";
        private string BatchFile = "test.bat";
        private RFile rFile = new RFile();
        
        /**
         * Function:     batchFileInit
         * Description:  Create batch files used to execute any generated .R files
         * Parameters:
         * Returns:
         * */
        public void plot(RVector r)
        {
            this.WriteToRFile("X11()\n");
            this.WriteToRFile("plot(" + r.name + ")");
        }

        /**
         * Function:     batchFileInit
         * Description:  Create batch files used to execute any generated .R files
         * Parameters:
         * Returns:
         * */
        public void plot(RVector r1, RVector r2)
        {
            this.WriteToRFile("X11()\n");
            this.WriteToRFile("plot(" + r1.name + ", " + r2.name + ")");
        }

        /**
         * Function:     batchFileInit
         * Description:  Create batch files used to execute any generated .R files
         * Parameters:
         * Returns:
         * */
        public void WriteLine(string command)
        {
            this.WriteToRFile("cat('" + command + "')\n");
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
            this.WriteToRFile("sink(\"" + file + "\")\n");
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
            this.WriteToRFile("sink()\n");
        }

        /**
         * Function:     batchFileInit
         * Description:  Create batch files used to execute any generated .R files
         * Parameters:
         * Returns:
         * */
        private void WriteToRFile(string command)
        {
            string RFile = this.RPath + this.RFile;
            try
            {
                File.AppendAllText(RFile, command);
            }
            catch (Exception e)
            {
                File.AppendAllText(RPath + RLogFile, "WriteToRFile:  " + System.DateTime.Now + ":  ");
                File.AppendAllText(RPath + RLogFile, "WriteToRFile:  " + System.DateTime.Now + e.Message + "\n");
                Console.WriteLine("Exception Caught: " + e.Message);
                Console.WriteLine("... press any key to continue");
                Console.ReadLine();
            }
        }

        /**
         * 
         * */
        public void WriteCommand(string command)
        {
            string RFile = this.RPath + this.RFile;
            try
            {
                File.AppendAllText(RFile, command);
            }
            catch (Exception e)
            {
                File.AppendAllText(RPath + RLogFile, "WriteToRFile:  " + System.DateTime.Now + ":  ");
                File.AppendAllText(RPath + RLogFile, "WriteToRFile:  " + System.DateTime.Now + e.Message + "\n");
                Console.WriteLine("Exception Caught: " + e.Message);
                Console.WriteLine("... press any key to continue");
                Console.ReadLine();
            }
        }

        /**
         * Function:     batchFileInit
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
