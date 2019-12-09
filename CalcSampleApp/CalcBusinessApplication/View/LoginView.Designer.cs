namespace CalcBusinessApplication.View
{
    partial class LoginView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label userIdLabel;
            this.loginViewDataBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.loginViewDataBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.loginButton = new System.Windows.Forms.Button();
            this.clientBizEventProcessWorker = new Terasoluna.Windows.Forms.Controls.EventProcessWorker(this.components);
            this.loginViewDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            passwordLabel = new System.Windows.Forms.Label();
            userIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loginViewDataBindingNavigator)).BeginInit();
            this.loginViewDataBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginViewDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // loginViewDataBindingNavigator
            // 
            this.loginViewDataBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.loginViewDataBindingNavigator.BindingSource = this.loginViewDataBindingSource;
            this.loginViewDataBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.loginViewDataBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.loginViewDataBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.loginViewDataBindingNavigatorSaveItem});
            this.loginViewDataBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.loginViewDataBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.loginViewDataBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.loginViewDataBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.loginViewDataBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.loginViewDataBindingNavigator.Name = "loginViewDataBindingNavigator";
            this.loginViewDataBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.loginViewDataBindingNavigator.Size = new System.Drawing.Size(323, 25);
            this.loginViewDataBindingNavigator.TabIndex = 0;
            this.loginViewDataBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "最初に移動";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "前に戻る";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 25);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "現在の場所";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目の総数";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "次に移動";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "最後に移動";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "新規追加";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "削除";
            // 
            // loginViewDataBindingNavigatorSaveItem
            // 
            this.loginViewDataBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loginViewDataBindingNavigatorSaveItem.Enabled = false;
            this.loginViewDataBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("loginViewDataBindingNavigatorSaveItem.Image")));
            this.loginViewDataBindingNavigatorSaveItem.Name = "loginViewDataBindingNavigatorSaveItem";
            this.loginViewDataBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.loginViewDataBindingNavigatorSaveItem.Text = "データの保存";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(25, 81);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(54, 12);
            passwordLabel.TabIndex = 1;
            passwordLabel.Text = "パスワード:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loginViewDataBindingSource, "Password", true));
            this.passwordTextBox.Location = new System.Drawing.Point(85, 78);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 19);
            this.passwordTextBox.TabIndex = 2;
            // 
            // userIdLabel
            // 
            userIdLabel.AutoSize = true;
            userIdLabel.Location = new System.Drawing.Point(31, 56);
            userIdLabel.Name = "userIdLabel";
            userIdLabel.Size = new System.Drawing.Size(48, 12);
            userIdLabel.TabIndex = 3;
            userIdLabel.Text = "ユーザID:";
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loginViewDataBindingSource, "UserId", true));
            this.userIdTextBox.Location = new System.Drawing.Point(85, 53);
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(100, 19);
            this.userIdTextBox.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.loginViewDataBindingSource;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(110, 103);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "ログイン";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // clientBizEventProcessWorker
            // 
            this.clientBizEventProcessWorker.BizLogicExecution = null;
            this.clientBizEventProcessWorker.EventProcessName = "FormLock";
            this.clientBizEventProcessWorker.LockControls = null;
            this.clientBizEventProcessWorker.RequestDataBuild = null;
            this.clientBizEventProcessWorker.ResponseDataReflection = null;
            this.clientBizEventProcessWorker.TargetControl = this;
            this.clientBizEventProcessWorker.ViewDataValidation = new Terasoluna.Windows.Forms.Events.ViewDataValidationInfo("RS01");
            // 
            // loginViewDataBindingSource
            // 
            this.loginViewDataBindingSource.DataSource = typeof(CalcBusinessApplication.ViewData.LoginViewData);
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 266);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(userIdLabel);
            this.Controls.Add(this.userIdTextBox);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginViewDataBindingNavigator);
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginView";
            this.Load += new System.EventHandler(this.LoginView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loginViewDataBindingNavigator)).EndInit();
            this.loginViewDataBindingNavigator.ResumeLayout(false);
            this.loginViewDataBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginViewDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource loginViewDataBindingSource;
        private System.Windows.Forms.BindingNavigator loginViewDataBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton loginViewDataBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button loginButton;
        private Terasoluna.Windows.Forms.Controls.EventProcessWorker clientBizEventProcessWorker;
    }
}