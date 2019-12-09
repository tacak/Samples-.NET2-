using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Renci.SshNet;

namespace BatchAutoTest
{
    public partial class ConsoleView : Form
    {
        public ConsoleView()
        {
            InitializeComponent();
        }

        private void menuAllClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("コンソールの内容を全て消去します。","確認",MessageBoxButtons.YesNo) == DialogResult.Yes){
                txtConsole.Clear();
            }
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void menuCmdSend_Click(object sender, EventArgs e)
        {
            return;
        }

        private void shellWoker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        public void AddLog(string logText)
        {
            txtConsole.Text += logText;
        }
    }
}
