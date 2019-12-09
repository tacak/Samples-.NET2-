using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchAutoTest.Task;
using BatchAutoTest.TaskReader;
using BatchAutoTest.TaskExecuter;
using System.IO;

namespace BatchAutoTest
{
    class TextTaskReader : TaskReader.TaskReader
    {
        private string inFilePath;

        public TextTaskReader(string filePath)
        {
            inFilePath = filePath;
        }

        public List<TaskInfo> ReadTask()
        {
            List<TaskInfo> taskList = new List<TaskInfo>();

            StreamReader cReader = (new System.IO.StreamReader(inFilePath, System.Text.Encoding.Default));
            while (cReader.Peek() >= 0)
            {
                string stBuffer = cReader.ReadLine();
                var taskInfos = stBuffer.Split(',');

                if (taskInfos.Length != 5)
                {
                    return null;
                }

                // 先頭から Status, Type, TaskName, ExecString, Params(実行サーバの情報入り)
                TaskInfo ti = new TaskInfo();
                ti.Status = (TASK_STATUS)Int32.Parse(taskInfos[0].Trim());
                ti.Type = (TASK_TYPE)Int32.Parse(taskInfos[1].Trim());
                ti.TaskName = taskInfos[2].Trim();
                ti.ExecString = taskInfos[3].Trim();
                Dictionary<string, string> paramMap = new Dictionary<string, string>();
                paramMap.Add("Server", taskInfos[4].Trim());
                ti.ParamMap = paramMap;

                taskList.Add(ti);
            }

            return taskList;
        }
    }
}
