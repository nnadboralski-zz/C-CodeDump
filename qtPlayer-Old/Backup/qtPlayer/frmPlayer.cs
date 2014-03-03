using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace qtPlayer
{
    public partial class frmPlayer : Form
    {
        public frmPlayer()
        {
            InitializeComponent();
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
        }

        private void frmPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Location = this.Location;
            Properties.Settings.Default.Save();
        }

        private void frmPlayer_Load(object sender, EventArgs e)
        {
            this.Location = Properties.Settings.Default.Location;
        }
    }
}