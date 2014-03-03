using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SketchieGemsV2
{
    public partial class sgForm : Form
    {
        public sgForm()
        {
            InitializeComponent();
            sketchieGems1.LoadTiles(@"Images\");
        }

        private void sgForm_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void sketchieGems1_GameOver(object sender, EventArgs e)
        {
            MessageBox.Show("Game Over, You Lose, Etc.");
        }
    }
}