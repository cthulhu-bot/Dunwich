using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace RTranscompiler
{
    class R
    {
        private string RPath = "C:\\Users\\Joshua\\Documents\\Visual Studio 2010\\Projects\\Dunwich\\Dunwich\\output\\";
        private string RFile = "test.R";
        private string RLogFile = "test.log";
        private string BatchFile = "test.bat";

        // public constructor
        public R()
        {
            this.RFileInit();
        }

        public void WriteLine(string command)
        {
            this.WriteToRFile("cat('" + command + "')\n");
            this.ExecuteRFile(this.RPath + this.BatchFile);
        }

        public void WriteOutputToFile(string file)
        {
            this.WriteToRFile("sink(\"" + file + "\")\n");
        }

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

        private void ExecuteRFile(string batchFile)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = batchFile;
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

        private void RFileInit()
        {
            try
            {
                //File.Delete(this.RPath + this.RFile);
                //File.Create(this.RPath + this.RFile);
            }
            catch (Exception e)
            {
                File.AppendAllText(RPath + RLogFile, "RFileInit:  " + System.DateTime.Now + ":  ");
                File.AppendAllText(RPath + RLogFile, e.Message + "\n");
                Console.WriteLine("Exception Caught: " + e.Message);
                Console.WriteLine("... press any key to continue");
                Console.ReadLine();
            }
        }

        private void rFileFactory()
        {
        }

        /**
         * Create batch files used to execute any generated .R files
         * */
        private void batchFileFactory()
        {
            string batchFileName = "C:\\Users\\Joshua\\Documents\\Visual Studio 2010\\Projects\\Dunwich\\Dunwich\\output\\test.bat";

            // Delete the file if it exists
            if (File.Exists(batchFileName))
            {
                File.Delete(batchFileName);
            }

            using (FileStream fs = File.Create(batchFileName, 1024)) 
            {
                byte[] info = new System.Text.UTF8Encoding(true).GetBytes("@ECHO OFF\nRscript \"C:\\Users\\Joshua\\Documents\\Visual Studio 2010\\Projects\\Dunwich\\Dunwich\\output\\test.R\"");
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
