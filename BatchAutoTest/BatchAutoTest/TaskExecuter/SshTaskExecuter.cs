using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchAutoTest.Task;
using Renci.SshNet;
using System.Windows.Forms;

namespace BatchAutoTest.TaskExecuter
{
    class SshTaskExecuter : TaskExecuter
    {
        ConnectionInfo connInfo;
        SshClient sClient;

        public SshTaskExecuter(string host, string username, string password)
            : this(host, 22, username, password)
        {
        }

        public SshTaskExecuter(string host, int port, string username, string password)
        {
            connInfo = new ConnectionInfo(host, port, username,
                       new AuthenticationMethod[] { new PasswordAuthenticationMethod(username, password) });
            connInfo.Encoding = Encoding.GetEncoding("UTF-8");

            sClient = new SshClient(connInfo);
            sClient.Connect();
        }

        public void Close()
        {
            if (sClient != null)
            {
                sClient.Disconnect();
                sClient.Dispose();
            }
        }

        public TaskResult Execute(TaskInfo ti)
        {
            if (ti.Type != TASK_TYPE.COMMAND &&
                ti.Type != TASK_TYPE.FILE_DOWNLOAD &&
                ti.Type != TASK_TYPE.FILE_UPLOAD)
            {
                return null;
            }
            return ExecuteCommand(ti);
        }

        public IAsyncResult BeginTaskExecute(TaskInfo ti, out SshCommand cmd)
        {
            cmd = sClient.CreateCommand(ti.ExecString);
            IAsyncResult syncObj = cmd.BeginExecute();

            return syncObj;
        }

        public void EndTaskExecute(IAsyncResult iar, SshCommand cmd)
        {
            cmd.EndExecute(iar);
        }

        private TaskResult ExecuteCommand(TaskInfo ti)
        {
            TaskResult tr = new TaskResult();

            if (ti.Type == TASK_TYPE.COMMAND)
            {
                using (var cmd = sClient.CreateCommand(ti.ExecString))
                {
                    string ret = cmd.Execute();
                    tr.ExitCode = cmd.ExitStatus;
                    tr.Output = ret;
                }

                return tr;
            }
            else if (ti.Type == TASK_TYPE.FILE_UPLOAD)
            {
                string[] strTransferInfo = ti.ExecString.Split(',');
                if (strTransferInfo.Length != 2)
                {
                    string msg = "ファイル転送ジョブの送信元、送信先が指定されていません\r\n";
                    msg += ("名称：" + ti.TaskName);
                    msg += ("実行文：" + ti.ExecString); 

                    MessageBox.Show(msg);
                    return null;
                }
                string localPath = strTransferInfo[0];
                string srvPath = strTransferInfo[0]; 
            }

            return null;
        }

        public SshClient getShClient()
        {
            return sClient;
        }

        public ShellStream GetShellStream()
        {
            return sClient.CreateShellStream("term", 1024, 100, 1024, 100, 2048);
        }
    }
}
