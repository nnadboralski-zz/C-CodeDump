using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmoothProgressBar
{
    public enum FillMode
    {
        LEFT_TO_RIGHT,
        RIGHT_TO_LEFT,
        TOP_TO_BOTTOM,
        BOTTOM_TO_TOP
    }
    public partial class SmoothProgressBar : UserControl
    {
        private long m_min;
        private long m_max;
        private long m_value;
        private FillMode m_fillMode;
        
        private string m_text;

        private Color m_txtColor;

        public long Minimum
        { 
            get 
            { 
                return m_min;
            } 
            set 
            {
                m_min = value;
                if (m_min > m_max)
                    m_min = m_max;
                if (m_value < m_min)
                    m_value = m_min;
                Invalidate();
            }
        }
        public long Maximum
        { 
            get
            { 
                return m_max;
            } 
            set 
            {
                m_max = value;
                if (m_max < m_min)
                    m_max = m_min;
                if (m_value > m_max)
                    m_value = m_max;
                Invalidate(); 
            } 
        }
        
        public long Value
        { 
            get 
            { 
                return m_value;
            } 
            set 
            {
                m_value = value;
                if (m_value > m_max)
                    m_value = m_max;
                if (m_value < m_min)
                    m_value = m_min;
                Invalidate();
            }
        }

        public FillMode Mode { get { return m_fillMode; } set { m_fillMode = value; Invalidate(); } }

        [Browsable(true)]
        public new string Text { get { return m_text; } set { m_text = value; Invalidate(); } }

        public Color TextColor { get { return m_txtColor; } set { m_txtColor = value; Invalidate(); } }

        public SmoothProgressBar()
        {
            InitializeComponent();
            m_min = 0;
            m_max = 100;
            m_value = 0;
            m_fillMode = FillMode.LEFT_TO_RIGHT;
            m_text = "";
            m_txtColor = SystemColors.WindowText;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int totalPixels = (m_fillMode == FillMode.LEFT_TO_RIGHT || m_fillMode == FillMode.RIGHT_TO_LEFT) ? Width : Height;
            long pixelProgress = (m_value - m_min) * totalPixels / (m_max - m_min);
            StringFormat sf = null;
            if (m_fillMode == FillMode.LEFT_TO_RIGHT || m_fillMode == FillMode.RIGHT_TO_LEFT)
                sf = new StringFormat();
            else
                sf = new StringFormat(StringFormatFlags.DirectionVertical);

            SizeF textSize = e.Graphics.MeasureString(Text, Font, new SizeF(Size.Width, Size.Height), sf);
            e.Graphics.Clear(BackColor);

            if (pixelProgress > 0)
            {
                long x = m_fillMode == FillMode.RIGHT_TO_LEFT ? Width - pixelProgress : 0;
                long y = m_fillMode == FillMode.BOTTOM_TO_TOP ? Height - pixelProgress : 0;
                long width = (m_fillMode == FillMode.LEFT_TO_RIGHT || m_fillMode == FillMode.RIGHT_TO_LEFT) ? pixelProgress : Width;
                long height = (m_fillMode == FillMode.BOTTOM_TO_TOP || m_fillMode == FillMode.TOP_TO_BOTTOM) ? pixelProgress : Height;
                //LinearGradientBrush GradientBrush = new LinearGradientBrush(new Rectangle(x, y, width, height), ForeColor, BackColor, LinearGradientMode.Horizontal);                
                e.Graphics.FillRectangle(new SolidBrush(ForeColor), new Rectangle((int)x, (int)y, (int)width, (int)height));
                //e.Graphics.FillRectangle(GradientBrush, new Rectangle(x, y, width, height));
            }
            e.Graphics.DrawString(Text, Font, new SolidBrush(TextColor), (float)((Width - textSize.Width)/2), (float)((Height -textSize.Height)/2),sf);
        }

        private void SmoothProgressBar_Load(object sender, EventArgs e)
        {

        }

    }
}