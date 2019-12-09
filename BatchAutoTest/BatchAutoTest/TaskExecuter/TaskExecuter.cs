using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchAutoTest.Task;
using Renci.SshNet;

namespace BatchAutoTest.TaskExecuter
{
    interface TaskExecuter
    {
        TaskResult Execute(TaskInfo ti);
    }
}
