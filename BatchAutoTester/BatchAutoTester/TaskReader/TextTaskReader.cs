using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchAutoTester.Task;
using BatchAutoTester.TaskReader;
using BatchAutoTester.TaskExecuter;

namespace BatchAutoTester
{
    class TextTaskReader : TaskReader.TaskReader
    {
        TextTaskReader(string filePath)
        {

        }

        public List<TaskInfo> ReadTask()
        {
            return new List<TaskInfo>();
        }
    }
}
