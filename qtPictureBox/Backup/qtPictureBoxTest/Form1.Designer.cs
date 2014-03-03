namespace qtPictureBoxTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.qtPictureBox1 = new qtPictureBox.qtPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.qtPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // qtPictureBox1
            // 
            this.qtPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qtPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("qtPictureBox1.Image")));
            this.qtPictureBox1.ImageLocation = "";
            this.qtPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.qtPictureBox1.Name = "qtPictureBox1";
            this.qtPictureBox1.Size = new System.Drawing.Size(292, 266);
            this.qtPictureBox1.TabIndex = 0;
            this.qtPictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.qtPictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.qtPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private qtPictureBox.qtPictureBox qtPictureBox1;

    }
}

