using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Terasoluna.DataCopy;
using Terasoluna.Windows.ViewModel.Validation;
using Terasoluna.Windows.Forms.FormForward;
using Terasoluna.Windows.Forms.MessageNotification;
using Terasoluna.Windows.ViewModel;

// ViewDataクラスを作成後、正しい名前空間を指定しコメント化を解除して下さい。
using CalcBusinessApplication.ViewData;

namespace CalcBusinessApplication.View
{
    // ScreenIdが決定後、指定して下さい。
    [ScreenId("LoginView")]
    public partial class LoginView : Form
    {
        // ViewDataクラスを作成後、コメント化を解除して下さい。
        public LoginViewData ViewData { get; set; }

        public LoginView()
        {
            InitializeComponent();
            // ViewDataクラスを作成後、コメント化を解除して下さい。
            ViewData = ValidatableViewDataManager.CreateViewData<LoginViewData>();
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            // バインディングソース名が確定したら、修正後コメント化を解除して下さい。
            loginViewDataBindingSource.DataSource = ViewData;

            ViewData.UserId = "terasoluna";
            ViewData.Password = "password";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            clientBizEventProcessWorker.RunWorker();
        }
    }
}
