using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace hp_tac_4doug_flattenfolder
{
    public partial class frmFlatten : Form
    {
        List<string> fileList = new List<string>();
        public frmFlatten()
        {
            InitializeComponent();
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbdSource.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                txtSource.Text = fbdSource.SelectedPath;
            }
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbdDestination.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                txtDestination.Text = fbdDestination.SelectedPath;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            fileList.Clear();
            BuildFileList(txtSource.Text);
            MoveFiles();
        }

        private void MoveFiles()
        {
            foreach (string s in fileList)
            {
                File.Move(s, txtDestination.Text + "\\" + Path.GetFileName(s));
            }
        }

        private void BuildFileList(string folder)
        {
            foreach (string s in Directory.GetDirectories(folder))
            {
                BuildFileList(s);
            }
            foreach (string f in Directory.GetFiles(folder))
            {
                fileList.Add(f);
            }
        }
    }
}
