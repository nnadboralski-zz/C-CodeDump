using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UberCatalogue
{
    static class Program
    {

        private static MusicCollection m_mc;
        public static MusicCollection MusicCollection { get { return m_mc; } }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            m_mc = new MusicCollection();
            Form1 form = new Form1();
            form.Show();          
            Application.Run(form);

        }
    }
}