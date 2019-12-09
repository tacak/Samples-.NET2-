using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchAutoTester.Task;

namespace BatchAutoTester.TaskExecuter
{
    interface TaskExecuter
    {
        TaskResult execute(TaskInfo ti);
    }
}
