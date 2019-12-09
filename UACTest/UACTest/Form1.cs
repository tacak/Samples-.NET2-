﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace UACTest
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        // 第2パラメータ：盾アイコンを設定するフラグ
        uint BCM_SETSHIELD = 0x0000160C;

        public Form1()
        {
            InitializeComponent();

            button1.FlatStyle = FlatStyle.System;
            HandleRef hwnd = new HandleRef(button1, button1.Handle);
            SendMessage(hwnd, BCM_SETSHIELD, new IntPtr(0), new IntPtr(1));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IsUAC=" + IsUAC().ToString());
            MessageBox.Show("IsAdministrator=" + IsAdministrator().ToString());

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.WorkingDirectory = Environment.CurrentDirectory;
            psi.FileName = @"C:\Windows\System32\notepad.exe";
            psi.Verb = "runas";

            Process.Start(psi);
        }

        private bool IsUAC()
        {
            OperatingSystem osInfo = Environment.OSVersion;
            if (osInfo.Platform == PlatformID.Win32NT)
            {
                if (osInfo.Version.Major == 6)
                {
                    if (osInfo.Version.Minor == 0)
                    {
                        // Windows Vista, Windows Server 2008
                        return true;
                    }
                    else if (osInfo.Version.Minor == 1)
                    {
                        // Windows 7, Windows Server 2008 R2
                        return true;
                    }
                }
                else if (osInfo.Version.Major > 6)
                {
                    // new Windows
                    return true;
                }
            }

            return false;
        }

        private bool IsAdministrator()
        {
            bool isAllowed = false;

            try
            {
                WindowsIdentity wi = WindowsIdentity.GetCurrent();
                WindowsPrincipal wp = new WindowsPrincipal(wi);
                isAllowed = wp.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                isAllowed = false;
            }

            return isAllowed;
        }
    }
}