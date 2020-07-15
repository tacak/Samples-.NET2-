using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Renci.SshNet;
using System.Text.RegularExpressions;
using System.Reflection;

namespace HqlCheck
{
    class Program
    {
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
                Console.WriteLine("SSH接続に失敗しました");
                return;
            }

            // 接続に成功した
            Console.WriteLine("SSH接続しました");

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

                Console.WriteLine("■テーブルの存在チェック");
                foreach (string tableName in tableList)
                {
                    // テーブル名にprefixを追加
                    Console.Write(prefix + tableName + " : ");

                    // 実行コマンド組み立て
                    string commandString = "hive -e \"desc " + prefix + tableName + "\"";
                    // コマンド実行
                    CommandResult cr = executeCommand(ssh, commandString);

                    // テーブルがなかったら作成
                    if (cr.stdErr.Contains("Table not found"))
                    {
                        Console.WriteLine("テーブルが存在しないため作成します");

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
                            Console.WriteLine(prefix + tableName + "テーブルの作成に失敗しました");
                            Console.WriteLine(cr.stdErr);

                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("OK");
                    }
                }
            }

            // パラメータの置換
            string hqlString = hqlStringOrg.Replace(":PRE_", prefix);
            hqlString = hqlString.Replace(":pt", "20200102030000");

            for (int i = 0; i < 20; i++)
            {
                hqlString = hqlString.Replace(String.Format(":p{0}", i), i.ToString());
                hqlString = hqlString.Replace(String.Format(":p{0:00}", i), i.ToString());
            }

            Console.WriteLine("■HQL実行");

            // HQL実行コマンド組み立て
            string hiveCommandString = "hive -e \"" + hqlString + "\"";

            // コマンド実行
            CommandResult result = executeCommand(ssh, hiveCommandString);

            Console.WriteLine("■実行結果");
            Console.WriteLine("戻り値：");
            Console.WriteLine(result.resultCd);
            Console.WriteLine();
            Console.WriteLine("出力：");
            Console.WriteLine(result.stdOut);
            Console.WriteLine(result.stdErr);

            // 接続終了
            ssh.Disconnect();
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

            return info;
        }

        static CommandResult executeCommand(SshClient ssh, string commandString)
        {
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
                }
            }

            return tableList;
        }
    }
}
