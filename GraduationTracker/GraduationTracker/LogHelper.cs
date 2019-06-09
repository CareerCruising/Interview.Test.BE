using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GraduationTracker
{
    class LogHelper
    {
        public static void WriteLog(Exception ex, string LogAddress = "")
        {
            //if log file is empty, then create file - YYYY-mm-dd_Log.log in the Debug directory
            if (LogAddress == "")
            {
                LogAddress = Environment.CurrentDirectory + '\\' +
                    DateTime.Now.Year + '-' +
                    DateTime.Now.Month + '-' +
                    DateTime.Now.Day + "_Log.log";
            }

            //exception information ouput into the file
            StreamWriter fs = new StreamWriter(LogAddress, true);
            fs.WriteLine("Current time：" + DateTime.Now.ToString());
            fs.WriteLine("Abnormal information：" + ex.Message);
            fs.WriteLine("Abnormal object：" + ex.Source);
            fs.WriteLine("Call stack：\n" + ex.StackTrace.Trim());
            fs.WriteLine("Triggering method：" + ex.TargetSite);
            fs.WriteLine();
            fs.Close();
        }

    }
}
