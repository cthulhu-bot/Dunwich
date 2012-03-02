using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Dunwich
{
    class RFile
    {
        private string RPath = "C:\\Users\\Joshua\\Documents\\Visual Studio 2010\\Projects\\Dunwich\\Dunwich\\output\\";
        private string RFileName = "test.R";
        private string RLogFile = "test.log";
        private string BatchFile = "test.bat";

        public RFile()
        {
            this.RFileInit();
            this.batchFileInit();
        }


        /**
         * Function:     batchFileInit
         * Description:  Create batch files used to execute any generated .R files
         * Parameters:
         * Returns:
         * */
        private void RFileInit()
        {
            // Create the file if it does not exist
            // Else wipe its contents
            if (!File.Exists(this.RPath + this.RFileName))
            {
                File.Create(this.RPath + this.RFileName);
            }
            else
            {
                File.WriteAllText(this.RPath + this.RFileName, "");
            }

        }


        /**
         * Function:     batchFileInit
         * Description:  Create batch files used to execute any generated .R files
         * Parameters:
         * Returns:
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
                byte[] info = new System.Text.UTF8Encoding(true).GetBytes("@ECHO OFF\nRscript \"" + this.RPath + this.RFileName + "\"");
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
