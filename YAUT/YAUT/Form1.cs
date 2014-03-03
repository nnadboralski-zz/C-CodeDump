using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace YAUT
{
    public partial class frmMain : Form
    {
        private List<Album> Albums = new List<Album>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbdFolder.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                txtFolder.Text = fbdFolder.SelectedPath.ToString();
                ParseDir(txtFolder.Text);               
            }
            lblStatus.Text = "Done.";
            //foreach (Album alb in Albums)
            //{ }
            for (int i = 0; i < Albums.Count; i++)
            {
                for (int j = i + 1; j < Albums.Count; j++)
                {
                    string hashA = Albums[i].Hash;
                    string hashB = Albums[j].Hash;

                    if (hashA == hashB)
                        lstDupes.Items.Add(Albums[i].FPath + " - " + Albums[j].FPath);

                }
            }

        }

        private void ParseDir(string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);
            foreach (string d in dirs)
                ParseDir(d);
            if (Directory.GetFiles(dir, "*.mp3").Length != 0)
            {
                lblStatus.Text = "Scanning " + dir;
                Albums.Add(new Album(dir));
                Application.DoEvents();
            }
        }
    }
}