using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass;


namespace qtPlayer2
{
    public partial class qtPlayer : Form
    {
        int stream = -1;
        string curPlaying;
        bool IsAutoPlay = false;
        public bool IsPlaying { get { return (Bass.BASS_ChannelIsActive(stream) != BASSActive.BASS_ACTIVE_STOPPED); } }
        bool IsPaused = false;
        public qtPlayer(string[] args)
        {           
            InitializeComponent();
            this.ContextMenu = cmPlaylist;
            BassNet.Registration(@"magicword@xyzzy.com", "2X22391943422");
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero, null);
            int bf = Bass.BASS_PluginLoad("bassflac.dll");
            Bass.BASS_SetVolume((float)1);

            // MessageBox.Show(Bass.BASS_PluginGetInfo(bf).formats[0].exts);
            // MessageBox.Show(Bass.SupportedStreamExtensions);

            TrackList tl = new TrackList(); ;
            if (args.Length != 0)
            {
                {
                    tl = new TrackList(args, false);
                    IsAutoPlay = true;
                }
            }
            else
            {
                if (File.Exists("cache.qtPlaylist"))
                {
                    tl = new TrackList("cache.qtPlaylist", false);
                }
                else
                {
                    tl = new TrackList();
                }
            }
            playlist1.TrackList = tl;
            playlist1.TrackList.ReadTags();
            playlist1.TrackSelected += new Playlist.TrackDelegate(playlist1_TrackSelected);
            playlist1.TrackList.FinishedReading += new System.Threading.ThreadStart(TrackList_FinishedReading);
            if (IsAutoPlay)
                PlaySong(tl[0]);
        }

        void TrackList_FinishedReading()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            playlist1.TrackList.SaveCache(path + "\\" + "cache.qtPlaylist");
        }

        void playlist1_TrackSelected(Track t)
        {
            PlaySong(t);
        }

        private void PlaySong(Track t)
        {
            if (stream != -1)
            {               
                Bass.BASS_ChannelStop(stream);
                Bass.BASS_StreamFree(stream);
            }
            stream = Bass.BASS_StreamCreateFile(t.FilePath, 0, 0, BASSFlag.BASS_DEFAULT);

            // TAG_INFO tag = BassTags.BASS_TAG_GetFromFile(t.FullPath);
            
            Bass.BASS_ChannelPlay(stream, true);
            string[] wlm = { t.ToString() };
            WLMStatus.SetNPM(WLMStatus.NPMType.Music, wlm, "{0}", true);
            curPlaying = t.ToString();
            tmrSongPlayed.Enabled = true;
        }

        private void tmrSongPlayed_Tick(object sender, EventArgs e)
        {
            long len = Bass.BASS_ChannelGetLength(stream);
            long pos = Bass.BASS_ChannelGetPosition(stream);
            double totaltime = Bass.BASS_ChannelBytes2Seconds(stream, len);
            double elapsedtime = Bass.BASS_ChannelBytes2Seconds(stream, pos);           
            spbPlayed.Maximum = (int)(totaltime * 100);
            spbPlayed.Value = (int)(elapsedtime * 100);
            TimeSpan total = TimeSpan.FromSeconds((int)totaltime);
            TimeSpan elapsed = TimeSpan.FromSeconds((int)elapsedtime);
            //Text = curPlaying + " (" + Bass.BASS_GetVolume() + ")";
            
            if (IsPaused)
            {
                Text = curPlaying + " [Paused]";
            }
            
            else 
            { 
                Text = curPlaying;
            }
            
            spbPlayed.Text = elapsed.ToString() + "/" + total.ToString();
            if (!IsPlaying)
            {
                playlist1.NextSong();
                PlaySong(playlist1.CurrentlyPlaying);
            }
        }

        private void qtPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            playlist1.TrackList.SaveCache(path + "\\" + "cache.qtPlaylist");
            Bass.BASS_Free();
            playlist1.TrackList.StopReadingTags();
            string[] wlm = { "false" };
            WLMStatus.SetNPM(WLMStatus.NPMType.Music, wlm, "{0}", false);
        }

        private void mnuAddFolder_Click(object sender, EventArgs e)
        {           
            DialogResult dr = browse.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                //Stopwatch sw = Stopwatch.StartNew();
                playlist1.TrackList.AddDirectory(browse.SelectedPath);
                //sw.Stop();
                //Debug.WriteLine("Added songs in: " + sw.Elapsed.Seconds);
            }
            Invalidate();           
            playlist1.TrackList.ReadTags();
        }

        private void qtPlayer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                playlist1.RandomSong();
                PlaySong(playlist1.CurrentlyPlaying);
            }
            if (e.KeyCode == Keys.Space)
            {
                if (IsPaused)
                {
                    Bass.BASS_ChannelPlay(stream, false);
                    IsPaused = false;
                }
                else
                {
                    Bass.BASS_ChannelPause(stream);
                    IsPaused = true;
                } 
            }

            /*
            if (e.KeyCode == Keys.A)
            {
                float curVolume = Bass.BASS_GetVolume();
                curVolume += (float).1;
                Bass.BASS_SetVolume(curVolume);
            }
            if (e.KeyCode == Keys.Z)
            {
                float curVolume = Bass.BASS_GetVolume();
                curVolume -= (float).1;
                Bass.BASS_SetVolume(curVolume);
            }
            */
        }

        private void spbPlayed_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetProgressBarValue(e.Location.X);
            }
        }

        private double SetProgressBarValue(double mp)
        {
            double r = mp / spbPlayed.Width;
            double pbv = r * spbPlayed.Maximum;
            Bass.BASS_ChannelSetPosition(stream, pbv);
            spbPlayed.Value = (int)pbv;
            Bass.BASS_ChannelSetPosition(stream, (double)(spbPlayed.Value/100));
            return pbv;
        }

        private void spbPlayed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetProgressBarValue(e.Location.X);
            }
        }

        private void mnuClearPlaylist_Click(object sender, EventArgs e)
        {
            playlist1.TrackList = new TrackList();
            Invalidate();
        }

        private void mnuSavePlaylist_Click(object sender, EventArgs e)
        {
            DialogResult dr = sfdPlaylist.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                playlist1.TrackList.SaveCache(sfdPlaylist.FileName);
            }
        }

        private void mnuLoadPlaylist_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofdPlaylist.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                playlist1.TrackList = new TrackList(ofdPlaylist.FileName, false);
            }
        }
    }
}