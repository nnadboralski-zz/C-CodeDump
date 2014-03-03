namespace UberCatalogue
{
    partial class Form1
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
            this.gridCollection = new System.Windows.Forms.DataGridView();
            this.pbFiles = new System.Windows.Forms.ProgressBar();
            this.colArtist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlbum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCollection
            // 
            this.gridCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCollection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArtist,
            this.colAlbum,
            this.colTrack,
            this.colFilename});
            this.gridCollection.Location = new System.Drawing.Point(12, 12);
            this.gridCollection.Name = "gridCollection";
            this.gridCollection.Size = new System.Drawing.Size(856, 478);
            this.gridCollection.TabIndex = 0;
            // 
            // pbFiles
            // 
            this.pbFiles.Location = new System.Drawing.Point(12, 496);
            this.pbFiles.Name = "pbFiles";
            this.pbFiles.Size = new System.Drawing.Size(856, 23);
            this.pbFiles.TabIndex = 1;
            // 
            // colArtist
            // 
            this.colArtist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colArtist.HeaderText = "Artist";
            this.colArtist.Name = "colArtist";
            this.colArtist.Width = 55;
            // 
            // colAlbum
            // 
            this.colAlbum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAlbum.HeaderText = "Album";
            this.colAlbum.Name = "colAlbum";
            this.colAlbum.Width = 61;
            // 
            // colTrack
            // 
            this.colTrack.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTrack.HeaderText = "Track";
            this.colTrack.Name = "colTrack";
            this.colTrack.Width = 60;
            // 
            // colFilename
            // 
            this.colFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFilename.HeaderText = "Filename";
            this.colFilename.Name = "colFilename";
            this.colFilename.Width = 74;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 526);
            this.Controls.Add(this.pbFiles);
            this.Controls.Add(this.gridCollection);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCollection;
        private System.Windows.Forms.ProgressBar pbFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlbum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrack;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
    }
}

