using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchAutoTester.Task
{
    class TaskResult
    {
        int _exitCode;
        string _output;

        public int ExitCode
        {
            get { return _exitCode; }
            set { _exitCode = value; }
        }

        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }
    }
}
