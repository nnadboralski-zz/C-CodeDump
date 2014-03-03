using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CrawlStats
{
    public partial class frmMain : Form
    {
        frmSettings Settings = new frmSettings();
        private CrawlCharacterList m_cList = new CrawlCharacterList();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            string host = CrawlStats.Properties.Settings.Default.HttpHost;
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            Settings.ShowDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbdAddDirectory.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                m_cList.AddDirectory(fbdAddDirectory.SelectedPath.ToString());
            }
            foreach (CrawlCharacter c in m_cList)
            {
                object[] row = new object[7];
                row[0] = c["v"];
                row[1] = c["name"];
                row[2] = Convert.ToInt32(c["xl"]);
                row[3] = c["race"];
                row[4] = c["cls"];
                row[5] = Convert.ToInt32(c["turn"]);
                row[6] = Convert.ToInt32(c["sc"]);
                dgCharacterList.Rows.Add(row);
                Application.DoEvents();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            m_cList.Sort();
            StreamWriter sw = new StreamWriter("index.html");
            sw.WriteLine(m_cList.ToHTML());
            sw.Close();
        }
    }
}