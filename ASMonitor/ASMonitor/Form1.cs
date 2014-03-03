using GameAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ASMonitor
{
    public partial class Form1 : Form
    {
        AudioSurf ASMonitor;
        string strSongTitle;
        string strArtistName;
        string strResult;
        int iScore = 0;
        int iPlayCount = 0;
        bool bSongFinished = false;
        bool bWindowShown = false;
        bool bPlurkSession = false;
        DateTime dtSongStart;
        TimeSpan tsSongDuration;
        TextWriter twASMLog;
        ProcessStartInfo psiPlurk;
        Process procPlurk;

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        public Form1()
        {
            InitializeComponent();
            ASMonitor = new AudioSurf();
            niASMIcon.ContextMenu = cmASMIcon;
            ShowWindowAsync(this.Handle, 0);
            bWindowShown = false;           
        }

        protected override void WndProc(ref Message m)
        {
            ASMonitor.HandleMessage(ref m);
            base.WndProc(ref m);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ASMonitor.AudioSurfStarted += new ThreadStart(ASMonitor_AudioSurfStarted);
            ASMonitor.WindowRegistered += new ThreadStart(ASMonitor_WindowRegistered);
            ASMonitor.AudioSurfClosed += new ThreadStart(ASMonitor_AudioSurfClosed);
            ASMonitor.NowPlayingArtistName += new AudioSurf.StringDelegate(ASMonitor_NowPlayingArtistName);
            ASMonitor.NowPlayingAshFile += new AudioSurf.StringDelegate(ASMonitor_NowPlayingAshFile);
            ASMonitor.NowPlayingSongTitle += new AudioSurf.StringDelegate(ASMonitor_NowPlayingSongTitle);
            ASMonitor.SongComplete += new AudioSurf.IntDelegate(ASMonitor_SongComplete);
            ASMonitor.OnCharacterScreen += new ThreadStart(ASMonitor_OnCharacterScreen);

            if (ASMonitor.AudioSurfRunning)
                ASMonitor.RegisterWindow(this, true);
        }

        void ASMonitor_AudioSurfStarted()
        {
            ASMonitor.RegisterWindow(this, true);
        }

        void ASMonitor_WindowRegistered()
        {
            mnuStatus.Text = "Registered";
        }

        void ASMonitor_AudioSurfClosed()
        {
            mnuStatus.Text = "Not Registered";
            if (bPlurkSession)
            {
                psiPlurk = new ProcessStartInfo();
                psiPlurk.FileName = "hstart.exe";
                psiPlurk.Arguments = "/NOWINDOW /WAIT \"CLP.bat Reply %5bFinished an Audiosurf session%5d\"";
                psiPlurk.UseShellExecute = false;
                procPlurk = Process.Start(psiPlurk);
                procPlurk.WaitForExit();
                procPlurk.Close();
                bPlurkSession = false;
            }
        }

        void ASMonitor_NowPlayingArtistName(string s)
        {
            strArtistName = s;
        }

        void ASMonitor_NowPlayingAshFile(string s)
        {
            bSongFinished = false;
            dtSongStart = DateTime.Now;
            iPlayCount++;
        }

        void ASMonitor_NowPlayingSongTitle(string s)
        {
            strSongTitle = s;
        }

        void ASMonitor_SongComplete(int i)
        {
            bSongFinished = true;
            iScore = i;
            strResult = "AS-JP:\"" + strArtistName + " - " + strSongTitle + "\" scoring " + iScore + " points.";
            tsSongDuration = TimeSpan.Parse((DateTime.Now - dtSongStart).ToString());
            if (mnuCopytoClipboard.Checked)
            {
                Clipboard.SetDataObject(strResult, true);
            }
            if (mnuLogtoFile.Checked)
            {               
                strResult = dtSongStart.ToString() + ":" + strArtistName + ":" + strSongTitle + ":" + tsSongDuration.Hours.ToString() + ":" + tsSongDuration.Minutes.ToString() + ":" + tsSongDuration.Seconds.ToString() + ":" + iScore;
                twASMLog = new StreamWriter("ASM_Log.txt", true);
                twASMLog.WriteLine(strResult);
                twASMLog.Flush();
                twASMLog.Close();
            }
            if (txtPlurkNickname.Text != "" && txtPlurkPassword.Text != "")
            {
                if (mnuPlurk.Checked)
                {
                    psiPlurk = new ProcessStartInfo();
                    psiPlurk.FileName = "hstart.exe";
                    psiPlurk.UseShellExecute = false;
                    psiPlurk.Arguments = "/NOWINDOW /WAIT \"CLP.bat Reply " + iPlayCount + ". %22" + strArtistName + " - " + strSongTitle + "%22 scored " + iScore + " points.";
                    procPlurk = Process.Start(psiPlurk);
                    procPlurk.WaitForExit(Timeout.Infinite);
                    if (procPlurk.ExitCode == 1)
                    {
                        MessageBox.Show("Something failed.");
                    }
                    procPlurk.Close();
                }
            }
        }

        void ASMonitor_OnCharacterScreen()
        {
            if (!bSongFinished)
                bSongFinished = true;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void niASMIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (bWindowShown)
            {
                bWindowShown = !bWindowShown;
                ShowWindowAsync(this.Handle, 0);
            }
            else
            {
                bWindowShown = !bWindowShown;
                ShowWindowAsync(this.Handle, 1);
            }
        }

        private void mnuCopytoClipboard_Click(object sender, EventArgs e)
        {
            mnuCopytoClipboard.Checked = !mnuCopytoClipboard.Checked;
        }

        private void mnuLogtoFile_Click(object sender, EventArgs e)
        {
            mnuLogtoFile.Checked = !mnuLogtoFile.Checked;
        }

        private void mnuPlurk_Click(object sender, EventArgs e)
        {
            mnuPlurk.Checked = !mnuPlurk.Checked;
            if (mnuPlurk.Checked == true && (txtPlurkNickname.Text == null || txtPlurkPassword.Text == null))
            {
                ShowWindowAsync(this.Handle, 1);
                bWindowShown = true;
            }
        }

        private void btnLogintoPlurk_Click(object sender, EventArgs e)
        {
            psiPlurk = new ProcessStartInfo();
            psiPlurk.FileName = "hstart.exe";
            psiPlurk.UseShellExecute = false;
            psiPlurk.Arguments = "/NOWINDOW /WAIT \"CLP.bat Login " + txtPlurkNickname.Text + " " + txtPlurkPassword.Text + " Post Another attempt... %5bStarted playing Audiosurf%5d\"";
            procPlurk = Process.Start(psiPlurk);
            procPlurk.WaitForExit(Timeout.Infinite);
            procPlurk.Close();
            bPlurkSession = true;
        }
    }
}