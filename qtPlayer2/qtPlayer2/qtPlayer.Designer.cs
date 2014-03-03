namespace qtPlayer2
{
    partial class qtPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrSongPlayed = new System.Windows.Forms.Timer(this.components);
            this.spbPlayed = new SmoothProgressBar.SmoothProgressBar();
            this.cmPlaylist = new System.Windows.Forms.ContextMenu();
            this.mnuAddFolder = new System.Windows.Forms.MenuItem();
            this.mnuSavePlaylist = new System.Windows.Forms.MenuItem();
            this.mnuLoadPlaylist = new System.Windows.Forms.MenuItem();
            this.mnuClearPlaylist = new System.Windows.Forms.MenuItem();
            this.browse = new System.Windows.Forms.FolderBrowserDialog();
            this.sfdPlaylist = new System.Windows.Forms.SaveFileDialog();
            this.ofdPlaylist = new System.Windows.Forms.OpenFileDialog();
            this.playlist1 = new qtPlayer2.Playlist();
            this.SuspendLayout();
            // 
            // tmrSongPlayed
            // 
            this.tmrSongPlayed.Interval = 10;
            this.tmrSongPlayed.Tick += new System.EventHandler(this.tmrSongPlayed_Tick);
            // 
            // spbPlayed
            // 
            this.spbPlayed.BackColor = System.Drawing.Color.White;
            this.spbPlayed.Dock = System.Windows.Forms.DockStyle.Top;
            this.spbPlayed.ForeColor = System.Drawing.Color.ForestGreen;
            this.spbPlayed.Location = new System.Drawing.Point(0, 0);
            this.spbPlayed.Maximum = 100;
            this.spbPlayed.Minimum = 0;
            this.spbPlayed.Mode = SmoothProgressBar.FillMode.LEFT_TO_RIGHT;
            this.spbPlayed.Name = "spbPlayed";
            this.spbPlayed.Size = new System.Drawing.Size(642, 14);
            this.spbPlayed.TabIndex = 2;
            this.spbPlayed.TextColor = System.Drawing.Color.Black;
            this.spbPlayed.Value = 0;
            this.spbPlayed.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spbPlayed_MouseMove);
            this.spbPlayed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.qtPlayer_KeyUp);
            this.spbPlayed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spbPlayed_MouseDown);
            // 
            // cmPlaylist
            // 
            this.cmPlaylist.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAddFolder,
            this.mnuSavePlaylist,
            this.mnuLoadPlaylist,
            this.mnuClearPlaylist});
            // 
            // mnuAddFolder
            // 
            this.mnuAddFolder.Index = 0;
            this.mnuAddFolder.Text = "Add Folder";
            this.mnuAddFolder.Click += new System.EventHandler(this.mnuAddFolder_Click);
            // 
            // mnuSavePlaylist
            // 
            this.mnuSavePlaylist.Index = 1;
            this.mnuSavePlaylist.Text = "Save Playlist";
            this.mnuSavePlaylist.Click += new System.EventHandler(this.mnuSavePlaylist_Click);
            // 
            // mnuLoadPlaylist
            // 
            this.mnuLoadPlaylist.Index = 2;
            this.mnuLoadPlaylist.Text = "Load Playlist";
            this.mnuLoadPlaylist.Click += new System.EventHandler(this.mnuLoadPlaylist_Click);
            // 
            // mnuClearPlaylist
            // 
            this.mnuClearPlaylist.Index = 3;
            this.mnuClearPlaylist.Text = "Clear Playlist";
            this.mnuClearPlaylist.Click += new System.EventHandler(this.mnuClearPlaylist_Click);
            // 
            // browse
            // 
            this.browse.ShowNewFolderButton = false;
            // 
            // sfdPlaylist
            // 
            this.sfdPlaylist.DefaultExt = "qtPlaylist";
            this.sfdPlaylist.Filter = "qt Playlist|*.qtPlaylist";
            // 
            // ofdPlaylist
            // 
            this.ofdPlaylist.DefaultExt = "qtPlaylist";
            this.ofdPlaylist.Filter = "qt Playlist|*.qtPlaylist|M3U Playlist|*.m3u|All Files|*.*";
            // 
            // playlist1
            // 
            this.playlist1.BackColor = System.Drawing.SystemColors.Control;
            this.playlist1.CurrentlyPlayingIndex = -1;
            this.playlist1.Cursor = System.Windows.Forms.Cursors.Default;
            this.playlist1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlist1.ForeColor = System.Drawing.Color.Black;
            this.playlist1.Location = new System.Drawing.Point(0, 14);
            this.playlist1.Name = "playlist1";
            this.playlist1.NowPlayingColor = System.Drawing.SystemColors.HighlightText;
            this.playlist1.SelectedColor = System.Drawing.SystemColors.Highlight;
            this.playlist1.SelectedIndex = -1;
            this.playlist1.Size = new System.Drawing.Size(642, 227);
            this.playlist1.TabIndex = 0;
            this.playlist1.TrackList = null;
            this.playlist1.ZebraStripeColorA = System.Drawing.Color.WhiteSmoke;
            this.playlist1.ZebraStripeColorB = System.Drawing.Color.LightGray;
            this.playlist1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.qtPlayer_KeyUp);
            // 
            // qtPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 241);
            this.Controls.Add(this.playlist1);
            this.Controls.Add(this.spbPlayed);
            this.Name = "qtPlayer";
            this.Text = "qtPlayer";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.qtPlayer_KeyUp);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.qtPlayer_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Playlist playlist1;
        private System.Windows.Forms.Timer tmrSongPlayed;
        private SmoothProgressBar.SmoothProgressBar spbPlayed;
        private System.Windows.Forms.ContextMenu cmPlaylist;
        private System.Windows.Forms.MenuItem mnuAddFolder;
        private System.Windows.Forms.MenuItem mnuSavePlaylist;
        private System.Windows.Forms.MenuItem mnuLoadPlaylist;
        private System.Windows.Forms.FolderBrowserDialog browse;
        private System.Windows.Forms.MenuItem mnuClearPlaylist;
        private System.Windows.Forms.SaveFileDialog sfdPlaylist;
        private System.Windows.Forms.OpenFileDialog ofdPlaylist;
    }
}