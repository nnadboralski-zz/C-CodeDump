using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace fURL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            else
            {
                TcpClient socket;
                try
                {
                    socket = new TcpClient(args[0],Convert.ToInt32(args[1]));
                }
                catch
                {
                    MessageBox.Show("Failed to connect to server at {0}:999", Properties.Settings.Default.Hostname);
                    return;
                }
                NetworkStream ns = socket.GetStream();
                StreamWriter sw = new StreamWriter(ns);
                try
                {
                    sw.WriteLine(args[2]);
                    sw.Flush();
                }
                catch
                {
                    MessageBox.Show("Obscure error message here.");
                }
                sw.Close();
                ns.Close();
            }
        }
    }
}