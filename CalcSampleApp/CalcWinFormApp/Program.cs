using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Terasoluna;
using Terasoluna.Windows.Forms;
using Terasoluna.ExceptionHandling;

namespace CalcWinFormApp
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ///TerasolunaStartupForm継承クラスによるフレームワークの起動処理
            ///TerasolunaBootstrap.configに設定した初期表示画面を起動する
            Application.Run(new StartupForm());

        }

        /// <summary>
        /// システムエラーの集約例外ハンドリング処理
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                ExceptionManager.HandleException(exception, "AppDomainUnhandledFailure");
            }

        }

        /// <summary>
        /// システムエラーの集約例外ハンドリング処理
        /// </summary>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ExceptionManager.HandleException(e.Exception, "ApplicationThreadFailure");
        }
    }
}
