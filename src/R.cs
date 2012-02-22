using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Dunwich
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
            this.batchFileInit();
        }

        public void WriteLine(string command)
        {
            this.WriteToRFile("cat('" + command + "')\n");
        }

        // For now the file that wants to get written must be fully qualified
        // Later implementations should use Path objects to write to the appropriate directory
        public void WriteToFileOn(string file)
        {
            this.WriteToRFile("sink(\"" + file + "\")\n");
        }

        public void WriteToFileOff()
        {
            this.WriteToRFile("sink()\n");
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

        private void RFileInit()
        {
            // Create the file if it does not exist
            // Else wipe its contents
            if (!File.Exists(this.RPath + this.RFile))
            {
                File.Create(this.RPath + this.RFile);
            }
            else
            {
                File.WriteAllText(this.RPath + this.RFile, "");
            }

        }

        /**
         * Create batch files used to execute any generated .R files
         * */
        private void batchFileInit()
        {
            string batchFileName = this.RPath + this.BatchFile;

            // Delete the file if it exists
            if (File.Exists(batchFileName))
            {
                File.Delete(batchFileName);
            }

            using (FileStream fs = File.Create(batchFileName, 1024)) 
            {
                byte[] info = new System.Text.UTF8Encoding(true).GetBytes("@ECHO OFF\nRscript \"" + this.RPath + this.RFile + "\"");
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
