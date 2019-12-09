using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestFormApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateForm uf = new UpdateForm();
            uf.ShowDialog();

            MessageBox.Show("test", "test", MessageBoxButtons.YesNo);
        }
    }
}
