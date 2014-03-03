using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace Plurky
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        bool bWindowShown;
        string strPlurkNickname;
        string strPlurkPassword;

        public Form1()
        {
            InitializeComponent();
            niPlurk.ContextMenu = cmPlurkIcon;
            ShowWindowAsync(this.Handle, 0);
            bWindowShown = false;
        }

        private void txtPlurk_TextChanged(object sender, EventArgs e)
        {
            int iCharsLeft;
            iCharsLeft = 140 - txtPlurk.Text.Length;
            lblCharCount.Text = iCharsLeft.ToString();
            if (iCharsLeft < 0)
            {
                btnPost.Enabled = false;
            }
            else
            {
                btnPost.Enabled = true;
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void niPlurk_DoubleClick(object sender, EventArgs e)
        {
            if (bWindowShown)
            {
                ShowWindowAsync(this.Handle,0);
                bWindowShown = false;
            }
            else
            {
                ShowWindowAsync(this.Handle, 1);
                bWindowShown = true;
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (strPlurkNickname == null || strPlurkPassword == null)
            {
                new PlurkUserInfo().ShowDialog();
            }
        }
    }
}