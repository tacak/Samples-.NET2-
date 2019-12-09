using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchAutoTest.Task;

namespace BatchAutoTest.TaskReader
{
    interface TaskReader
    {
        List<TaskInfo> ReadTask();
    }
}
