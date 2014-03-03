namespace qtPlayer2
{
    partial class Playlist
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vs = new System.Windows.Forms.VScrollBar();
            this.picList = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picList)).BeginInit();
            this.SuspendLayout();
            // 
            // vs
            // 
            this.vs.Dock = System.Windows.Forms.DockStyle.Right;
            this.vs.Location = new System.Drawing.Point(133, 0);
            this.vs.Name = "vs";
            this.vs.Size = new System.Drawing.Size(17, 150);
            this.vs.TabIndex = 0;
            this.vs.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vs_Scroll);
            // 
            // picList
            // 
            this.picList.BackColor = System.Drawing.Color.White;
            this.picList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picList.Location = new System.Drawing.Point(0, 0);
            this.picList.Name = "picList";
            this.picList.Size = new System.Drawing.Size(133, 150);
            this.picList.TabIndex = 1;
            this.picList.TabStop = false;
            this.picList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picList_MouseMove);
            this.picList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picList_MouseDoubleClick);
            this.picList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picList_MouseClick);
            this.picList.Paint += new System.Windows.Forms.PaintEventHandler(this.picList_Paint);
            this.picList.SizeChanged += new System.EventHandler(this.picList_SizeChanged);
            // 
            // Playlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picList);
            this.Controls.Add(this.vs);
            this.Name = "Playlist";
            this.Resize += new System.EventHandler(this.Playlist_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vs;
        private System.Windows.Forms.PictureBox picList;
    }
}
