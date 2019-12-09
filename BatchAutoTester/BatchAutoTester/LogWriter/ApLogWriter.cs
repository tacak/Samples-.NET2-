using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchAutoTester.LogWriter
{
    class ApLogWriter : LogWriter
    {
        // 1 : error
        // 2 : error, warn
        // 3 : error, warn, info
        // 4 : error, warn, info, debug
        int _logLevel = 0;

        public ApLogWriter(int logLevel, string logFilePath) : base(logFilePath)
        {
            this._logLevel = logLevel;
        }

        public void error(string msg)
        {
            if (_logLevel >= 0)
            {
                WriteLog(msg);
            }
        }

        public void warn(string msg)
        {
            if (_logLevel >= 1)
            {
                WriteLog(msg);
            }
        }

        public void info(string msg)
        {
            if (_logLevel >= 2)
            {
                WriteLog(msg);
            }
        }

        public void info(string msg)
        {
            if (_logLevel >= 3)
            {
                WriteLog(msg);
            }
        }
    }
}
