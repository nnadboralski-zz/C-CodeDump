namespace Plurky
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtPlurk = new System.Windows.Forms.TextBox();
            this.lblCharsLeft = new System.Windows.Forms.Label();
            this.lblCharCount = new System.Windows.Forms.Label();
            this.btnPost = new System.Windows.Forms.Button();
            this.niPlurk = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmPlurkIcon = new System.Windows.Forms.ContextMenu();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // txtPlurk
            // 
            this.txtPlurk.Location = new System.Drawing.Point(12, 12);
            this.txtPlurk.MaxLength = 1000;
            this.txtPlurk.Multiline = true;
            this.txtPlurk.Name = "txtPlurk";
            this.txtPlurk.Size = new System.Drawing.Size(268, 67);
            this.txtPlurk.TabIndex = 0;
            this.txtPlurk.TextChanged += new System.EventHandler(this.txtPlurk_TextChanged);
            // 
            // lblCharsLeft
            // 
            this.lblCharsLeft.AutoSize = true;
            this.lblCharsLeft.Location = new System.Drawing.Point(12, 91);
            this.lblCharsLeft.Name = "lblCharsLeft";
            this.lblCharsLeft.Size = new System.Drawing.Size(82, 13);
            this.lblCharsLeft.TabIndex = 1;
            this.lblCharsLeft.Text = "Characters Left:";
            // 
            // lblCharCount
            // 
            this.lblCharCount.AutoSize = true;
            this.lblCharCount.Location = new System.Drawing.Point(100, 91);
            this.lblCharCount.Name = "lblCharCount";
            this.lblCharCount.Size = new System.Drawing.Size(25, 13);
            this.lblCharCount.TabIndex = 2;
            this.lblCharCount.Text = "140";
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(205, 86);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 3;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // niPlurk
            // 
            this.niPlurk.Icon = ((System.Drawing.Icon)(resources.GetObject("niPlurk.Icon")));
            this.niPlurk.Text = "notifyIcon1";
            this.niPlurk.Visible = true;
            this.niPlurk.DoubleClick += new System.EventHandler(this.niPlurk_DoubleClick);
            // 
            // cmPlurkIcon
            // 
            this.cmPlurkIcon.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuExit});
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 0;
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 124);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.lblCharCount);
            this.Controls.Add(this.lblCharsLeft);
            this.Controls.Add(this.txtPlurk);
            this.Name = "Form1";
            this.Text = "Plurky";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlurk;
        private System.Windows.Forms.Label lblCharsLeft;
        private System.Windows.Forms.Label lblCharCount;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.NotifyIcon niPlurk;
        private System.Windows.Forms.ContextMenu cmPlurkIcon;
        private System.Windows.Forms.MenuItem mnuExit;
    }
}

