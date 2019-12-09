using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchAutoTest.TaskExecuter;

namespace BatchAutoTest.Task
{
    class TaskInfo
    {
        private TASK_TYPE _type;
        private TASK_STATUS _status;
        private string _taskName;
        private string _execCommand;
        private Dictionary<string, string> _paramMap;

        public TASK_STATUS Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }

        public Dictionary<string, string> ParamMap
        {
            get { return _paramMap; }
            set { _paramMap = value; }
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
