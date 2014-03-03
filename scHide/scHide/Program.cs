using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace scHide
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            List<string> startApps = new List<string>();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
            foreach (string s in args)
            {
                if (s.Split(' ').Count() > 1)
                {

                }
                if (File.Exists(s))
                {
                    startApps.Add(s);
                }
            }
            foreach (string s in startApps)
            {
                ProcessStartInfo psi = new ProcessStartInfo(s);
                psi.RedirectStandardOutput = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process run;
                run = Process.Start(psi);
                System.IO.StreamReader myOutput = run.StandardOutput;
                //MessageBox.Show("Running " + s);
                run.WaitForExit(2000);
            }
        }
    }
}
