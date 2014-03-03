using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace qtPictureBox
{
    public class qtPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Image != null)
            {
                pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                pe.Graphics.DrawImage(Image, new Rectangle(0, 0, Width, Height), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}
