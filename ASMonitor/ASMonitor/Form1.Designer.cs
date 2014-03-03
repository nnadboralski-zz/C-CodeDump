namespace ASMonitor
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
            this.niASMIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmASMIcon = new System.Windows.Forms.ContextMenu();
            this.mnuStatus = new System.Windows.Forms.MenuItem();
            this.mnuSeperator = new System.Windows.Forms.MenuItem();
            this.mnuPlurk = new System.Windows.Forms.MenuItem();
            this.mnuLogtoFile = new System.Windows.Forms.MenuItem();
            this.mnuCopytoClipboard = new System.Windows.Forms.MenuItem();
            this.mnuSeperator2 = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.txtPlurkNickname = new System.Windows.Forms.TextBox();
            this.txtPlurkPassword = new System.Windows.Forms.TextBox();
            this.lblPlurkNickname = new System.Windows.Forms.Label();
            this.lblPlurkPassword = new System.Windows.Forms.Label();
            this.btnLogintoPlurk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // niASMIcon
            // 
            this.niASMIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("niASMIcon.Icon")));
            this.niASMIcon.Text = "Audiosurf Monitor";
            this.niASMIcon.Visible = true;
            this.niASMIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niASMIcon_MouseDoubleClick);
            // 
            // cmASMIcon
            // 
            this.cmASMIcon.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuStatus,
            this.mnuSeperator,
            this.mnuPlurk,
            this.mnuLogtoFile,
            this.mnuCopytoClipboard,
            this.mnuSeperator2,
            this.mnuExit});
            // 
            // mnuStatus
            // 
            this.mnuStatus.Enabled = false;
            this.mnuStatus.Index = 0;
            this.mnuStatus.Text = "Not Registered";
            // 
            // mnuSeperator
            // 
            this.mnuSeperator.Index = 1;
            this.mnuSeperator.Text = "-";
            // 
            // mnuPlurk
            // 
            this.mnuPlurk.Index = 2;
            this.mnuPlurk.Text = "Plurk";
            this.mnuPlurk.Click += new System.EventHandler(this.mnuPlurk_Click);
            // 
            // mnuLogtoFile
            // 
            this.mnuLogtoFile.Index = 3;
            this.mnuLogtoFile.Text = "Log to File";
            this.mnuLogtoFile.Click += new System.EventHandler(this.mnuLogtoFile_Click);
            // 
            // mnuCopytoClipboard
            // 
            this.mnuCopytoClipboard.Index = 4;
            this.mnuCopytoClipboard.Text = "Copy to Clipboard";
            this.mnuCopytoClipboard.Click += new System.EventHandler(this.mnuCopytoClipboard_Click);
            // 
            // mnuSeperator2
            // 
            this.mnuSeperator2.Index = 5;
            this.mnuSeperator2.Text = "-";
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 6;
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // txtPlurkNickname
            // 
            this.txtPlurkNickname.Location = new System.Drawing.Point(73, 12);
            this.txtPlurkNickname.Name = "txtPlurkNickname";
            this.txtPlurkNickname.Size = new System.Drawing.Size(100, 20);
            this.txtPlurkNickname.TabIndex = 0;
            // 
            // txtPlurkPassword
            // 
            this.txtPlurkPassword.Location = new System.Drawing.Point(73, 38);
            this.txtPlurkPassword.Name = "txtPlurkPassword";
            this.txtPlurkPassword.PasswordChar = '*';
            this.txtPlurkPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPlurkPassword.TabIndex = 1;
            // 
            // lblPlurkNickname
            // 
            this.lblPlurkNickname.AutoSize = true;
            this.lblPlurkNickname.Location = new System.Drawing.Point(12, 15);
            this.lblPlurkNickname.Name = "lblPlurkNickname";
            this.lblPlurkNickname.Size = new System.Drawing.Size(55, 13);
            this.lblPlurkNickname.TabIndex = 2;
            this.lblPlurkNickname.Text = "Nickname";
            // 
            // lblPlurkPassword
            // 
            this.lblPlurkPassword.AutoSize = true;
            this.lblPlurkPassword.Location = new System.Drawing.Point(14, 41);
            this.lblPlurkPassword.Name = "lblPlurkPassword";
            this.lblPlurkPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPlurkPassword.TabIndex = 3;
            this.lblPlurkPassword.Text = "Password";
            // 
            // btnLogintoPlurk
            // 
            this.btnLogintoPlurk.Location = new System.Drawing.Point(17, 64);
            this.btnLogintoPlurk.Name = "btnLogintoPlurk";
            this.btnLogintoPlurk.Size = new System.Drawing.Size(156, 23);
            this.btnLogintoPlurk.TabIndex = 4;
            this.btnLogintoPlurk.Text = "Login to Plurk";
            this.btnLogintoPlurk.UseVisualStyleBackColor = true;
            this.btnLogintoPlurk.Click += new System.EventHandler(this.btnLogintoPlurk_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 99);
            this.Controls.Add(this.btnLogintoPlurk);
            this.Controls.Add(this.lblPlurkPassword);
            this.Controls.Add(this.lblPlurkNickname);
            this.Controls.Add(this.txtPlurkPassword);
            this.Controls.Add(this.txtPlurkNickname);
            this.Name = "Form1";
            this.Text = "ASMonitor";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niASMIcon;
        private System.Windows.Forms.ContextMenu cmASMIcon;
        private System.Windows.Forms.MenuItem mnuPlurk;
        private System.Windows.Forms.MenuItem mnuLogtoFile;
        private System.Windows.Forms.MenuItem mnuCopytoClipboard;
        private System.Windows.Forms.MenuItem mnuStatus;
        private System.Windows.Forms.MenuItem mnuSeperator;
        private System.Windows.Forms.MenuItem mnuSeperator2;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.TextBox txtPlurkNickname;
        private System.Windows.Forms.TextBox txtPlurkPassword;
        private System.Windows.Forms.Label lblPlurkNickname;
        private System.Windows.Forms.Label lblPlurkPassword;
        private System.Windows.Forms.Button btnLogintoPlurk;
    }
}

