using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UberCatalogue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Program.MusicCollection.Progress += new MusicCollection.ProgressCallback(MusicCollection_Progress);
            Program.MusicCollection.Finished += new MusicCollection.FinishedCallback(MusicCollection_Finished);
            Program.MusicCollection.LoadDir(@"K:\Uber\DL");          
        }

        void MusicCollection_Finished()
        {
            PopulateGrid();
        }

        void MusicCollection_Progress(int file, int total)
        {
            pbFiles.Maximum = total;
            pbFiles.Value = file;
            Application.DoEvents();
        }
        private void PopulateGrid()
        {
            MusicCollection mc = Program.MusicCollection;
            object[] row = new object[4];
            foreach (Track t in mc.Tracks)
            {
                // Artist, Album, Track, Filename
                row[0] = t.Artist.Name;
                row[1] = t.Album.Title;
                row[2] = t.Title;
                row[3] = t.FileName;
                gridCollection.Rows.Add(row);
            }
        }
    }
}