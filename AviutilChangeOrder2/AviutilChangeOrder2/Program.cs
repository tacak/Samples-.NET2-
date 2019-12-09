using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AviutilChangeOrder2
{
    class Program
    {
        static void Main(string[] args)
        {
            string strAvrutilIniPath = @".\aviutl99i8\aviutl.ini";
            string strNewAvrutilIniPath = @".\aviutl.ini";
            string buf;

            Console.Write("実行しますか？(y/n) ---> ");
            buf = Console.ReadLine();
            if (buf.CompareTo("y") != 0 && buf.CompareTo("Y") != 0)
            {
                return;
            }

            // Ini ファイルを開く
            StreamReader sr = new StreamReader(strAvrutilIniPath, Encoding.GetEncoding("shift_jis"));
            // Ini ファイルを作成する
            StreamWriter sw = new StreamWriter(strNewAvrutilIniPath, false, Encoding.GetEncoding("shift_jis"));

            //内容を一行ずつ読み込む
            while (sr.Peek() > -1)
            {
                buf = sr.ReadLine();
                if (buf.IndexOf("batchlist=") >= 0)
                {
                    string[] strData = buf.Split(new char[] { ',', '=' });

                    int len = strData.Length / 2;

                    sw.Write("batchlist=");
                    for (int i = 1; i <= len; i++)
                    {
                        sw.Write(strData[i]);
                        sw.Write(",");
                        sw.Write(strData[len + i]);
                        if (i != len)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();
                }
                else
                {
                    sw.WriteLine(buf);
                }
            }
            //閉じる
            sr.Close();
            sw.Close();

            File.Copy(strNewAvrutilIniPath, strAvrutilIniPath, true);
            File.Delete(strNewAvrutilIniPath);
        }
    }
}
