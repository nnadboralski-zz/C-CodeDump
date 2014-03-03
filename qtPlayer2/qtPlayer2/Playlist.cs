using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace qtPlayer2
{
    public partial class Playlist : UserControl
    {

        public delegate void TrackDelegate(Track t);
        public event TrackDelegate TrackSelected;
        private TrackList m_tl;
        private Color m_zebraA;
        private Color m_zebraB;
        private Color m_selectedColor;
        private Color m_playingColor;
        
        private Point m_mloc;    
        
        private int m_selectedInd;
        private int m_playingInd;
        
        public Color ZebraStripeColorA { get { return m_zebraA; } set { m_zebraA = value; picList.Invalidate();  } }
        public Color ZebraStripeColorB { get { return m_zebraB; } set { m_zebraB = value; picList.Invalidate();  } }
        public Color SelectedColor { get { return m_selectedColor; } set { m_selectedColor = value; picList.Invalidate(); } }
        public Color NowPlayingColor { get { return m_playingColor; } set { m_playingColor = value; picList.Invalidate(); } }

        public int SelectedIndex { get { return m_selectedInd; } set { m_selectedInd = value; picList.Invalidate(); } }
        public int CurrentlyPlayingIndex { get { return m_playingInd; } set { m_playingInd = value; picList.Invalidate(); } }

        public Track CurrentlyPlaying { get { return m_tl[m_playingInd]; } }
        public Track Selected { get { return m_tl[m_selectedInd]; } }

        public TrackList TrackList
        { 
            get 
            { 
                return m_tl;
            } 
            set
            { 
                if(value != null)
                {
                    m_tl = value;
                    m_tl.TrackUpdated += new TrackList.UpdateDelegate(m_tl_TrackUpdated);
                    UpdateScrollbar();
                    picList.Invalidate();
                }
            }
        }

        void m_tl_TrackUpdated(Track t)
        {
            if (InvokeRequired) Invoke(new TrackDelegate(m_tl_TrackUpdated), new object[] { t });
            int itemCount = picList.Height / Font.Height;
            int ind = m_tl.IndexOf(t);
            if (ind >= vs.Value && ind <= vs.Value + itemCount)
            {
                UpdateScrollbar();
                picList.Invalidate();
            }
        }

        public Playlist()
        {           
            InitializeComponent();
            m_playingInd = -1;
            m_selectedInd = -1;
            m_playingColor = SystemColors.HighlightText;
            m_selectedColor = SystemColors.Highlight;
            ForeColor = SystemColors.WindowText;
            m_zebraA = SystemColors.ControlDark;
            m_zebraB = SystemColors.ControlDark;
            this.MouseWheel += new MouseEventHandler(Playlist_MouseWheel);
        }

        public void NextSong()
        {            
            CurrentlyPlayingIndex++;
            if (CurrentlyPlayingIndex >= m_tl.Count)
                CurrentlyPlayingIndex = 0;
            SelectedIndex = CurrentlyPlayingIndex;
            if (vs.Enabled)
            {
                int itemCount = picList.Height / Font.Height;
                if (CurrentlyPlayingIndex < vs.Value)
                    vs.Value = CurrentlyPlayingIndex;
                if (CurrentlyPlayingIndex > vs.Value + itemCount - 1)
                {
                    vs.Value = CurrentlyPlayingIndex - itemCount + 1;
                }
            }
            UpdateScrollbar();
            picList.Invalidate();
        }

        public void RandomSong()
        {
            Random r = new Random();
            int rndNum = r.Next(m_tl.Count);
            int oldIndex = CurrentlyPlayingIndex;
            CurrentlyPlayingIndex = rndNum;
            SelectedIndex = rndNum;
            if (vs.Enabled)
            {
                int itemCount = picList.Height / Font.Height;
                if (CurrentlyPlayingIndex < vs.Value)
                    vs.Value = CurrentlyPlayingIndex;
                if (CurrentlyPlayingIndex > vs.Value + itemCount - 1)
                {
                    vs.Value = CurrentlyPlayingIndex - itemCount + 1;
                }
            }
            UpdateScrollbar();
            picList.Invalidate();
        }

        void Playlist_MouseWheel(object sender, MouseEventArgs e)
        {
            //I sense an if statement >.>;
            int newvalue = vs.Value - (e.Delta / 120);
            // or not.
            // there it is.
            if(newvalue < 0) newvalue = 0;
            // not quite what I expected :P
            if (newvalue > vs.Maximum - vs.LargeChange) newvalue = vs.Maximum - vs.LargeChange + 1;
            vs.Value = newvalue;
            picList.Invalidate();
        }
        
        private void UpdateScrollbar()
        {
            if (m_tl == null)
            {
                vs.Enabled = false;
                return;
            }
            int itemCount = picList.Height / Font.Height;
            if (itemCount > m_tl.Count)
            {
                vs.Enabled = false;
                return;
            }
            vs.Maximum = m_tl.Count - 1;
            vs.LargeChange = itemCount;
            if (vs.Value > vs.Maximum - vs.LargeChange) vs.Value = vs.Maximum - vs.LargeChange + 1;
            vs.Enabled = true;
        }

        private void picList_Paint(object sender, PaintEventArgs e)
        {
            if (m_tl == null) return;           
            int itemCount = picList.Height / Font.Height;
            // darn wizards.
            SolidBrush b = new SolidBrush(ForeColor);
            SolidBrush zsA = new SolidBrush(ZebraStripeColorA);
            SolidBrush zsB = new SolidBrush(ZebraStripeColorB);
            for (int i = 0; i < itemCount; i++)
            {
                if (i + vs.Value == m_selectedInd)
                {
                    e.Graphics.FillRectangle(new SolidBrush(SelectedColor), new Rectangle(0, i * Font.Height, picList.Width, Font.Height));
                }
                else 
                    e.Graphics.FillRectangle((((i+vs.Value)&1)==0)?zsA:zsB, new Rectangle(0,i*Font.Height,picList.Width,Font.Height));
                if (i + vs.Value < m_tl.Count)
                {
                    if (i + vs.Value == m_playingInd)
                    {
                        if (m_playingInd == m_selectedInd)
                        {
                            e.Graphics.DrawString("-> " + (i + vs.Value).ToString() + ". " + m_tl[i + vs.Value].ToString(), Font, new SolidBrush(Color.LightGreen), 0, (float)(i * Font.Height));
                        }
                        else
                        {
                            e.Graphics.DrawString("-> " + (i + vs.Value).ToString() + ". " + m_tl[i + vs.Value].ToString(), Font, new SolidBrush(Color.Green), 0, (float)(i * Font.Height));
                        }
                    }
                    else
                        e.Graphics.DrawString((i + vs.Value).ToString() + ". " + m_tl[i + vs.Value].ToString(), Font, b, 0, (float)(i * Font.Height));
                }
            }
        }

        private void vs_Scroll(object sender, ScrollEventArgs e)
        {
            picList.Invalidate();
        }

        private void Playlist_Resize(object sender, EventArgs e)
        {
            UpdateScrollbar();
            picList.Invalidate();
        }

        private void picList_SizeChanged(object sender, EventArgs e)
        {
            picList.Invalidate();
        }

        private void picList_MouseMove(object sender, MouseEventArgs e)
        {
            m_mloc = new Point(e.X, e.Y);
        }

        private void picList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int ind = m_mloc.Y / Font.Height;
                if (vs.Value + ind < m_tl.Count)
                {
                    SelectedIndex = vs.Value + ind;
                    CurrentlyPlayingIndex = vs.Value + ind;
                    if (TrackSelected != null)
                        TrackSelected(m_tl[vs.Value + ind]);
                }
            }

        }

        private void picList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int ind = m_mloc.Y / Font.Height;
                if (vs.Value + ind < m_tl.Count)
                    SelectedIndex = vs.Value + ind; // this one's right with that, right?
            }

        }
    }
}
