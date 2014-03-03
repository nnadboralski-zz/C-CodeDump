namespace GradientProgressBar
{
    partial class GradientProgressBar
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
            this.lblGrdPrgBar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGrdPrgBar
            // 
            this.lblGrdPrgBar.AutoSize = true;
            this.lblGrdPrgBar.Location = new System.Drawing.Point(65, 16);
            this.lblGrdPrgBar.Name = "lblGrdPrgBar";
            this.lblGrdPrgBar.Size = new System.Drawing.Size(21, 13);
            this.lblGrdPrgBar.TabIndex = 0;
            this.lblGrdPrgBar.Text = "0%";
            // 
            // GradientProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblGrdPrgBar);
            this.Name = "GradientProgressBar";
            this.Size = new System.Drawing.Size(150, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGrdPrgBar;
    }
}
