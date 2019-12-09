namespace BatchAutoTest
{
    partial class BatchAutoTest
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsoleView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsoleAp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsoleDb = new System.Windows.Forms.ToolStripMenuItem();
            this.groupAp = new System.Windows.Forms.GroupBox();
            this.txtApPassword = new System.Windows.Forms.TextBox();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.txtApUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtApSshPort = new System.Windows.Forms.TextBox();
            this.cmbApServer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupDb = new System.Windows.Forms.GroupBox();
            this.txtDbSchemaPass = new System.Windows.Forms.TextBox();
            this.txtDbPassword = new System.Windows.Forms.TextBox();
            this.txtDbSid = new System.Windows.Forms.TextBox();
            this.txtDbSchema = new System.Windows.Forms.TextBox();
            this.txtDbUserName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDbPort = new System.Windows.Forms.TextBox();
            this.txtDbSshPort = new System.Windows.Forms.TextBox();
            this.cmbDbServer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupTask = new System.Windows.Forms.GroupBox();
            this.txtEndNo = new System.Windows.Forms.TextBox();
            this.txtStartNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkWarn = new System.Windows.Forms.CheckBox();
            this.listTasks = new System.Windows.Forms.ListView();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnLogDownload = new System.Windows.Forms.Button();
            this.btnTaskLoad = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.execWorker = new System.ComponentModel.BackgroundWorker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextTaskList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.選択項目を実行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ジョブリストを保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.groupAp.SuspendLayout();
            this.groupDb.SuspendLayout();
            this.groupTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.contextTaskList.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(895, 26);
            this.menuMain.TabIndex = 4;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ジョブリストを保存SToolStripMenuItem,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(85, 22);
            this.menuFile.Text = "ファイル(&F)";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(118, 22);
            this.menuExit.Text = "終了(&X)";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConsoleView});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(74, 22);
            this.menuView.Text = "ビュー(&V)";
            // 
            // menuConsoleView
            // 
            this.menuConsoleView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConsoleAp,
            this.menuConsoleDb});
            this.menuConsoleView.Name = "menuConsoleView";
            this.menuConsoleView.Size = new System.Drawing.Size(154, 22);
            this.menuConsoleView.Text = "コンソール(&C)";
            // 
            // menuConsoleAp
            // 
            this.menuConsoleAp.Name = "menuConsoleAp";
            this.menuConsoleAp.Size = new System.Drawing.Size(148, 22);
            this.menuConsoleAp.Text = "APサーバ(&A)";
            this.menuConsoleAp.Click += new System.EventHandler(this.menuConsoleAp_Click);
            // 
            // menuConsoleDb
            // 
            this.menuConsoleDb.Name = "menuConsoleDb";
            this.menuConsoleDb.Size = new System.Drawing.Size(148, 22);
            this.menuConsoleDb.Text = "DBサーバ(&D)";
            this.menuConsoleDb.Click += new System.EventHandler(this.menuConsoleDb_Click);
            // 
            // groupAp
            // 
            this.groupAp.Controls.Add(this.txtApPassword);
            this.groupAp.Controls.Add(this.txtLogPath);
            this.groupAp.Controls.Add(this.txtApUserName);
            this.groupAp.Controls.Add(this.label8);
            this.groupAp.Controls.Add(this.label12);
            this.groupAp.Controls.Add(this.label9);
            this.groupAp.Controls.Add(this.txtApSshPort);
            this.groupAp.Controls.Add(this.cmbApServer);
            this.groupAp.Controls.Add(this.label4);
            this.groupAp.Controls.Add(this.label2);
            this.groupAp.Location = new System.Drawing.Point(14, 30);
            this.groupAp.Name = "groupAp";
            this.groupAp.Size = new System.Drawing.Size(272, 141);
            this.groupAp.TabIndex = 6;
            this.groupAp.TabStop = false;
            this.groupAp.Text = "APサーバ情報";
            // 
            // txtApPassword
            // 
            this.txtApPassword.Location = new System.Drawing.Point(204, 66);
            this.txtApPassword.MaxLength = 256;
            this.txtApPassword.Name = "txtApPassword";
            this.txtApPassword.PasswordChar = '*';
            this.txtApPassword.Size = new System.Drawing.Size(62, 19);
            this.txtApPassword.TabIndex = 4;
            this.txtApPassword.Text = "tk5734";
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(62, 91);
            this.txtLogPath.MaxLength = 256;
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(204, 19);
            this.txtLogPath.TabIndex = 5;
            this.txtLogPath.Text = "/usr/local/sei19/log/batch";
            // 
            // txtApUserName
            // 
            this.txtApUserName.Location = new System.Drawing.Point(62, 66);
            this.txtApUserName.MaxLength = 256;
            this.txtApUserName.Name = "txtApUserName";
            this.txtApUserName.Size = new System.Drawing.Size(62, 19);
            this.txtApUserName.TabIndex = 3;
            this.txtApUserName.Text = "TacaK";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(148, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "SshPass";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "LogPath";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "Sshuser";
            // 
            // txtApSshPort
            // 
            this.txtApSshPort.Location = new System.Drawing.Point(62, 42);
            this.txtApSshPort.MaxLength = 5;
            this.txtApSshPort.Name = "txtApSshPort";
            this.txtApSshPort.Size = new System.Drawing.Size(62, 19);
            this.txtApSshPort.TabIndex = 2;
            this.txtApSshPort.Text = "22";
            this.txtApSshPort.Validating += new System.ComponentModel.CancelEventHandler(this.txtApSshPort_Validating);
            // 
            // cmbApServer
            // 
            this.cmbApServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApServer.FormattingEnabled = true;
            this.cmbApServer.Location = new System.Drawing.Point(62, 18);
            this.cmbApServer.Name = "cmbApServer";
            this.cmbApServer.Size = new System.Drawing.Size(117, 20);
            this.cmbApServer.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "SshPort";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "IpAddress";
            // 
            // groupDb
            // 
            this.groupDb.Controls.Add(this.txtDbSchemaPass);
            this.groupDb.Controls.Add(this.txtDbPassword);
            this.groupDb.Controls.Add(this.txtDbSid);
            this.groupDb.Controls.Add(this.txtDbSchema);
            this.groupDb.Controls.Add(this.txtDbUserName);
            this.groupDb.Controls.Add(this.label15);
            this.groupDb.Controls.Add(this.label14);
            this.groupDb.Controls.Add(this.label13);
            this.groupDb.Controls.Add(this.label10);
            this.groupDb.Controls.Add(this.label11);
            this.groupDb.Controls.Add(this.txtDbPort);
            this.groupDb.Controls.Add(this.txtDbSshPort);
            this.groupDb.Controls.Add(this.cmbDbServer);
            this.groupDb.Controls.Add(this.label3);
            this.groupDb.Controls.Add(this.label7);
            this.groupDb.Controls.Add(this.label6);
            this.groupDb.Location = new System.Drawing.Point(292, 30);
            this.groupDb.Name = "groupDb";
            this.groupDb.Size = new System.Drawing.Size(282, 141);
            this.groupDb.TabIndex = 7;
            this.groupDb.TabStop = false;
            this.groupDb.Text = "DBサーバ情報";
            // 
            // txtDbSchemaPass
            // 
            this.txtDbSchemaPass.Location = new System.Drawing.Point(208, 91);
            this.txtDbSchemaPass.MaxLength = 256;
            this.txtDbSchemaPass.Name = "txtDbSchemaPass";
            this.txtDbSchemaPass.PasswordChar = '*';
            this.txtDbSchemaPass.Size = new System.Drawing.Size(62, 19);
            this.txtDbSchemaPass.TabIndex = 11;
            this.txtDbSchemaPass.Text = "tk5734";
            // 
            // txtDbPassword
            // 
            this.txtDbPassword.Location = new System.Drawing.Point(208, 70);
            this.txtDbPassword.MaxLength = 256;
            this.txtDbPassword.Name = "txtDbPassword";
            this.txtDbPassword.PasswordChar = '*';
            this.txtDbPassword.Size = new System.Drawing.Size(62, 19);
            this.txtDbPassword.TabIndex = 9;
            this.txtDbPassword.Text = "tk5734";
            // 
            // txtDbSid
            // 
            this.txtDbSid.Location = new System.Drawing.Point(208, 113);
            this.txtDbSid.MaxLength = 256;
            this.txtDbSid.Name = "txtDbSid";
            this.txtDbSid.Size = new System.Drawing.Size(62, 19);
            this.txtDbSid.TabIndex = 13;
            this.txtDbSid.Text = "XE";
            // 
            // txtDbSchema
            // 
            this.txtDbSchema.Location = new System.Drawing.Point(62, 91);
            this.txtDbSchema.MaxLength = 256;
            this.txtDbSchema.Name = "txtDbSchema";
            this.txtDbSchema.Size = new System.Drawing.Size(62, 19);
            this.txtDbSchema.TabIndex = 10;
            this.txtDbSchema.Text = "tacak";
            // 
            // txtDbUserName
            // 
            this.txtDbUserName.Location = new System.Drawing.Point(62, 70);
            this.txtDbUserName.MaxLength = 256;
            this.txtDbUserName.Name = "txtDbUserName";
            this.txtDbUserName.Size = new System.Drawing.Size(62, 19);
            this.txtDbUserName.TabIndex = 8;
            this.txtDbUserName.Text = "TacaK";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(152, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 12);
            this.label15.TabIndex = 13;
            this.label15.Text = "DbSID";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(152, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "DbPass";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "DbUser";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(152, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "SshPass";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "SshUser";
            // 
            // txtDbPort
            // 
            this.txtDbPort.Location = new System.Drawing.Point(62, 113);
            this.txtDbPort.MaxLength = 5;
            this.txtDbPort.Name = "txtDbPort";
            this.txtDbPort.Size = new System.Drawing.Size(62, 19);
            this.txtDbPort.TabIndex = 12;
            this.txtDbPort.Text = "1521";
            this.txtDbPort.Validating += new System.ComponentModel.CancelEventHandler(this.txtDbPort_Validating);
            // 
            // txtDbSshPort
            // 
            this.txtDbSshPort.Location = new System.Drawing.Point(62, 46);
            this.txtDbSshPort.MaxLength = 5;
            this.txtDbSshPort.Name = "txtDbSshPort";
            this.txtDbSshPort.Size = new System.Drawing.Size(62, 19);
            this.txtDbSshPort.TabIndex = 7;
            this.txtDbSshPort.Text = "22";
            this.txtDbSshPort.Validating += new System.ComponentModel.CancelEventHandler(this.txtDbSshPort_Validating);
            // 
            // cmbDbServer
            // 
            this.cmbDbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDbServer.FormattingEnabled = true;
            this.cmbDbServer.Location = new System.Drawing.Point(62, 18);
            this.cmbDbServer.Name = "cmbDbServer";
            this.cmbDbServer.Size = new System.Drawing.Size(127, 20);
            this.cmbDbServer.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "IpAddress";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "DbPort";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "SshPort";
            // 
            // groupTask
            // 
            this.groupTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTask.Controls.Add(this.txtEndNo);
            this.groupTask.Controls.Add(this.txtStartNo);
            this.groupTask.Controls.Add(this.label5);
            this.groupTask.Controls.Add(this.label1);
            this.groupTask.Controls.Add(this.chkWarn);
            this.groupTask.Controls.Add(this.listTasks);
            this.groupTask.Controls.Add(this.btnConnect);
            this.groupTask.Controls.Add(this.btnExecute);
            this.groupTask.Controls.Add(this.btnLogDownload);
            this.groupTask.Controls.Add(this.btnTaskLoad);
            this.groupTask.Location = new System.Drawing.Point(14, 177);
            this.groupTask.Name = "groupTask";
            this.groupTask.Size = new System.Drawing.Size(869, 373);
            this.groupTask.TabIndex = 9;
            this.groupTask.TabStop = false;
            this.groupTask.Text = "ジョブ情報";
            // 
            // txtEndNo
            // 
            this.txtEndNo.Location = new System.Drawing.Point(254, 13);
            this.txtEndNo.MaxLength = 9;
            this.txtEndNo.Name = "txtEndNo";
            this.txtEndNo.Size = new System.Drawing.Size(62, 19);
            this.txtEndNo.TabIndex = 15;
            this.txtEndNo.Text = "99999";
            this.txtEndNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtEndNo_Validating);
            // 
            // txtStartNo
            // 
            this.txtStartNo.Location = new System.Drawing.Point(89, 15);
            this.txtStartNo.MaxLength = 9;
            this.txtStartNo.Name = "txtStartNo";
            this.txtStartNo.Size = new System.Drawing.Size(62, 19);
            this.txtStartNo.TabIndex = 14;
            this.txtStartNo.Text = "1";
            this.txtStartNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartNo_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "実行終了項番";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "実行開始項番";
            // 
            // chkWarn
            // 
            this.chkWarn.AutoSize = true;
            this.chkWarn.Location = new System.Drawing.Point(340, 14);
            this.chkWarn.Name = "chkWarn";
            this.chkWarn.Size = new System.Drawing.Size(134, 16);
            this.chkWarn.TabIndex = 16;
            this.chkWarn.Text = "警告終了でも続行する";
            this.chkWarn.UseVisualStyleBackColor = true;
            // 
            // listTasks
            // 
            this.listTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listTasks.ContextMenuStrip = this.contextTaskList;
            this.listTasks.Location = new System.Drawing.Point(6, 79);
            this.listTasks.Name = "listTasks";
            this.listTasks.Size = new System.Drawing.Size(855, 288);
            this.listTasks.TabIndex = 21;
            this.listTasks.UseCompatibleStateImageBehavior = false;
            this.listTasks.View = System.Windows.Forms.View.Details;
            this.listTasks.DoubleClick += new System.EventHandler(this.listTasks_DoubleClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnConnect.Location = new System.Drawing.Point(645, 13);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(105, 60);
            this.btnConnect.TabIndex = 17;
            this.btnConnect.Text = "サーバ接続";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Enabled = false;
            this.btnExecute.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExecute.Location = new System.Drawing.Point(756, 13);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(105, 60);
            this.btnExecute.TabIndex = 18;
            this.btnExecute.Text = "テスト実行開始";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnLogDownload
            // 
            this.btnLogDownload.Location = new System.Drawing.Point(137, 49);
            this.btnLogDownload.Name = "btnLogDownload";
            this.btnLogDownload.Size = new System.Drawing.Size(111, 23);
            this.btnLogDownload.TabIndex = 20;
            this.btnLogDownload.Text = "ログ一括収集";
            this.btnLogDownload.UseVisualStyleBackColor = true;
            this.btnLogDownload.Click += new System.EventHandler(this.btnLogDownload_Click);
            // 
            // btnTaskLoad
            // 
            this.btnTaskLoad.Location = new System.Drawing.Point(8, 50);
            this.btnTaskLoad.Name = "btnTaskLoad";
            this.btnTaskLoad.Size = new System.Drawing.Size(111, 23);
            this.btnTaskLoad.TabIndex = 19;
            this.btnTaskLoad.Text = "タスクリスト読み込み";
            this.btnTaskLoad.UseVisualStyleBackColor = true;
            this.btnTaskLoad.Click += new System.EventHandler(this.btnTaskLoad_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblStatus.Location = new System.Drawing.Point(580, 39);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(190, 33);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "テスト実行中";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(586, 79);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(289, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // execWorker
            // 
            this.execWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.execWorker_DoWork);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // contextTaskList
            // 
            this.contextTaskList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.選択項目を実行ToolStripMenuItem,
            this.編集ToolStripMenuItem});
            this.contextTaskList.Name = "contextMenuStrip1";
            this.contextTaskList.Size = new System.Drawing.Size(161, 48);
            // 
            // 選択項目を実行ToolStripMenuItem
            // 
            this.選択項目を実行ToolStripMenuItem.Name = "選択項目を実行ToolStripMenuItem";
            this.選択項目を実行ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.選択項目を実行ToolStripMenuItem.Text = "選択項目を実行";
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.編集ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.編集ToolStripMenuItem.Text = "編集";
            // 
            // ジョブリストを保存SToolStripMenuItem
            // 
            this.ジョブリストを保存SToolStripMenuItem.Name = "ジョブリストを保存SToolStripMenuItem";
            this.ジョブリストを保存SToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.ジョブリストを保存SToolStripMenuItem.Text = "ジョブリストを保存(&S)";
            // 
            // BatchAutoTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 562);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupTask);
            this.Controls.Add(this.groupDb);
            this.Controls.Add(this.groupAp);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "BatchAutoTest";
            this.Text = "バッチ自動テスト";
            this.Load += new System.EventHandler(this.BatchAutoTest_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.groupAp.ResumeLayout(false);
            this.groupAp.PerformLayout();
            this.groupDb.ResumeLayout(false);
            this.groupDb.PerformLayout();
            this.groupTask.ResumeLayout(false);
            this.groupTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.contextTaskList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuConsoleView;
        private System.Windows.Forms.GroupBox groupAp;
        private System.Windows.Forms.TextBox txtApPassword;
        private System.Windows.Forms.TextBox txtApUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtApSshPort;
        private System.Windows.Forms.ComboBox cmbApServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupDb;
        private System.Windows.Forms.TextBox txtDbPassword;
        private System.Windows.Forms.TextBox txtDbUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDbPort;
        private System.Windows.Forms.TextBox txtDbSshPort;
        private System.Windows.Forms.ComboBox cmbDbServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupTask;
        private System.Windows.Forms.ListView listTasks;
        private System.Windows.Forms.Button btnTaskLoad;
        private System.Windows.Forms.TextBox txtStartNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkWarn;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLogDownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker execWorker;
        private System.Windows.Forms.ToolStripMenuItem menuConsoleAp;
        private System.Windows.Forms.ToolStripMenuItem menuConsoleDb;
        private System.Windows.Forms.TextBox txtDbSchemaPass;
        private System.Windows.Forms.TextBox txtDbSchema;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtEndNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDbSid;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip contextTaskList;
        private System.Windows.Forms.ToolStripMenuItem 選択項目を実行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ジョブリストを保存SToolStripMenuItem;
    }
}

