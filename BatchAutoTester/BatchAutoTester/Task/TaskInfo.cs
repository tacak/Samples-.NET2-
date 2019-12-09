using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchAutoTester.TaskExecuter;

namespace BatchAutoTester.Task
{
    class TaskInfo
    {
        private TASK_TYPE _type;
        private string _execCommand;
        private List<string> _params;

        public List<string> _params1
        {
            get { return _params; }
            set { _params = value; }
        }

        public string ExecString
        {
            get { return _execCommand; }
            set { _execCommand = value; }
        }

        public TASK_TYPE Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
