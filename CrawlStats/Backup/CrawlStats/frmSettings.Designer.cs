namespace CrawlStats
{
    partial class frmSettings
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
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.txtHttpHost = new System.Windows.Forms.TextBox();
            this.lblHttpHost = new System.Windows.Forms.Label();
            this.lblFtpPassword = new System.Windows.Forms.Label();
            this.txtFtpHost = new System.Windows.Forms.TextBox();
            this.txtFtpPort = new System.Windows.Forms.TextBox();
            this.lblFtpUsername = new System.Windows.Forms.Label();
            this.txtFtpUsername = new System.Windows.Forms.TextBox();
            this.lblFtpPort = new System.Windows.Forms.Label();
            this.lblFtpHost = new System.Windows.Forms.Label();
            this.txtFtpPassword = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.txtHttpHost);
            this.gbSettings.Controls.Add(this.lblHttpHost);
            this.gbSettings.Controls.Add(this.lblFtpPassword);
            this.gbSettings.Controls.Add(this.txtFtpHost);
            this.gbSettings.Controls.Add(this.txtFtpPort);
            this.gbSettings.Controls.Add(this.lblFtpUsername);
            this.gbSettings.Controls.Add(this.txtFtpUsername);
            this.gbSettings.Controls.Add(this.lblFtpPort);
            this.gbSettings.Controls.Add(this.lblFtpHost);
            this.gbSettings.Controls.Add(this.txtFtpPassword);
            this.gbSettings.Location = new System.Drawing.Point(12, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(251, 155);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // txtHttpHost
            // 
            this.txtHttpHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHttpHost.Location = new System.Drawing.Point(90, 123);
            this.txtHttpHost.Name = "txtHttpHost";
            this.txtHttpHost.Size = new System.Drawing.Size(155, 20);
            this.txtHttpHost.TabIndex = 9;
            // 
            // lblHttpHost
            // 
            this.lblHttpHost.AutoSize = true;
            this.lblHttpHost.Location = new System.Drawing.Point(6, 126);
            this.lblHttpHost.Name = "lblHttpHost";
            this.lblHttpHost.Size = new System.Drawing.Size(61, 13);
            this.lblHttpHost.TabIndex = 8;
            this.lblHttpHost.Text = "HTTP Host";
            // 
            // lblFtpPassword
            // 
            this.lblFtpPassword.AutoSize = true;
            this.lblFtpPassword.Location = new System.Drawing.Point(6, 100);
            this.lblFtpPassword.Name = "lblFtpPassword";
            this.lblFtpPassword.Size = new System.Drawing.Size(76, 13);
            this.lblFtpPassword.TabIndex = 7;
            this.lblFtpPassword.Text = "FTP Password";
            // 
            // txtFtpHost
            // 
            this.txtFtpHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFtpHost.Location = new System.Drawing.Point(90, 19);
            this.txtFtpHost.Name = "txtFtpHost";
            this.txtFtpHost.Size = new System.Drawing.Size(155, 20);
            this.txtFtpHost.TabIndex = 2;
            // 
            // txtFtpPort
            // 
            this.txtFtpPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFtpPort.Location = new System.Drawing.Point(90, 45);
            this.txtFtpPort.Name = "txtFtpPort";
            this.txtFtpPort.Size = new System.Drawing.Size(155, 20);
            this.txtFtpPort.TabIndex = 0;
            // 
            // lblFtpUsername
            // 
            this.lblFtpUsername.AutoSize = true;
            this.lblFtpUsername.Location = new System.Drawing.Point(6, 74);
            this.lblFtpUsername.Name = "lblFtpUsername";
            this.lblFtpUsername.Size = new System.Drawing.Size(78, 13);
            this.lblFtpUsername.TabIndex = 6;
            this.lblFtpUsername.Text = "FTP Username";
            // 
            // txtFtpUsername
            // 
            this.txtFtpUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFtpUsername.Location = new System.Drawing.Point(90, 71);
            this.txtFtpUsername.Name = "txtFtpUsername";
            this.txtFtpUsername.Size = new System.Drawing.Size(155, 20);
            this.txtFtpUsername.TabIndex = 1;
            // 
            // lblFtpPort
            // 
            this.lblFtpPort.AutoSize = true;
            this.lblFtpPort.Location = new System.Drawing.Point(6, 48);
            this.lblFtpPort.Name = "lblFtpPort";
            this.lblFtpPort.Size = new System.Drawing.Size(49, 13);
            this.lblFtpPort.TabIndex = 5;
            this.lblFtpPort.Text = "FTP Port";
            // 
            // lblFtpHost
            // 
            this.lblFtpHost.AutoSize = true;
            this.lblFtpHost.Location = new System.Drawing.Point(6, 22);
            this.lblFtpHost.Name = "lblFtpHost";
            this.lblFtpHost.Size = new System.Drawing.Size(52, 13);
            this.lblFtpHost.TabIndex = 4;
            this.lblFtpHost.Text = "FTP Host";
            // 
            // txtFtpPassword
            // 
            this.txtFtpPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFtpPassword.Location = new System.Drawing.Point(90, 97);
            this.txtFtpPassword.Name = "txtFtpPassword";
            this.txtFtpPassword.PasswordChar = '*';
            this.txtFtpPassword.Size = new System.Drawing.Size(155, 20);
            this.txtFtpPassword.TabIndex = 3;
            this.txtFtpPassword.UseSystemPasswordChar = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(188, 173);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(107, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(26, 173);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 202);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.gbSettings);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.frmSettings_Shown);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label lblFtpPassword;
        private System.Windows.Forms.TextBox txtFtpHost;
        private System.Windows.Forms.TextBox txtFtpPort;
        private System.Windows.Forms.Label lblFtpUsername;
        private System.Windows.Forms.TextBox txtFtpUsername;
        private System.Windows.Forms.Label lblFtpPort;
        private System.Windows.Forms.Label lblFtpHost;
        private System.Windows.Forms.TextBox txtFtpPassword;
        private System.Windows.Forms.TextBox txtHttpHost;
        private System.Windows.Forms.Label lblHttpHost;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}