using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Dunwich
{
    class RFileWriter
    {
        private static Boolean rFileInitialized;
        private string RPath = "C:\\Users\\Joshua\\Documents\\Visual Studio 2010\\Projects\\Dunwich\\Dunwich\\output\\";
        private string RFile = "test.R";
        private string BatchFile = "test.bat";
        private string RLogFile = "test.log";
        private static RFile rFile = null;

        public RFileWriter()
        {
            if (rFile == null)
            {
                rFile = new RFile(RPath, RFile, BatchFile);
                RFileInitialized = true;
            }
        }


        /**
         * Function:     WriteToRFile
         * Description:  Core function to format and write commands to RFile for execution.
         * Parameters:   command Actual R code generated from other internal functions
         * Returns:      void
         * */
        public void WriteToRFile(string command)
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
         * Function:    WriteCommand
         * Description: Backdoor implementation to write commands directly to the RFile.
         * Must change to private before deployment.
         * Parameters:  command String of R commands to write
         * Returns:     Void
         * */
        public void WriteBDCommand(string command)
        {
            string RFile = this.RPath + this.RFile;
            try
            {
                File.AppendAllText(RFile, command + "\n");
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

        public Boolean RFileInitialized
        {
            get { return rFileInitialized; }
            set { rFileInitialized = value; }
        }
    }
}
