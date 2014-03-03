namespace fURL
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.gpMode = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gpSettings = new System.Windows.Forms.GroupBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHostname = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHostname = new System.Windows.Forms.TextBox();
            this.niFurl = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.cbAutoMinimize = new System.Windows.Forms.CheckBox();
            this.cmFurl = new System.Windows.Forms.ContextMenu();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.gpMode.SuspendLayout();
            this.gpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Checked = true;
            this.rbClient.Location = new System.Drawing.Point(6, 19);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(51, 17);
            this.rbClient.TabIndex = 0;
            this.rbClient.TabStop = true;
            this.rbClient.Text = "Client";
            this.rbClient.UseVisualStyleBackColor = true;
            // 
            // rbServer
            // 
            this.rbServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbServer.AutoSize = true;
            this.rbServer.Location = new System.Drawing.Point(135, 19);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(56, 17);
            this.rbServer.TabIndex = 1;
            this.rbServer.Text = "Server";
            this.rbServer.UseVisualStyleBackColor = true;
            this.rbServer.CheckedChanged += new System.EventHandler(this.rbServer_CheckedChanged);
            // 
            // gpMode
            // 
            this.gpMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpMode.Controls.Add(this.rbClient);
            this.gpMode.Controls.Add(this.rbServer);
            this.gpMode.Location = new System.Drawing.Point(12, 12);
            this.gpMode.Name = "gpMode";
            this.gpMode.Size = new System.Drawing.Size(197, 49);
            this.gpMode.TabIndex = 3;
            this.gpMode.TabStop = false;
            this.gpMode.Text = "fURL Mode";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(134, 169);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(12, 169);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gpSettings
            // 
            this.gpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpSettings.Controls.Add(this.cbAutoMinimize);
            this.gpSettings.Controls.Add(this.cbAutoStart);
            this.gpSettings.Controls.Add(this.lblPort);
            this.gpSettings.Controls.Add(this.lblHostname);
            this.gpSettings.Controls.Add(this.txtPort);
            this.gpSettings.Controls.Add(this.txtHostname);
            this.gpSettings.Location = new System.Drawing.Point(12, 67);
            this.gpSettings.Name = "gpSettings";
            this.gpSettings.Size = new System.Drawing.Size(197, 96);
            this.gpSettings.TabIndex = 6;
            this.gpSettings.TabStop = false;
            this.gpSettings.Text = "Settings";
            // 
            // lblPort
            // 
            this.lblPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(6, 50);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port";
            // 
            // lblHostname
            // 
            this.lblHostname.AutoSize = true;
            this.lblHostname.Location = new System.Drawing.Point(6, 22);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(70, 13);
            this.lblHostname.TabIndex = 2;
            this.lblHostname.Text = "Hostname/IP";
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPort.Location = new System.Drawing.Point(91, 47);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPort.Click += new System.EventHandler(this.txtPort_Click);
            // 
            // txtHostname
            // 
            this.txtHostname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHostname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtHostname.Location = new System.Drawing.Point(91, 19);
            this.txtHostname.Name = "txtHostname";
            this.txtHostname.Size = new System.Drawing.Size(100, 20);
            this.txtHostname.TabIndex = 0;
            this.txtHostname.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHostname.Click += new System.EventHandler(this.txtHostname_Click);
            // 
            // niFurl
            // 
            this.niFurl.Icon = ((System.Drawing.Icon)(resources.GetObject("niFurl.Icon")));
            this.niFurl.Text = "fURL";
            this.niFurl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niFurl_MouseDoubleClick);
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Location = new System.Drawing.Point(9, 73);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.Size = new System.Drawing.Size(73, 17);
            this.cbAutoStart.TabIndex = 4;
            this.cbAutoStart.Text = "Auto-Start";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            // 
            // cbAutoMinimize
            // 
            this.cbAutoMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAutoMinimize.AutoSize = true;
            this.cbAutoMinimize.Location = new System.Drawing.Point(100, 73);
            this.cbAutoMinimize.Name = "cbAutoMinimize";
            this.cbAutoMinimize.Size = new System.Drawing.Size(91, 17);
            this.cbAutoMinimize.TabIndex = 5;
            this.cbAutoMinimize.Text = "Auto-Minimize";
            this.cbAutoMinimize.UseVisualStyleBackColor = true;
            // 
            // cmFurl
            // 
            this.cmFurl.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miExit});
            // 
            // miExit
            // 
            this.miExit.Index = 0;
            this.miExit.Text = "E&xit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 204);
            this.Controls.Add(this.gpSettings);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.gpMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "fURL";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.gpMode.ResumeLayout(false);
            this.gpMode.PerformLayout();
            this.gpSettings.ResumeLayout(false);
            this.gpSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.GroupBox gpMode;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gpSettings;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHostname;
        private System.Windows.Forms.NotifyIcon niFurl;
        private System.Windows.Forms.CheckBox cbAutoMinimize;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.ContextMenu cmFurl;
        private System.Windows.Forms.MenuItem miExit;
    }
}