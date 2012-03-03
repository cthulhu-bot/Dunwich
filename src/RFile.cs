using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Dunwich
{
    class RFile
    {
        public RFile(string RPath, string RFileName, string BatchFile)
        {
            this.RFileInit(RPath, RFileName);
            this.batchFileInit(RPath, BatchFile, RFileName);
        }


        /**
         * Function:     batchFileInit
         * Description:  Create batch files used to execute any generated .R files
         * Parameters:
         * Returns:
         * */
        private void RFileInit(string RPath, string RFileName)
        {
            // Create the file if it does not exist
            // Else wipe its contents
            if (!File.Exists(RPath + RFileName))
            {
                File.Create(RPath + RFileName);
            }
            else
            {
                File.WriteAllText(RPath + RFileName, "");
            }

        }


        /**
         * Function:     batchFileInit
         * Description:  Create batch files used to execute any generated .R files
         * Parameters:
         * Returns:
         * */
        private void batchFileInit(string RPath, string BatchFile, string RFileName)
        {
            string batchFileName = RPath + BatchFile;

            // Delete the file if it exists
            if (File.Exists(batchFileName))
            {
                File.Delete(batchFileName);
            }

            using (FileStream fs = File.Create(batchFileName, 1024))
            {
                byte[] info = new System.Text.UTF8Encoding(true).GetBytes("@ECHO OFF\nRscript \"" + RPath + RFileName + "\"");
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
