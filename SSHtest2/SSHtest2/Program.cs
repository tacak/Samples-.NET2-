using System;
using System.Collections.Generic;
using System.Text;
using Renci.SshNet;
using System.IO;

namespace SSHtest2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionInfo ConnNfo = new ConnectionInfo("127.0.0.1", 22, "TacaK",
                new AuthenticationMethod[] { new PasswordAuthenticationMethod("TacaK", "tk5734") }
                );
            ConnNfo.Encoding = Encoding.GetEncoding("UTF-8");

            using (var sshclient = new SshClient(ConnNfo))
            {
                sshclient.Connect();
                var cmd = sshclient.CreateCommand("ping localhost");
                var asyncResult = cmd.BeginExecute();
                var stdoutStreamReader = new StreamReader(cmd.OutputStream, Encoding.GetEncoding("Shift-JIS"));
                var stderrStreamReader = new StreamReader(cmd.ExtendedOutputStream);

                while (!asyncResult.IsCompleted)
                {
                    var stdoutLine = stdoutStreamReader.ReadToEnd();

                    if (!string.IsNullOrEmpty(stdoutLine))
                    {
                        Console.Write(stdoutLine);
                    }

                    //var cmd2 = sshclient.CreateCommand("y");
                    //var ret = cmd2.Execute();
                    //Console.WriteLine(ret);
                }
                cmd.EndExecute(asyncResult);

                stdoutStreamReader.Close();
                stderrStreamReader.Close();

                cmd = sshclient.CreateCommand("ping localhost");
                asyncResult = cmd.BeginExecute();
                stdoutStreamReader = new StreamReader(cmd.OutputStream, Encoding.GetEncoding("Shift-JIS"));
                stderrStreamReader = new StreamReader(cmd.ExtendedOutputStream);

                while (!asyncResult.IsCompleted)
                {
                    var stdoutLine = stdoutStreamReader.ReadToEnd();

                    if (!string.IsNullOrEmpty(stdoutLine))
                    {
                        Console.Write(stdoutLine);
                    }
                }
                cmd.EndExecute(asyncResult);

                stdoutStreamReader.Close();
                stderrStreamReader.Close();
            }
            /*
            using (var sftp = new SftpClient(ConnNfo))
            {
                string uploadfn = @"C:\temp\test.txt";

                sftp.Connect();
                sftp.ChangeDirectory(@"C:\tmp\test2.txt");
                using (var uplfileStream = System.IO.File.OpenRead(uploadfn))
                {
                    sftp.UploadFile(uplfileStream, uploadfn, true);
                }
                sftp.Disconnect();
            } 
            */
            /*
            using (var sshclient = new SshClient(ConnNfo))
            {
                sshclient.Connect();
                using (var cmd = sshclient.CreateCommand("pwd"))
                {
                    string ret = cmd.Execute();
                    Console.WriteLine("Command>" + cmd.CommandText);
                    Console.WriteLine("Result>" + ret);
                    Console.WriteLine("Return Value = {0}", cmd.ExitStatus);
                }
                sshclient.Disconnect();
            }
             * */

            /*
            using (var sftp = new SftpClient(ConnNfo)){ 
                string uploadfn = "Renci.SshNet.dll"; 
  
                sftp.Connect(); 
                sftp.ChangeDirectory("/tmp/uploadtest"); 
                using (var uplfileStream = System.IO.File.OpenRead(uploadfn)){ 
                    sftp.UploadFile(uplfileStream, uploadfn, true); 
                } 
                sftp.Disconnect(); 
            } 
            */
            /*
            using (var sshclient = new SshClient(ConnNfo))
            {
                sshclient.Connect();

                    // quick way to use ist, but not best practice - SshCommand is not Disposed, ExitStatus not checked... 
                    Console.WriteLine(sshclient.CreateCommand("ls").Execute());
                    Console.WriteLine(sshclient.CreateCommand("ls").Execute());
                    //Console.WriteLine(sshclient.CreateCommand("cd /tmp/uploadtest && ls -lah").Execute()); 
                sshclient.Disconnect();
            }
             */ 
            Console.ReadKey(); 
            
        }
    }
}
