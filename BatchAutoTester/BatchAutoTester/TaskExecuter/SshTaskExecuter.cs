using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchAutoTester.Task;
using Renci.SshNet;

namespace BatchAutoTester.TaskExecuter
{
    class SshTaskExecuter : TaskExecuter
    {
        ConnectionInfo connInfo;
        SshClient sCient;

        public SshTaskExecuter(string host, string username, string password)
            : this(host, 22, username, password)
        {
        }

        public SshTaskExecuter(string host, int port, string username, string password)
        {
            connInfo = new ConnectionInfo(host, port, username,
                       new AuthenticationMethod[] { new PasswordAuthenticationMethod(username, password) });
        }

        public TaskResult execute(TaskInfo ti)
        {
            return new TaskResult();
        }
    }
}
