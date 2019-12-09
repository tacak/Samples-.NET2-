using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using BatchAutoTest.Task;
using System.Data;

namespace BatchAutoTest.TaskExecuter
{
    class DbTaskExecuter : TaskExecuter
    {
        private OracleConnection Connection;

        public DbTaskExecuter(string ConnectionString)
        {
            Connection = new OracleConnection();
            Connection.ConnectionString = ConnectionString;
            Connection.Open();
        }

        public TaskResult Execute(TaskInfo ti)
        {
            TaskResult tr = new TaskResult();
            tr.Output = "";

            OracleCommand cmd = new OracleCommand(ti.ExecString);
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;

            try
            {
                tr.ExitCode = cmd.ExecuteNonQuery();
            }
            catch (Exception ex){
                tr.ExitCode = -9999;
                tr.Output = ex.Message;
            }

            return tr;
        }

        public void Close()
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}
