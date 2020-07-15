using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Renci.SshNet;
using System.Text.RegularExpressions;
using System.Reflection;
using NLog;
using NLog.Config;

namespace HqlCheck
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            // 引数チェック
            if (args.Length != 1 && args.Length != 2)
            {
                Console.WriteLine("使用方法: HqlCheck [HQLファイル] [テーブルチェックフラグ]");
                Console.WriteLine("[HQLファイル]は必須。対象のHQLファイル名を指定する");
                Console.WriteLine("[テーブルチェックフラグ]は、任意。0-テーブルチェックしない 1-テーブルチェックする(デフォルト)");
                return;
            }

            // ロガー設定
            logger.Factory.Configuration.Variables.Add("dt", DateTime.Now.ToString("yyyyMMddHHmmss"));
            logger.Factory.Configuration.Variables.Add("hqlfile", args[0]);
            logger.Factory.ReconfigExistingLoggers();

            // テーブルチェックフラグの設定
            bool tableCheckFlg = true;
            if (args.Length == 2 && args[1].Equals("0"))
            {
                tableCheckFlg = false;
            }

            // 接続情報作成
            ConnectionInfo info = createConnectionInfo();

            // クライアント作成
            SshClient ssh = new SshClient(info);

            // 接続開始
            ssh.Connect();
            if (!ssh.IsConnected)
            {
                // 接続に失敗した
                logger.Error("SSH接続に失敗");
                return;
            }

            // 接続に成功した
            logger.Info("SSH接続に成功");

            // Prefixを取得する
            string prefix = ConfigurationManager.AppSettings["Prefix"];

            // 指定されたHQL全体を読み込む
            StreamReader sr = new StreamReader(args[0], Encoding.GetEncoding("UTF-8"));
            string hqlStringOrg = sr.ReadToEnd();

            // テーブルの存在チェック
            // tableCheckFlgがfalseの場合は実行しない
            if (tableCheckFlg)
            {
                // hqlに含まれるテーブルを抽出
                List<string> tableList = extractionTableName(hqlStringOrg);

                // DDLテンプレートのパス
                string templatePath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).ToString() + "\\ddl_template";

                foreach (string tableName in tableList)
                {
                    // テーブル名にprefixを追加
                    logger.Info(prefix + tableName + " テーブルの存在チェックを開始");

                    // 実行コマンド組み立て
                    string commandString = "hive -e \"desc " + prefix + tableName + "\"";

                    // コマンド実行
                    CommandResult cr = executeCommand(ssh, commandString);

                    // テーブルがなかったら作成
                    if (cr.stdErr.Contains("Table not found"))
                    {
                        logger.Info(prefix + tableName + " テーブルが存在しないため作成");

                        // テンプレート読込
                        sr = new StreamReader(templatePath + "\\create_DEVXX_" + tableName + ".sql", Encoding.GetEncoding("UTF-8"));
                        string ddlString = sr.ReadToEnd();

                        // テンプレート編集
                        ddlString = ddlString.Replace("DEVXX_", prefix);

                        // テーブル作成コマンド組み立て
                        commandString = "hive -e \"" + ddlString + "\"";

                        // コマンド実行
                        cr = executeCommand(ssh, commandString);

                        // 戻り値確認してテーブル作成に失敗していたらエラー終了
                        if(cr.resultCd != 0)
                        {
                            logger.Error(prefix + tableName + " テーブルの作成に失敗");
                            logger.Error(cr.stdErr);

                            return;
                        }
                        logger.Info(prefix + tableName + " テーブルの作成に成功");
                    }
                    else
                    {
                        logger.Info(prefix + tableName + " テーブルが存在するため作成処理をスキップ");
                    }
                }
            }

            // パラメータの置換
            string hqlString = hqlStringOrg.Replace(":PRE_", prefix);
            hqlString = hqlString.Replace(":pt", "20200102030000");

            // :p1～:p20,:p01～:p20を置換
            for (int i = 0; i < 20; i++)
            {
                hqlString = hqlString.Replace(String.Format(":p{0}", i), i.ToString());
                hqlString = hqlString.Replace(String.Format(":p{0:00}", i), i.ToString());
            }

            logger.Info("メインHQLの実行開始");

            // HQL実行コマンド組み立て
            string hiveCommandString = "hive -e \"" + hqlString + "\"";

            // コマンド実行
            CommandResult result = executeCommand(ssh, hiveCommandString);

            logger.Info("メインHQL_戻値: " + result.resultCd);

            string logmsg = result.stdOut + result.stdErr;
            logger.Info("メインHQL_出力: " + logmsg.Trim());

            // 接続終了
            ssh.Disconnect();

            logger.Info("SSH切断");
        }

        static ConnectionInfo createConnectionInfo()
        {
            // 接続先のホスト名またはIPアドレス
            var hostNameOrIpAddr = ConfigurationManager.AppSettings["ServerIp"];

            // 接続先のポート番号
            var portNo = int.Parse(ConfigurationManager.AppSettings["ServerPort"]);

            // ログインユーザー名
            var userName = ConfigurationManager.AppSettings["userName"];

            // ログインパスワード
            var passWord = ConfigurationManager.AppSettings["Password"];

            // コネクション情報
            ConnectionInfo info = new ConnectionInfo(hostNameOrIpAddr, portNo, userName,
                new AuthenticationMethod[] {
                    new PasswordAuthenticationMethod(userName, passWord)
                    /* PrivateKeyAuthenticationMethod("キーの場所")を指定することでssh-key認証にも対応しています */
                }
            );

            string logmsg = String.Format("{0}:{1} {2}/*****", hostNameOrIpAddr, portNo, userName);
            logger.Info("ConnectionInfo: " + logmsg);

            return info;
        }

        static CommandResult executeCommand(SshClient ssh, string commandString)
        {
            logger.Debug("executeCommand:" + commandString);

            // コマンドを作成する
            SshCommand cmd = ssh.CreateCommand(commandString);

            // コマンドを実行する
            cmd.Execute();

            // 結果を変数に入れる
            CommandResult cr = new CommandResult();
            cr.stdOut = cmd.Result;
            cr.stdErr = cmd.Error;
            cr.resultCd = cmd.ExitStatus;

            return cr;
        }

        static List<string> extractionTableName(string hqlString)
        {
            List<string> tableList = new List<string>();

            Regex reg = new Regex(@":PRE_(?<name>[a-zA-Z0-9_]+)",
                RegexOptions.IgnoreCase | RegexOptions.None);

            for (Match m = reg.Match(hqlString); m.Success; m = m.NextMatch())
            {
                string tname = m.Groups["name"].Value;
                if (!tableList.Contains(tname)) {
                    tableList.Add(tname);
                    logger.Debug("TableList:" + tname);
                }
            }

            return tableList;
        }
    }
}
