using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RenameMovie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = textBox1.Text;
            fbd.Description = "処理対象フォルダを選択してください";

            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
                textBox2.Text = fbd.SelectedPath + @"\title.txt";
                textBox3.Text = Path.GetFileName(fbd.SelectedPath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = textBox1.Text;
            ofd.Filter = "TXT ファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "開くファイルを選択してください";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo current = new DirectoryInfo(textBox1.Text);

            string title = "";
            using (StreamReader sr = new StreamReader(textBox2.Text, Encoding.GetEncoding("Shift_JIS")))
            {
                int cnt = 1;
                while ((title = sr.ReadLine()) != null)
                {
                    string work1 = cnt.ToString() + "wa.avi";
                    string work2 = cnt.ToString() + ".avi";
                    string work01 = "0" + cnt.ToString() + "wa.avi";
                    string work02 = "0" + cnt.ToString() + ".avi";
                    foreach (FileInfo file in current.GetFiles())
                    {
                        if (work1.Equals(file.Name) || work2.Equals(file.Name))
                        {
                            if (title.Equals(""))
                            {
                                File.Move(textBox1.Text + "\\" + file.Name, textBox1.Text + "\\" + textBox3.Text + " " + PreNum.Text + cnt.ToString("d2") + AfterNum.Text + ".avi");
                            }
                            else
                            {
                                File.Move(textBox1.Text + "\\" + file.Name, textBox1.Text + "\\" + textBox3.Text + " " + PreNum.Text + cnt.ToString("d2") + AfterNum.Text + "「" + title + "」.avi");
                            }
                            break;
                        }

                        if (work01.Equals(file.Name) || work02.Equals(file.Name))
                        {
                            if (title.Equals(""))
                            {
                                File.Move(textBox1.Text + "\\" + file.Name, textBox1.Text + "\\" + textBox3.Text + " " + PreNum.Text + cnt.ToString("d2") + AfterNum.Text + ".avi");
                            }
                            else
                            {
                                File.Move(textBox1.Text + "\\" + file.Name, textBox1.Text + "\\" + textBox3.Text + " " + PreNum.Text + cnt.ToString("d2") + AfterNum.Text + "「" + title + "」.avi");
                            }
                            break;
                        }
                    }
                    cnt++;
                }
                MessageBox.Show("終了しました");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
        }
    }
}