using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BatchAutoTest.LogWriter
{
    class LogWriter
    {
        string logFilePath;

        public LogWriter(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void WriteLog(string msg)
        {
            using (StreamWriter fs = new StreamWriter(logFilePath, true))
            {
                fs.WriteLine(msg);
            }
        }
    }
}
