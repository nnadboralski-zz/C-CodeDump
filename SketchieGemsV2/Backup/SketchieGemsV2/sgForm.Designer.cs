namespace SketchieGemsV2
{
    partial class sgForm
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
            this.titlePicture = new System.Windows.Forms.PictureBox();
            this.scoreBox = new System.Windows.Forms.PictureBox();
            this.sketchieGems1 = new SketchieGemsV2.SketchieGems();
            ((System.ComponentModel.ISupportInitialize)(this.titlePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePicture
            // 
            this.titlePicture.Location = new System.Drawing.Point(12, 12);
            this.titlePicture.Name = "titlePicture";
            this.titlePicture.Size = new System.Drawing.Size(238, 155);
            this.titlePicture.TabIndex = 1;
            this.titlePicture.TabStop = false;
            // 
            // scoreBox
            // 
            this.scoreBox.Location = new System.Drawing.Point(12, 173);
            this.scoreBox.Name = "scoreBox";
            this.scoreBox.Size = new System.Drawing.Size(238, 82);
            this.scoreBox.TabIndex = 2;
            this.scoreBox.TabStop = false;
            // 
            // sketchieGems1
            // 
            this.sketchieGems1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sketchieGems1.BackColor = System.Drawing.Color.Black;
            this.sketchieGems1.Cols = 0;
            this.sketchieGems1.Location = new System.Drawing.Point(256, 12);
            this.sketchieGems1.Name = "sketchieGems1";
            this.sketchieGems1.Rows = 0;
            this.sketchieGems1.Size = new System.Drawing.Size(433, 430);
            this.sketchieGems1.TabIndex = 0;
            this.sketchieGems1.GameOver += new System.EventHandler(this.sketchieGems1_GameOver);
            // 
            // sgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 454);
            this.Controls.Add(this.scoreBox);
            this.Controls.Add(this.titlePicture);
            this.Controls.Add(this.sketchieGems1);
            this.Name = "sgForm";
            this.Text = "sgForm";
            this.SizeChanged += new System.EventHandler(this.sgForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.titlePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SketchieGems sketchieGems1;
        private System.Windows.Forms.PictureBox titlePicture;
        private System.Windows.Forms.PictureBox scoreBox;


    }
}