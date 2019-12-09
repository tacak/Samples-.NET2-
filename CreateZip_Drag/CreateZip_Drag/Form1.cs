using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CreateZip_Drag
{
    public partial class Form1 : Form
    {
        string[] s;
        int mode;
        string dirPath;

        delegate void SetCountDelegate(int cur, int max);
        delegate void SetAllowDropDelegate(bool b);

        public Form1()
        {
            InitializeComponent();

            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            mode = comboBox1.SelectedIndex;
            AllowDrop = false;
            comboBox1.Enabled = false;
            checkBox1.Enabled = false;
            label1.Text = "現在処理中です";

            Thread trd = new Thread(new ThreadStart(this.ThreadTask));
            trd.Start();
        }

        private void SetCount(int cur, int max)
        {
            label3.Text = cur + "/" + max;
            if (cur == 0 && max == 0)
            {
                label1.Text = "圧縮したいファイルをドラッグアンドドロップしてください";
                comboBox1.Enabled = true;
                checkBox1.Enabled = true;
            }
        }

        private void SetAllowDrop(bool b)
        {
            AllowDrop = b;
        }

        private void ThreadTask()
        {
            for (int i = 0; i < s.Length; i++)
            {
                Invoke(new SetCountDelegate(SetCount), i + 1, s.Length);

                if (mode == 0)
                {
                    ProcessStartInfo psInfo = new ProcessStartInfo();
                    psInfo.FileName = @"D:\Program Files\7-Zip\7z.exe"; // 実行するファイル
                    if (dirPath.Equals(""))
                    {
                        psInfo.Arguments = "a \"" + Path.GetDirectoryName(s[i]) + "\\" + Path.GetFileNameWithoutExtension(s[i]) + ".7z\" \"" + s[i] + "\"";
                    }
                    else
                    {
                        psInfo.Arguments = "a \"" + dirPath + "\\" + Path.GetFileNameWithoutExtension(s[i]) + ".7z\" \"" + s[i] + "\"";
                    }
                    
                    psInfo.CreateNoWindow = true; // コンソール・ウィンドウを開かない
                    psInfo.UseShellExecute = false; // シェル機能を使用しない

                    Process ps = Process.Start(psInfo);
                    ps.WaitForExit();
                    ps.Close();
                    ps.Dispose();
                }
                else if (mode == 1)
                {
                    ProcessStartInfo psInfo = new ProcessStartInfo();
                    psInfo.FileName = @"D:\Program Files\Lhaplus\Lhaplus.exe"; // 実行するファイル
                    if (dirPath.Equals(""))
                    {
                        psInfo.Arguments = "/c:zip /o:\"" + Path.GetDirectoryName(s[i]) + "\" \"" + s[i] + "\"";
                    }
                    else
                    {
                        psInfo.Arguments = "/c:zip /o:\"" + dirPath + "\" \"" + s[i] + "\"";
                    }

                    Process ps = Process.Start(psInfo);
                    ps.WaitForExit();
                    ps.Close();
                    ps.Dispose();
                }
            }

            s = null;
            Invoke(new SetCountDelegate(SetCount), 0, 0);
            Invoke(new SetAllowDropDelegate(SetAllowDrop), true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            dirPath = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "処理対象フォルダを選択してください";

                DialogResult dr = fbd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    textBox1.Text = fbd.SelectedPath;
                    dirPath = fbd.SelectedPath;
                }
                else
                {
                    checkBox1.Checked = false;
                    textBox1.Text = "";
                    dirPath = "";
                }
            }
            else if (checkBox1.Checked == false)
            {
                textBox1.Text = "";
                dirPath = "";
            }
        }
    }
}
