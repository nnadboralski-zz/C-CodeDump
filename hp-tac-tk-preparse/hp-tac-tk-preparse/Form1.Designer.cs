namespace hp_tac_tk_preparse
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
            this.pbSheep = new System.Windows.Forms.PictureBox();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.fbdPreparse = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbSheep)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSheep
            // 
            this.pbSheep.Image = global::hp_tac_tk_preparse.Properties.Resources.Nick_L;
            this.pbSheep.InitialImage = global::hp_tac_tk_preparse.Properties.Resources.Nick_L;
            this.pbSheep.Location = new System.Drawing.Point(12, 25);
            this.pbSheep.Name = "pbSheep";
            this.pbSheep.Size = new System.Drawing.Size(194, 204);
            this.pbSheep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSheep.TabIndex = 1;
            this.pbSheep.TabStop = false;
            this.pbSheep.Click += new System.EventHandler(this.pbSheep_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(231, 25);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(270, 199);
            this.lstFiles.TabIndex = 2;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 285);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.pbSheep);
            this.Name = "Form1";
            this.Text = "Sheepy\'s One Stop Double Space Removal Shop";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pbSheep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSheep;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.FolderBrowserDialog fbdPreparse;

    }
}

