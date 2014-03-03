using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CrawlStats
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Shown(object sender, EventArgs e)
        {
            txtFtpHost.Text = CrawlStats.Properties.Settings.Default.FtpHost;
            txtFtpPort.Text = CrawlStats.Properties.Settings.Default.FtpPort;
            txtFtpUsername.Text = CrawlStats.Properties.Settings.Default.FtpUsername;
            txtFtpPassword.Text = CrawlStats.Properties.Settings.Default.FtpPassword;
            txtHttpHost.Text = CrawlStats.Properties.Settings.Default.HttpHost;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            CrawlStats.Properties.Settings.Default.FtpHost = txtFtpHost.Text;
            CrawlStats.Properties.Settings.Default.FtpPort = txtFtpPort.Text;
            CrawlStats.Properties.Settings.Default.FtpUsername = txtFtpUsername.Text;
            CrawlStats.Properties.Settings.Default.FtpPassword = txtFtpPassword.Text;
            CrawlStats.Properties.Settings.Default.HttpHost = txtHttpHost.Text;
            CrawlStats.Properties.Settings.Default.Save();
        }
    }
}