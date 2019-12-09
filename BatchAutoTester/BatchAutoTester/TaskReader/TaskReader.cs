using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchAutoTester.Task;

namespace BatchAutoTester.TaskReader
{
    interface TaskReader
    {
        List<TaskInfo> ReadTask();
    }
}
