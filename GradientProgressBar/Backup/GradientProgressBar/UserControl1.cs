using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace GradientProgressBar
{
    public partial class GradientProgressBar : UserControl
    {
        private int m_min = 0;
        private int m_max = 100;
        private int m_value = 0;
        private int m_percent = 0;

        private Color m_barFGColor = Color.LightSeaGreen;
        private Color m_barBGColor = Color.DimGray;
        private Color m_lblFGColor = Color.LightSeaGreen;
        private Color m_lblBGColor = Color.DimGray;

        private LinearGradientMode m_gradientMode = LinearGradientMode.ForwardDiagonal;

        private bool m_dispLabel = true;
        private System.Windows.Forms.Label lblGrdPrgsBar;
        private Point m_lblPos;

        public int Minimum 
        { 
            get 
            { 
                return m_min; 
            } 
            set 
            {
                if ((value < 0))
                    m_min = 0;
                if ((value > m_max))
                    m_min = value;
                if ((m_value < m_min))
                    m_value = m_min;
                this.Invalidate();           
            } 
        }
        public int Maximum 
        { 
            get 
            { 
                return m_max;
            } 
            set 
            {
                if ((value < m_min))
                    m_min = value;
                m_max = value;
                if ((m_value > m_max))
                    m_value = m_max;
                this.Invalidate();
            } 
        }
        public int Value
        { 
            get 
            { 
                return m_value;
            } 
            set 
            {
                int m_oldValue = m_value;
                if ((value < m_min))
                    m_value = m_min;
                else if ((value > m_max))
                    m_value = m_max;
                else
                    m_value = value;
                int m_curPercent;
                
                Rectangle m_newRect = this.ClientRectangle;
                Rectangle m_oldRect = this.ClientRectangle;
                
                m_curPercent = (m_value - m_min) / (m_max - m_min);
                m_newRect.Width = (m_newRect.Width * m_curPercent);
                m_curPercent = (m_oldValue - m_min) / (m_max - m_min);
                m_oldRect.Width = (m_oldRect.Width * m_curPercent);

                Rectangle m_updatedRect = new Rectangle();

                if ((m_newRect.Width > m_oldRect.Width))
                {
                    m_updatedRect.X = m_oldRect.Size.Width;
                    m_updatedRect.Width = m_newRect.Width - m_oldRect.Width;
                }
                else
                {
                    m_updatedRect.X = m_newRect.Size.Width;
                    m_updatedRect.Width = m_oldRect.Width - m_newRect.Width;
                }
                this.Invalidate(m_updatedRect);
            }
        }
        public int Percent 
        { 
            get 
            { 
                return m_percent;
            }
            set
            {
                m_percent = m_percent + value;
                if (m_percent > m_max)
                {
                    m_percent = 0;
                    this.Invalidate();
                }
            } 
        }
        public LinearGradientMode GradientStyle { get { return m_gradientMode; } set { m_gradientMode = value; } }


        public GradientProgressBar()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);


        }

        public void SetProgComplete(int percentage)
        {
            int Width = (int)Math.Floor((double)((this.ClientRectangle.Width * percentage) / 100));
            int Height = (int)this.ClientRectangle.Height;

            if (Width > 0 && Height > 0)
            {
                this.Invalidate(new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, Width, Height));
                lblGrdPrgBar.Text = Percent.ToString() + "%";
            }
        }

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (e.ClipRectangle.Width > 0)
            {
                LinearGradientBrush m_barBG = new LinearGradientBrush(e.ClipRectangle, m_barBGColor, m_barFGColor, LinearGradientMode.BackwardDiagonal);
                e.Graphics.FillRectangle(m_barBG, e.ClipRectangle);
            }
        }
    }
}