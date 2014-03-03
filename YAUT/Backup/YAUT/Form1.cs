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

/*                    string albumA = Albums[i].Title;
                    string albumB = Albums[j].Title;
                    albumA.Replace("(Disc ", "Disc ");
                    albumB.Replace("(Disc ", "Disc ");

                    while (albumA.IndexOf('[') != -1)
                    {
                        string[] splitA = albumA.Split('[');
                        albumA = splitA[0];
                    }
                    while (albumA.IndexOf('(') != -1)
                    {
                        string[] splitA = albumA.Split('(');
                        albumA = splitA[0];
                    }
                    while (albumB.IndexOf('[') != -1)
                    {
                        string[] splitB = albumB.Split('[');
                        albumB = splitB[0];
                    }
                    while (albumB.IndexOf('(') != -1)
                    {
                        string[] splitB = albumB.Split('(');
                        albumB = splitB[0];
                    }
                    albumA = albumA.Replace('-', ' ');
                    albumB = albumB.Replace('-', ' ');
                    albumA = albumA.ToLower();
                    albumB = albumB.ToLower();
                    albumA = albumA.Trim();
                    albumB = albumB.Trim();

                    Application.DoEvents();
                    if (Albums[i].Artist == Albums[j].Artist && albumA == albumB)
                        lstDupes.Items.Add(Albums[i].FPath + " - " + Albums[j].FPath);
 * */
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
                Albums.Add(new Album(dir));
                Application.DoEvents();
            }
        }
    }
}