using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace hp_tac_tk_preparse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                lstFiles.Items.Add(Path.GetFileName(file) + " being proccessed.");
                try
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        String line;
                        String OutPath = Application.StartupPath + "\\Processed\\" + Path.GetFileName(file);
                        if (!Directory.Exists(Application.StartupPath + "\\Processed\\"))
                        {
                            Directory.CreateDirectory(Application.StartupPath + "\\Processed\\");
                        }
                        
                        StreamWriter sw = new StreamWriter(OutPath);
                        while ((line = sr.ReadLine()) != null)
                        {
                            line = System.Text.RegularExpressions.Regex.Replace(line, @"\s{2,}", " ");
                            line = Regex.Replace(line, @"\u00A0", " ");
                            sw.WriteLine(line);
                        }
                        sw.Flush();
                        sw.Close();
                        lstFiles.Items.Add(Path.GetFileName(file) + " written to Processed folder.");
                    }                 
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error while reading files: " + x.ToString());
                }
            }
        }
        /*
        public void GetFileList(string baseDir)
        {
            string[] dirs = Directory.GetDirectories(baseDir);
            foreach (string d in dirs)
            {
                GetFileList(d);
                UpdateLog("Scanning folder: " + d);
            }
            string[] files = Directory.GetFiles(baseDir, "*.csv");
            foreach (string f in files)
            {
                m_files.Add(f);
                UpdateLog("Gathering files: " + f);
            }
            files = Directory.GetFiles(baseDir, "*.xls");
            foreach (string f in files)
            {
                m_files.Add(f);
                UpdateLog("Gathering files: " + f);
            }
        }
         */

        private void pbSheep_Click(object sender, EventArgs e)
        {

        }
    }
}
