using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BatchAutoTest.TaskReader;
using BatchAutoTest.TaskExecuter;
using BatchAutoTest.Task;
using Renci.SshNet;
using System.IO;

namespace BatchAutoTest
{
    public partial class BatchAutoTest : Form
    {
        ConsoleView apConsoleView;
        ConsoleView dbConsoleView;
        bool isConnect = false;
        SshTaskExecuter apSte;
        SshTaskExecuter dbSte;
        DbTaskExecuter dte;
        List<TaskInfo> taskList;

        public BatchAutoTest()
        {
            InitializeComponent();

            apConsoleView = new ConsoleView();
            apConsoleView.Text += " - APサーバ";

            dbConsoleView = new ConsoleView();
            dbConsoleView.Text += " - DBサーバ";
        }

        private void BatchAutoTest_Load(object sender, EventArgs e)
        {
            // Apサーバコンボボックスの設定
            var ApServers = ConfigurationManager.AppSettings["ApServer"].Split(',');
            foreach(var ApServer in ApServers){
                cmbApServer.Items.Add(ApServer.Trim());
            }
            cmbApServer.SelectedIndex = 0;

            // Dbサーバコンボボックスの設定
            var DbServers = ConfigurationManager.AppSettings["DbServer"].Split(',');
            foreach (var DbServer in DbServers)
            {
                cmbDbServer.Items.Add(DbServer.Trim());
            }
            cmbDbServer.SelectedIndex = 0;

            // タスクリストの設定
            listTasks.FullRowSelect = true;
            listTasks.GridLines = true;
            listTasks.Sorting = SortOrder.Ascending;
            listTasks.View = View.Details;

            // 列（コラム）ヘッダの作成
            var columnStatus = new ColumnHeader();
            var columnSrv = new ColumnHeader();
            var columnType = new ColumnHeader();
            var columnName = new ColumnHeader();
            var columnCmd = new ColumnHeader();
            columnStatus.Text = "Status";
            columnStatus.Width = 60;
            columnSrv.Text = "環境";
            columnSrv.Width = 40;
            columnType.Text = "ジョブ種別";
            columnType.Width = 100;
            columnName.Text = "ジョブ名";
            columnName.Width = 250;
            columnCmd.Text = "実行コマンド";
            columnCmd.Width = 400;
            ColumnHeader[] colHeaderRegValue = { columnStatus, columnSrv, columnType, columnName, columnCmd };
            listTasks.Columns.AddRange(colHeaderRegValue);

            //自動実行表示
            lblStatus.Visible = false;
            progressBar1.Visible = false;

            string[] item1 = { "正常終了", "AP", "IF転送", "[B]請求計算01", @"C:\inputdata\20170202,/usr/local/sei19/" };
            string[] item2 = { "未実行", "AP", "コマンド実行", "[B]請求計算01", "/usr/local/sei19/batch/block/M0008_1.sh" };
            string[] item3 = { "未実行", "DB", "SQL実行", "合算請求ワークパッチ", "TRUNCATE TABLE SEI_W_GASSANSEIKYU;" };
            listTasks.Items.Add(new ListViewItem(item1));
            listTasks.Items.Add(new ListViewItem(item2));
            listTasks.Items.Add(new ListViewItem(item3));
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (listTasks.Items.Count == 0)
            {
                MessageBox.Show("ジョブリストが読み込まれていません");
                return;
            }

            txtStartNo.Enabled = false;
            txtEndNo.Enabled = false;
            chkWarn.Enabled = false;
            btnTaskLoad.Enabled = false;
            btnLogDownload.Enabled = false;
            btnExecute.Text = "テスト実行停止";

            lblStatus.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = Int32.Parse(txtEndNo.Text) - Int32.Parse(txtStartNo.Text) + 1;
            progressBar1.Visible = true;

            //ListViewItem itemx = new ListViewItem();
            //itemx = listTasks.SelectedItems[0];
            //itemx.SubItems[1].Text = "正常終了";
        }

        private void btnTaskLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "JobListファイル(*.joblist)|*.joblist|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "ジョブリストファイルを選択してください";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                //MessageBox.Show(ofd.FileName);
                TextTaskReader ttr = new TextTaskReader(ofd.FileName);
                taskList = ttr.ReadTask();

                if (taskList == null)
                {
                    MessageBox.Show("JobListファイルの読み込みに失敗しました");
                    return;
                }

                listTasks.Items.Clear();

                foreach (TaskInfo ti in taskList)
                {
                    string[] item = { ti.Status.DisplayName(), ti.ParamMap["Server"], ti.Type.DisplayName(), ti.TaskName, ti.ExecString };
                    listTasks.Items.Add(new ListViewItem(item));
                }
            }
        }

        private void listTasks_DoubleClick(object sender, EventArgs e)
        {
            if (!isConnect)
            {
                MessageBox.Show("サーバ接続されていないため、個別実行できません");
                return;
            }

            ListViewItem itemx = new ListViewItem();
            itemx = listTasks.SelectedItems[0];
            int idx = listTasks.SelectedIndices[0];
            string cmd = itemx.SubItems[4].Text;
            string taskName = itemx.SubItems[3].Text;
            DialogResult dr = MessageBox.Show(idx + " " + taskName + "を個別実行しますか？", "実行確認", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                if (taskList[idx].Type == TASK_TYPE.SQL)
                {
                    TaskResult tr = dte.Execute(taskList[idx]);
                    if (tr.ExitCode == -9999)
                    {
                        MessageBox.Show("SQL実行時にエラーが発生しました。\r\n" + tr.Output);
                    }
                    
                }
                else
                {
                    if (itemx.SubItems[1].Text.Equals("AP"))
                    {
                        //TaskResult tr = apSte.Execute(taskList[no - 1]);
                        //apConsoleView.AddLog(tr.Output);
                        execWorker.RunWorkerAsync(taskList[idx]);
                    }
                    else if (itemx.SubItems[1].Text.Equals("DB"))
                    {
                        TaskResult tr = dbSte.Execute(taskList[idx]);
                        dbConsoleView.AddLog(tr.Output);
                    }
                }
            }

        }

        private void btnLogDownload_Click(object sender, EventArgs e)
        {

        }

        private void execWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            TaskInfo ti = (TaskInfo)e.Argument;
            SshCommand cmd;
            IAsyncResult asyncResult = apSte.BeginTaskExecute(ti, out cmd);
            StreamReader stdoutStreamReader = new StreamReader(cmd.OutputStream, Encoding.GetEncoding("Shift-JIS"));
            StreamReader stderrStreamReader = new StreamReader(cmd.ExtendedOutputStream);

            while (!asyncResult.IsCompleted)
            {
                var stdoutLine = stdoutStreamReader.ReadToEnd();

                if (!string.IsNullOrEmpty(stdoutLine))
                {
                    apConsoleView.AddLog(stdoutLine);
                }
            }

            apConsoleView.AddLog("\r\n");
            cmd.EndExecute(asyncResult);

        }

        private void menuConsoleAp_Click(object sender, EventArgs e)
        {
            apConsoleView.Show();
        }

        private void menuConsoleDb_Click(object sender, EventArgs e)
        {
            dbConsoleView.Show();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!isConnect)
            {
                try
                {
                    apSte = new SshTaskExecuter(cmbApServer.SelectedText, txtApUserName.Text, txtApPassword.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("APサーバへのSSH接続に失敗しました。\r\n" + ex.Message);
                    return;
                }

                try
                {
                    dbSte = new SshTaskExecuter(cmbDbServer.SelectedText, txtDbUserName.Text, txtDbPassword.Text);
                }
                catch (Exception ex)
                {
                    apSte.Close();
                    apSte = null;
                    MessageBox.Show("DBサーバへのSSH接続に失敗しました。\r\n" + ex.Message);
                    return;
                }

                string conStr = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + cmbDbServer.SelectedText + ")(PORT=" + txtDbPort.Text + "))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + txtDbSid.Text + "))); User Id=" + txtDbSchema.Text + "; Password=" + txtDbSchemaPass.Text;
                try
                {
                    dte = new DbTaskExecuter(conStr);
                }
                catch (Exception ex)
                {
                    apSte.Close();
                    apSte = null;
                    dbSte.Close();
                    dbSte = null;
                    MessageBox.Show("DB接続に失敗しました。\r\n" + ex.Message);
                    return;
                }

                groupAp.Enabled = false;
                groupDb.Enabled = false;
                btnExecute.Enabled = true;
                btnConnect.Text = "サーバ切断";
            }
            else
            {
                if (apSte != null)
                {
                    apSte.Close();
                    apSte = null;
                }
                if (dbSte != null)
                {
                    dbSte.Close();
                    dbSte = null;
                }

                if (dte != null)
                {
                    dte.Close();
                    dte = null;
                }
                groupAp.Enabled = true;
                groupDb.Enabled = true;
                btnExecute.Enabled = false;
                btnConnect.Text = "サーバ接続";
            }
            isConnect = !isConnect;
        }

        private void txtApSshPort_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                // 入力値を数値に変換する
                int iAge = int.Parse(txtApSshPort.Text);
                errorProvider1.SetError(txtApSshPort, "");
            }
            catch (Exception)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApSshPort, "数値(0-9)で入力してください");
            }
        }

        private void txtStartNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                // 入力値を数値に変換する
                int iAge = int.Parse(txtStartNo.Text);
                errorProvider1.SetError(txtStartNo, "");
            }
            catch (Exception)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtStartNo, "数値(0-9)で入力してください");
            }
        }

        private void txtDbSshPort_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                // 入力値を数値に変換する
                int iAge = int.Parse(txtDbSshPort.Text);
                errorProvider1.SetError(txtDbSshPort, "");
            }
            catch (Exception)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDbSshPort, "数値(0-9)で入力してください");
            }
        }

        private void txtDbPort_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                // 入力値を数値に変換する
                int iAge = int.Parse(txtDbPort.Text);
                errorProvider1.SetError(txtDbPort, "");
            }
            catch (Exception)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDbPort, "数値(0-9)で入力してください");
            }
        }

        private void txtEndNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                // 入力値を数値に変換する
                int iAge = int.Parse(txtEndNo.Text);
                errorProvider1.SetError(txtEndNo, "");
            }
            catch (Exception)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEndNo, "数値(0-9)で入力してください");
            }
        }
    }
}
