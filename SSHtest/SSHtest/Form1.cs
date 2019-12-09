using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Renci.SshNet;

namespace SSHtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionInfo ConnNfo = new ConnectionInfo("localhost",22,"tacak",
                new AuthenticationMethod[] { new PasswordAuthenticationMethod("tacak", "tk5734") }
            );
            /*
            using (var sshclient = new SshClient(ConnNfo))
            {
                sshclient.Connect();
                using (var cmd = sshclient.CreateCommand("mkdir -p /tmp/uploadtest && chmod +rw /tmp/uploadtest"))
                {
                    cmd.Execute();
                    Console.WriteLine("Command>" + cmd.CommandText);
                    Console.WriteLine("Return Value = {0}", cmd.ExitStatus);
                }
                sshclient.Disconnect();
            }

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
            using (var sshclient = new SshClient(ConnNfo)){ 
                sshclient.Connect(); 
  
                // quick way to use ist, but not best practice - SshCommand is not Disposed, ExitStatus not checked... 
                Console.WriteLine(sshclient.CreateCommand("pwd").Execute()); 
                Console.WriteLine(sshclient.CreateCommand("dir").Execute()); 
                //Console.WriteLine(sshclient.CreateCommand("cd /tmp/uploadtest && ls -lah").Execute()); 
                sshclient.Disconnect(); 
            } 
            Console.ReadKey(); 

        }
    }
}
