namespace BatchAutoTest
{
    partial class ConsoleView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.consoleMenu = new System.Windows.Forms.MenuStrip();
            this.menuAllClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCmdSend = new System.Windows.Forms.ToolStripMenuItem();
            this.shellWoker = new System.ComponentModel.BackgroundWorker();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.consoleMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // consoleMenu
            // 
            this.consoleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAllClear,
            this.menuClose,
            this.menuCmdSend});
            this.consoleMenu.Location = new System.Drawing.Point(0, 0);
            this.consoleMenu.Name = "consoleMenu";
            this.consoleMenu.Size = new System.Drawing.Size(753, 26);
            this.consoleMenu.TabIndex = 1;
            this.consoleMenu.Text = "menuStrip1";
            // 
            // menuAllClear
            // 
            this.menuAllClear.Name = "menuAllClear";
            this.menuAllClear.Size = new System.Drawing.Size(98, 22);
            this.menuAllClear.Text = "すべて消去(&C)";
            this.menuAllClear.Click += new System.EventHandler(this.menuAllClear_Click);
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(74, 22);
            this.menuClose.Text = "非表示(&X)";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // menuCmdSend
            // 
            this.menuCmdSend.Name = "menuCmdSend";
            this.menuCmdSend.Size = new System.Drawing.Size(110, 22);
            this.menuCmdSend.Text = "コマンド送信(&S)";
            this.menuCmdSend.Visible = false;
            this.menuCmdSend.Click += new System.EventHandler(this.menuCmdSend_Click);
            // 
            // shellWoker
            // 
            this.shellWoker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.shellWoker_DoWork);
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(0, 26);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(753, 391);
            this.txtConsole.TabIndex = 2;
            // 
            // ConsoleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 417);
            this.ControlBox = false;
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.consoleMenu);
            this.MainMenuStrip = this.consoleMenu;
            this.Name = "ConsoleView";
            this.Text = "ConsoleView";
            this.consoleMenu.ResumeLayout(false);
            this.consoleMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip consoleMenu;
        private System.Windows.Forms.ToolStripMenuItem menuAllClear;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.ToolStripMenuItem menuCmdSend;
        private System.ComponentModel.BackgroundWorker shellWoker;
        private System.Windows.Forms.TextBox txtConsole;


    }
}