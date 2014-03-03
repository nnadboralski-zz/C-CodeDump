using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using Microsoft.Win32;

namespace fURL
{
    public partial class frmMain : Form
    {

        private string m_oHTTPOpen;
        private string m_oHTTPSOpen;
        private string m_oHTTPDDE;
        private string m_oHTTPSDDE;

        private RegistryKey m_httpOpen;
        private RegistryKey m_httpsOpen;
        private RegistryKey m_httpDDE;
        private RegistryKey m_httpsDDE;


        public frmMain()
        {
            m_httpOpen = Registry.ClassesRoot.OpenSubKey("http\\shell\\open\\command", true);
            m_httpsOpen = Registry.ClassesRoot.OpenSubKey("https\\shell\\open\\command", true);
            m_httpDDE = Registry.ClassesRoot.OpenSubKey("http\\shell\\open\\ddeexec", true);
            m_httpsDDE = Registry.ClassesRoot.OpenSubKey("https\\shell\\open\\ddeexec", true);

            m_oHTTPOpen = m_httpOpen.GetValue("").ToString();
            m_oHTTPSOpen = m_httpsOpen.GetValue("").ToString();
            m_oHTTPDDE = m_httpDDE.GetValue("").ToString();
            m_oHTTPSDDE = m_httpsDDE.GetValue("").ToString();

            InitializeComponent();
            niFurl.ContextMenu = cmFurl;
        }

        private void rbServer_CheckedChanged(object sender, EventArgs e)
        {
            txtHostname.Enabled = !rbServer.Checked;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            rbClient.Checked = Properties.Settings.Default.Client;
            rbServer.Checked = !(Properties.Settings.Default.Client);
            txtHostname.Enabled = !rbServer.Checked;
            txtHostname.Text = Properties.Settings.Default.Hostname;
            txtPort.Text = Properties.Settings.Default.Port.ToString();
            cbAutoMinimize.Checked = Properties.Settings.Default.Autominimize;
            cbAutoStart.Checked = Properties.Settings.Default.Autostart;
            if (cbAutoStart.Checked)
                StartUp();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                niFurl.Visible = true;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                ShowInTaskbar = true;
                niFurl.Visible = false;
            }
        }

        private void niFurl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
            ShowInTaskbar = true;
            niFurl.Visible = false;
        }

        private void StartUp()
        {
            SaveSettings();
            if (Properties.Settings.Default.Autominimize)
            {
                this.WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                niFurl.Visible = true;
            }

            btnStart.Enabled = false;
            txtHostname.Enabled = false;
            txtPort.Enabled = false;
            cbAutoMinimize.Enabled = false;
            cbAutoStart.Enabled = false;
            rbClient.Enabled = false;
            rbServer.Enabled = false;
            btnStop.Enabled = true;

            if (rbClient.Checked)
            {
                m_httpOpen.SetValue("", "\"" + Application.ExecutablePath + "\" " + Properties.Settings.Default.Hostname + " " + Properties.Settings.Default.Port + " %1", RegistryValueKind.String);
                m_httpsOpen.SetValue("", "\"" + Application.ExecutablePath + "\" " + Properties.Settings.Default.Hostname + " " + Properties.Settings.Default.Port + " %1", RegistryValueKind.String);
                m_httpDDE.SetValue("", "", RegistryValueKind.String);
                m_httpsDDE.SetValue("", "", RegistryValueKind.String);
            }
            else
            {
                TcpListener server = new TcpListener(Convert.ToInt32(Properties.Settings.Default.Port));
                server.Start();
                while (btnStop.Enabled)
                {
                    Application.DoEvents();
                    Thread.Sleep(250);
                    if (server.Pending())
                    {
                        Socket socket = server.AcceptSocket();
                        if (socket.Connected)
                        {
                            NetworkStream ns = new NetworkStream(socket);
                            StreamReader sr = new StreamReader(ns);
                            string url = sr.ReadLine();
                            Process.Start(url);
                            sr.Close();
                            ns.Close();
                            socket.Close();
                        }
                    }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartUp();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Client = rbClient.Checked;
            Properties.Settings.Default.Hostname = txtHostname.Text;
            Properties.Settings.Default.Port = txtPort.Text;
            Properties.Settings.Default.Autostart = cbAutoStart.Checked;
            Properties.Settings.Default.Autominimize = cbAutoMinimize.Checked;
            Properties.Settings.Default.Save();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rbClient.Checked)
                RestoreOriginalRegistry();
        }
        private void RestoreOriginalRegistry()
        {
            m_httpOpen.SetValue("", m_oHTTPOpen, RegistryValueKind.String);
            m_httpsOpen.SetValue("", m_oHTTPSOpen, RegistryValueKind.String);
            m_httpDDE.SetValue("", m_oHTTPDDE, RegistryValueKind.String);
            m_httpsDDE.SetValue("", m_oHTTPSDDE, RegistryValueKind.String);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (rbClient.Checked)
                RestoreOriginalRegistry();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            txtHostname.Enabled = true;
            txtPort.Enabled = true;
            cbAutoMinimize.Enabled = true;
            cbAutoStart.Enabled = true;
            rbClient.Enabled = true;
            rbServer.Enabled = true;
        }

        private void txtHostname_Click(object sender, EventArgs e)
        {
            txtHostname.Clear();
        }

        private void txtPort_Click(object sender, EventArgs e)
        {
            txtPort.Clear();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}