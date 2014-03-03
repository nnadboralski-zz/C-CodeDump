namespace DynSigPostUtility
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
            this.txtSubmission = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.lblField = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtField = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnAddField = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSubmission
            // 
            this.txtSubmission.Enabled = false;
            this.txtSubmission.Location = new System.Drawing.Point(12, 57);
            this.txtSubmission.Multiline = true;
            this.txtSubmission.Name = "txtSubmission";
            this.txtSubmission.Size = new System.Drawing.Size(496, 64);
            this.txtSubmission.TabIndex = 0;
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(9, 9);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(32, 13);
            this.lblURL.TabIndex = 1;
            this.lblURL.Text = "URL:";
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(9, 32);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(32, 13);
            this.lblField.TabIndex = 2;
            this.lblField.Text = "Field:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(50, 6);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(458, 20);
            this.txtURL.TabIndex = 3;
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // txtField
            // 
            this.txtField.Location = new System.Drawing.Point(50, 29);
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(179, 20);
            this.txtField.TabIndex = 4;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(235, 32);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(37, 13);
            this.lblValue.TabIndex = 5;
            this.lblValue.Text = "Value:";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(276, 29);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(160, 20);
            this.txtValue.TabIndex = 6;
            // 
            // btnAddField
            // 
            this.btnAddField.Location = new System.Drawing.Point(442, 27);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(66, 23);
            this.btnAddField.TabIndex = 7;
            this.btnAddField.Text = "Add Field";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(433, 127);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(352, 127);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 159);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnAddField);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtField);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.txtSubmission);
            this.Name = "Form1";
            this.Text = "Dynamic Signature Web Post Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubmission;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtField;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
    }
}

