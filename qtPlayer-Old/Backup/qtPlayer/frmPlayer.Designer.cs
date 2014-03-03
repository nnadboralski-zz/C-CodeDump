namespace qtPlayer
{
    partial class frmPlayer
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
            this.smoothProgressBar1 = new SmoothProgressBar.SmoothProgressBar();
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuEdit = new System.Windows.Forms.MenuItem();
            this.mnuView = new System.Windows.Forms.MenuItem();
            this.mnuPlaylist = new System.Windows.Forms.MenuItem();
            this.mnuTools = new System.Windows.Forms.MenuItem();
            this.mnuHelp = new System.Windows.Forms.MenuItem();
            this.mnuSettings = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // smoothProgressBar1
            // 
            this.smoothProgressBar1.BackColor = System.Drawing.Color.White;
            this.smoothProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.smoothProgressBar1.ForeColor = System.Drawing.Color.ForestGreen;
            this.smoothProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.smoothProgressBar1.Maximum = 100;
            this.smoothProgressBar1.Minimum = 0;
            this.smoothProgressBar1.Mode = SmoothProgressBar.FillMode.LEFT_TO_RIGHT;
            this.smoothProgressBar1.Name = "smoothProgressBar1";
            this.smoothProgressBar1.Size = new System.Drawing.Size(466, 18);
            this.smoothProgressBar1.TabIndex = 0;
            this.smoothProgressBar1.TextColor = System.Drawing.SystemColors.WindowText;
            this.smoothProgressBar1.Value = 0;
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuPlaylist,
            this.mnuTools,
            this.mnuHelp});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuSettings});
            this.mnuFile.Text = "&File";
            // 
            // mnuEdit
            // 
            this.mnuEdit.Index = 1;
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuView
            // 
            this.mnuView.Index = 2;
            this.mnuView.Text = "&View";
            // 
            // mnuPlaylist
            // 
            this.mnuPlaylist.Index = 3;
            this.mnuPlaylist.Text = "&Playlist";
            // 
            // mnuTools
            // 
            this.mnuTools.Index = 4;
            this.mnuTools.Text = "&Tools";
            // 
            // mnuHelp
            // 
            this.mnuHelp.Index = 5;
            this.mnuHelp.Text = "&Help";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Index = 0;
            this.mnuSettings.Text = "&Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 439);
            this.Controls.Add(this.smoothProgressBar1);
            this.Menu = this.mnuMain;
            this.Name = "frmPlayer";
            this.Text = "qtPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPlayer_FormClosing);
            this.Load += new System.EventHandler(this.frmPlayer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SmoothProgressBar.SmoothProgressBar smoothProgressBar1;
        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuFile;
        private System.Windows.Forms.MenuItem mnuEdit;
        private System.Windows.Forms.MenuItem mnuView;
        private System.Windows.Forms.MenuItem mnuPlaylist;
        private System.Windows.Forms.MenuItem mnuTools;
        private System.Windows.Forms.MenuItem mnuHelp;
        private System.Windows.Forms.MenuItem mnuSettings;
    }
}

