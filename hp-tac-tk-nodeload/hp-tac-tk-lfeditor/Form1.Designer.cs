namespace hp_tac_tk_lfeditor
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
            this.tvLogicFlow = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblCurrentNode = new System.Windows.Forms.Label();
            this.lblCurrentNodeValue = new System.Windows.Forms.Label();
            this.mnuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdConcentra = new System.Windows.Forms.OpenFileDialog();
            this.lblSCB = new System.Windows.Forms.Label();
            this.lblEL2Code = new System.Windows.Forms.Label();
            this.txtEL2Code = new System.Windows.Forms.TextBox();
            this.txtSCB = new System.Windows.Forms.TextBox();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCheckBoxConfiguraitonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvLogicFlow
            // 
            this.tvLogicFlow.AllowDrop = true;
            this.tvLogicFlow.Location = new System.Drawing.Point(12, 28);
            this.tvLogicFlow.Name = "tvLogicFlow";
            this.tvLogicFlow.Size = new System.Drawing.Size(433, 330);
            this.tvLogicFlow.TabIndex = 0;
            this.tvLogicFlow.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLogicFlow_AfterSelect);
            this.tvLogicFlow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvLogicFlow_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(451, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(451, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(379, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(451, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(379, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(451, 122);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(379, 91);
            this.txtContent.TabIndex = 6;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(451, 106);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(73, 13);
            this.lblContent.TabIndex = 5;
            this.lblContent.Text = "Node Content";
            // 
            // lblCurrentNode
            // 
            this.lblCurrentNode.AutoSize = true;
            this.lblCurrentNode.Location = new System.Drawing.Point(12, 361);
            this.lblCurrentNode.Name = "lblCurrentNode";
            this.lblCurrentNode.Size = new System.Drawing.Size(132, 13);
            this.lblCurrentNode.TabIndex = 7;
            this.lblCurrentNode.Text = "Current Selected Node ID:";
            // 
            // lblCurrentNodeValue
            // 
            this.lblCurrentNodeValue.AutoSize = true;
            this.lblCurrentNodeValue.Location = new System.Drawing.Point(150, 361);
            this.lblCurrentNodeValue.Name = "lblCurrentNodeValue";
            this.lblCurrentNodeValue.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentNodeValue.TabIndex = 8;
            // 
            // mnuStripMain
            // 
            this.mnuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mnuStripMain.Location = new System.Drawing.Point(0, 0);
            this.mnuStripMain.Name = "mnuStripMain";
            this.mnuStripMain.Size = new System.Drawing.Size(842, 24);
            this.mnuStripMain.TabIndex = 9;
            this.mnuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.recentToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.recentToolStripMenuItem.Text = "&Recent";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // lblSCB
            // 
            this.lblSCB.AutoSize = true;
            this.lblSCB.Location = new System.Drawing.Point(451, 216);
            this.lblSCB.Name = "lblSCB";
            this.lblSCB.Size = new System.Drawing.Size(83, 13);
            this.lblSCB.TabIndex = 10;
            this.lblSCB.Text = "ShowCheckBox";
            // 
            // lblEL2Code
            // 
            this.lblEL2Code.AutoSize = true;
            this.lblEL2Code.Location = new System.Drawing.Point(655, 216);
            this.lblEL2Code.Name = "lblEL2Code";
            this.lblEL2Code.Size = new System.Drawing.Size(83, 13);
            this.lblEL2Code.TabIndex = 11;
            this.lblEL2Code.Text = "EndLevel2Code";
            // 
            // txtEL2Code
            // 
            this.txtEL2Code.Location = new System.Drawing.Point(658, 232);
            this.txtEL2Code.Name = "txtEL2Code";
            this.txtEL2Code.Size = new System.Drawing.Size(172, 20);
            this.txtEL2Code.TabIndex = 12;
            // 
            // txtSCB
            // 
            this.txtSCB.Location = new System.Drawing.Point(451, 232);
            this.txtSCB.Name = "txtSCB";
            this.txtSCB.Size = new System.Drawing.Size(172, 20);
            this.txtSCB.TabIndex = 13;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.showCheckBoxConfiguraitonToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // showCheckBoxConfiguraitonToolStripMenuItem
            // 
            this.showCheckBoxConfiguraitonToolStripMenuItem.Name = "showCheckBoxConfiguraitonToolStripMenuItem";
            this.showCheckBoxConfiguraitonToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.showCheckBoxConfiguraitonToolStripMenuItem.Text = "Show Check Box Configuraiton";
            this.showCheckBoxConfiguraitonToolStripMenuItem.Click += new System.EventHandler(this.showCheckBoxConfiguraitonToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 397);
            this.Controls.Add(this.txtSCB);
            this.Controls.Add(this.txtEL2Code);
            this.Controls.Add(this.lblEL2Code);
            this.Controls.Add(this.lblSCB);
            this.Controls.Add(this.lblCurrentNodeValue);
            this.Controls.Add(this.lblCurrentNode);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvLogicFlow);
            this.Controls.Add(this.mnuStripMain);
            this.MainMenuStrip = this.mnuStripMain;
            this.Name = "Form1";
            this.Text = "LFEditor";
            this.mnuStripMain.ResumeLayout(false);
            this.mnuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvLogicFlow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblCurrentNode;
        private System.Windows.Forms.Label lblCurrentNodeValue;
        private System.Windows.Forms.MenuStrip mnuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdConcentra;
        private System.Windows.Forms.Label lblSCB;
        private System.Windows.Forms.Label lblEL2Code;
        private System.Windows.Forms.TextBox txtEL2Code;
        private System.Windows.Forms.TextBox txtSCB;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCheckBoxConfiguraitonToolStripMenuItem;
    }
}

