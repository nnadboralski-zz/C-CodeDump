namespace hp_tac_tk_lfeditor
{
    partial class SCBConfiguration
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
            this.lstShowCheckBox = new System.Windows.Forms.ListBox();
            this.lstEndLevel2Code = new System.Windows.Forms.ListBox();
            this.lblAddShowCheckBox = new System.Windows.Forms.Label();
            this.txtShowCheckBox = new System.Windows.Forms.TextBox();
            this.lblAddEndLevel2Code = new System.Windows.Forms.Label();
            this.txtEndLevel2Code = new System.Windows.Forms.TextBox();
            this.btnNewEndLevel2Code = new System.Windows.Forms.Button();
            this.btnNewShowCheckBox = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdSCBConfig = new System.Windows.Forms.OpenFileDialog();
            this.sfdSCBConfig = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstShowCheckBox
            // 
            this.lstShowCheckBox.FormattingEnabled = true;
            this.lstShowCheckBox.Location = new System.Drawing.Point(12, 69);
            this.lstShowCheckBox.Name = "lstShowCheckBox";
            this.lstShowCheckBox.Size = new System.Drawing.Size(278, 329);
            this.lstShowCheckBox.TabIndex = 0;
            // 
            // lstEndLevel2Code
            // 
            this.lstEndLevel2Code.FormattingEnabled = true;
            this.lstEndLevel2Code.Location = new System.Drawing.Point(296, 69);
            this.lstEndLevel2Code.Name = "lstEndLevel2Code";
            this.lstEndLevel2Code.Size = new System.Drawing.Size(338, 329);
            this.lstEndLevel2Code.TabIndex = 1;
            // 
            // lblAddShowCheckBox
            // 
            this.lblAddShowCheckBox.AutoSize = true;
            this.lblAddShowCheckBox.Location = new System.Drawing.Point(12, 27);
            this.lblAddShowCheckBox.Name = "lblAddShowCheckBox";
            this.lblAddShowCheckBox.Size = new System.Drawing.Size(83, 13);
            this.lblAddShowCheckBox.TabIndex = 2;
            this.lblAddShowCheckBox.Text = "ShowCheckBox";
            // 
            // txtShowCheckBox
            // 
            this.txtShowCheckBox.Location = new System.Drawing.Point(15, 44);
            this.txtShowCheckBox.Name = "txtShowCheckBox";
            this.txtShowCheckBox.Size = new System.Drawing.Size(246, 20);
            this.txtShowCheckBox.TabIndex = 3;
            this.txtShowCheckBox.TextChanged += new System.EventHandler(this.txtShowCheckBox_TextChanged);
            this.txtShowCheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShowCheckBox_KeyDown);
            // 
            // lblAddEndLevel2Code
            // 
            this.lblAddEndLevel2Code.AutoSize = true;
            this.lblAddEndLevel2Code.Location = new System.Drawing.Point(293, 27);
            this.lblAddEndLevel2Code.Name = "lblAddEndLevel2Code";
            this.lblAddEndLevel2Code.Size = new System.Drawing.Size(83, 13);
            this.lblAddEndLevel2Code.TabIndex = 4;
            this.lblAddEndLevel2Code.Text = "EndLevel2Code";
            // 
            // txtEndLevel2Code
            // 
            this.txtEndLevel2Code.Location = new System.Drawing.Point(296, 45);
            this.txtEndLevel2Code.Name = "txtEndLevel2Code";
            this.txtEndLevel2Code.Size = new System.Drawing.Size(309, 20);
            this.txtEndLevel2Code.TabIndex = 5;
            // 
            // btnNewEndLevel2Code
            // 
            this.btnNewEndLevel2Code.Location = new System.Drawing.Point(609, 43);
            this.btnNewEndLevel2Code.Name = "btnNewEndLevel2Code";
            this.btnNewEndLevel2Code.Size = new System.Drawing.Size(23, 23);
            this.btnNewEndLevel2Code.TabIndex = 6;
            this.btnNewEndLevel2Code.Text = "+";
            this.btnNewEndLevel2Code.UseVisualStyleBackColor = true;
            // 
            // btnNewShowCheckBox
            // 
            this.btnNewShowCheckBox.Location = new System.Drawing.Point(267, 42);
            this.btnNewShowCheckBox.Name = "btnNewShowCheckBox";
            this.btnNewShowCheckBox.Size = new System.Drawing.Size(23, 23);
            this.btnNewShowCheckBox.TabIndex = 7;
            this.btnNewShowCheckBox.Text = "+";
            this.btnNewShowCheckBox.UseVisualStyleBackColor = true;
            this.btnNewShowCheckBox.Click += new System.EventHandler(this.btnNewShowCheckBox_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(644, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            // 
            // ofdSCBConfig
            // 
            this.ofdSCBConfig.FileName = "openFileDialog1";
            // 
            // SCBConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 411);
            this.Controls.Add(this.btnNewShowCheckBox);
            this.Controls.Add(this.btnNewEndLevel2Code);
            this.Controls.Add(this.txtEndLevel2Code);
            this.Controls.Add(this.lblAddEndLevel2Code);
            this.Controls.Add(this.txtShowCheckBox);
            this.Controls.Add(this.lblAddShowCheckBox);
            this.Controls.Add(this.lstEndLevel2Code);
            this.Controls.Add(this.lstShowCheckBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SCBConfiguration";
            this.Text = "SCBConfiguration";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstShowCheckBox;
        private System.Windows.Forms.ListBox lstEndLevel2Code;
        private System.Windows.Forms.Label lblAddShowCheckBox;
        private System.Windows.Forms.TextBox txtShowCheckBox;
        private System.Windows.Forms.Label lblAddEndLevel2Code;
        private System.Windows.Forms.TextBox txtEndLevel2Code;
        private System.Windows.Forms.Button btnNewEndLevel2Code;
        private System.Windows.Forms.Button btnNewShowCheckBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdSCBConfig;
        private System.Windows.Forms.SaveFileDialog sfdSCBConfig;
    }
}