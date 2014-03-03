using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SketchieGemsV2
{
    public partial class SketchieGems : UserControl
    {
        private Bitmap[] m_tiles;
        private Point m_selected;
        private GemsCore m_gc;
        private Bitmap m_backBuffer;
        private bool m_redrawBackBuffer;
        private AnimationHandler m_animHandler;
        public event EventHandler GameOver;
                
        public int Rows { get { return m_gc == null ? 0 : m_gc.Rows; }
                          set { if ( m_gc != null ) m_gc.Rows = value; } }

        public int Cols { get { return m_gc == null ? 0 : m_gc.Cols; }
                          set { if ( m_gc != null ) m_gc.Cols = value; } }
                        
        public SketchieGems()
        {
            InitializeComponent();
            m_animHandler = new AnimationHandler(45);
            m_animHandler.Tick += new EventHandler(m_animHandler_Tick);
        }

        void m_animHandler_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        public void LoadTiles(string dir)
        {
            string[] files = Directory.GetFiles(dir, "*.png");
            m_tiles = new Bitmap[files.Length];
            for (int j = 0; j < m_tiles.Length; j++)
                m_tiles[j] = new Bitmap(files[j]);
            m_gc = new GemsCore(m_tiles.Length, 18,18);
            m_gc.SwapStart += new GemsCore.DManageTiles(m_gc_SwapStart);
            m_gc.SwapEnd += new GemsCore.DManageTiles(m_gc_SwapEnd);
            m_gc.GameOver += new EventHandler(m_gc_GameOver);
            m_gc.FallStart += new GemsCore.DTileAnimations(m_gc_FallStart);
        }

        void m_gc_FallStart(List<Tile> tiles)
        {
            foreach (Tile t in tiles)
            {
                Point t1 = new Point(t.tileLoc.X * m_tiles[0].Width, t.tileLoc.Y * m_tiles[0].Height);
                Point t2 = new Point(t.tileLoc.X * m_tiles[0].Width, (t.tileLoc.Y + 1) * m_tiles[0].Height);
                m_animHandler.Add(new Animation(m_tiles[t.tileInd], t1, t2, m_gc.FallSpeed));
            }
        }

        void m_gc_GameOver(object sender, EventArgs e)
        {
            if (GameOver != null)
                GameOver(null, null);
        }

        void m_gc_SwapEnd(Tile a, Tile b)
        {
            m_redrawBackBuffer = true;
            Invalidate();
        }

        void m_gc_SwapStart(Tile a, Tile b)
        {
            Point t1 = new Point(a.tileLoc.X * m_tiles[0].Width, a.tileLoc.Y * m_tiles[0].Height);
            Point t2 = new Point(b.tileLoc.X * m_tiles[0].Width, b.tileLoc.Y * m_tiles[0].Height);

            m_animHandler.Add(new Animation(m_tiles[a.tileInd], t2, t1, m_gc.SwapSpeed));
            m_animHandler.Add(new Animation(m_tiles[b.tileInd], t1, t2, m_gc.SwapSpeed));

            m_redrawBackBuffer = true;
            Invalidate();
        }

        private void DrawBackBuffer()
        {
            if (m_backBuffer == null)
                m_backBuffer = new Bitmap(m_tiles[0].Width * m_gc.Cols, m_tiles[0].Height * m_gc.Rows);

            Graphics g = Graphics.FromImage(m_backBuffer);
            g.Clear(Color.Black);

            int w = m_tiles[0].Width;
            int h = m_tiles[0].Height;

            for (int j = 0; j < m_gc.Rows; j++)
                for (int i = 0; i < m_gc.Cols; i++)
                    if (m_gc[i, j] != -1)
                        g.DrawImage(m_tiles[m_gc[i, j]], new Rectangle(i * w, j * h, w, h), 0, 0, m_tiles[m_gc[i, j]].Width, m_tiles[m_gc[i, j]].Height, GraphicsUnit.Pixel);
            m_redrawBackBuffer = false;
        }

        private void SketchieGems_Paint(object sender, PaintEventArgs e)
        {
            if (m_tiles != null)
            {
                Graphics g = e.Graphics;
                
                //if (m_backBuffer == null || m_redrawBackBuffer)
                    DrawBackBuffer();
                
                g.DrawImage(m_backBuffer, new Rectangle(0, 0, Width, Height), 0, 0, m_backBuffer.Width, m_backBuffer.Height, GraphicsUnit.Pixel);

                int w = Width / m_gc.Cols;
                int h = Height / m_gc.Rows;

                float ScaleW = (float)w / m_tiles[0].Width;
                float ScaleH = (float)h / m_tiles[0].Height;

                for (int i = 0; i < m_animHandler.Count; i++)
                    g.DrawImage(m_animHandler[i].bmp, new Rectangle((int)(m_animHandler[i].pos.X * ScaleW), (int)(m_animHandler[i].pos.Y * ScaleH), w, h), 0, 0, m_animHandler[i].bmp.Width, m_animHandler[i].bmp.Height, GraphicsUnit.Pixel);

                if (m_selected.X != -1)
                    g.DrawRectangle(Pens.White, new Rectangle(m_selected.X * Width / m_gc.Cols, m_selected.Y * Height / m_gc.Rows, Width / m_gc.Cols, Height /m_gc.Rows));
            }
        }

        private void SketchieGems_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.X >= 0 && e.X < Width && e.Y >= 0 & e.Y < Height)
            {
                //m_selected = new Point(e.X * m_cols / Width, e.Y * m_rows / Height);
                int x = e.X * m_gc.Cols / Width;
                int y = e.Y * m_gc.Rows / Height;
                if (m_selected.X == -1)
                {
                    m_selected = new Point(x, y);
                }
                else
                {
                    if (!m_gc.Swap(m_selected, new Point(x, y)))
                        m_selected = new Point(x, y);
                    else
                        m_redrawBackBuffer = true;

                }
            }
            Invalidate();
        }
    }

    struct Animation
    {
        public Bitmap bmp;
        public Point start;
        public Point end;
        public int duration;
        public Animation(Bitmap b, Point s, Point e, int d)
        {
            bmp = b;
            start = s;
            end = e;
            duration = d;
        }
    }

    struct AnimFrame
    {
        public Bitmap bmp;
        public Point pos;
        public AnimFrame(Bitmap b, Point p)
        {
            bmp = b;
            pos = p;
        }
    }

    class AnimationHandler
    {
        private List<Animation> m_anims;
        private List<int> m_starts;
        private List<AnimFrame> m_frames;
        private Timer m_t;
        public int Count { get { return m_frames.Count; } }
        public AnimFrame this[int i] { get { return m_frames[i]; } }
        public event EventHandler Tick;

        public AnimationHandler(int fps)
        {
            m_anims = new List<Animation>();
            m_starts = new List<int>();
            m_frames = new List<AnimFrame>();
            m_t = new Timer();
            m_t.Interval = 1000 / fps;
            m_t.Tick += new EventHandler(m_t_Tick);
        }

        void m_t_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < m_anims.Count; i++)
            {
                if (m_starts[i] + m_anims[i].duration < Environment.TickCount)
                {
                    m_starts.RemoveAt(i);
                    m_frames.RemoveAt(i);
                    m_anims.RemoveAt(i);
                    i--;
                    if (m_anims.Count <= 0)
                        m_t.Enabled = false;
                    continue; 
                }
                else
                {
                    float t = (Environment.TickCount - m_starts[i]) / (float)m_anims[i].duration;
                    int x = (int)((m_anims[i].end.X - m_anims[i].start.X) * t + m_anims[i].start.X);
                    int y = (int)((m_anims[i].end.Y - m_anims[i].start.Y) * t + m_anims[i].start.Y);
                    m_frames[i] = new AnimFrame(m_frames[i].bmp, new Point(x, y));
                }
            }
            if (Tick != null)
                Tick(sender, e);
        }
        public void Add(Animation a)
        {
            m_anims.Add(a);
            m_frames.Add(new AnimFrame(a.bmp, a.start));
            m_starts.Add(Environment.TickCount);
            if (!m_t.Enabled)
                m_t.Enabled = true;
        }
    }
}
