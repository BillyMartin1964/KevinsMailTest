namespace prpts
{
    partial class RptSched
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
            btnGetPK = new Button();
            btnImportPK = new Button();
            btnExportPK = new Button();
            btnDecrypt = new Button();
            btnEncrypt = new Button();
            button2 = new Button();
            label1 = new Label();
            decryptOpenFileDialog = new OpenFileDialog();
            encryptOpenFileDialog = new OpenFileDialog();
            tbTo = new TextBox();
            tbCC = new TextBox();
            tbFrom = new TextBox();
            tbSubject = new TextBox();
            tbBody = new TextBox();
            SuspendLayout();
            // 
            // btnGetPK
            // 
            btnGetPK.Location = new Point(177, 425);
            btnGetPK.Margin = new Padding(4, 5, 4, 5);
            btnGetPK.Name = "btnGetPK";
            btnGetPK.Size = new Size(100, 35);
            btnGetPK.TabIndex = 11;
            btnGetPK.Text = "Get PK";
            btnGetPK.UseVisualStyleBackColor = true;
            btnGetPK.Click += btnGetPK_Click;
            // 
            // btnImportPK
            // 
            btnImportPK.Location = new Point(707, 485);
            btnImportPK.Margin = new Padding(4, 5, 4, 5);
            btnImportPK.Name = "btnImportPK";
            btnImportPK.Size = new Size(100, 35);
            btnImportPK.TabIndex = 10;
            btnImportPK.Text = "Import PK";
            btnImportPK.UseVisualStyleBackColor = true;
            btnImportPK.Click += btnImportPK_Click;
            // 
            // btnExportPK
            // 
            btnExportPK.Location = new Point(712, 425);
            btnExportPK.Margin = new Padding(4, 5, 4, 5);
            btnExportPK.Name = "btnExportPK";
            btnExportPK.Size = new Size(100, 35);
            btnExportPK.TabIndex = 9;
            btnExportPK.Text = "Export PK";
            btnExportPK.UseVisualStyleBackColor = true;
            btnExportPK.Click += btnExportPK_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(736, 309);
            btnDecrypt.Margin = new Padding(4, 5, 4, 5);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(100, 35);
            btnDecrypt.TabIndex = 8;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(708, 242);
            btnEncrypt.Margin = new Padding(4, 5, 4, 5);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(100, 35);
            btnEncrypt.TabIndex = 7;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // button2
            // 
            button2.Location = new Point(124, 269);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(299, 60);
            button2.TabIndex = 6;
            button2.Text = "Send";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(197, 372);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 12;
            label1.Text = "label1";
            // 
            // decryptOpenFileDialog
            // 
            decryptOpenFileDialog.FileName = "openFileDialog1";
            // 
            // encryptOpenFileDialog
            // 
            encryptOpenFileDialog.FileName = "openFileDialog1";
            // 
            // tbTo
            // 
            tbTo.Location = new Point(84, 79);
            tbTo.Margin = new Padding(4, 5, 4, 5);
            tbTo.Name = "tbTo";
            tbTo.Size = new Size(404, 27);
            tbTo.TabIndex = 13;
            tbTo.TextChanged += tbTO_TextChanged;
            // 
            // tbCC
            // 
            tbCC.Location = new Point(84, 116);
            tbCC.Margin = new Padding(4, 5, 4, 5);
            tbCC.Name = "tbCC";
            tbCC.Size = new Size(404, 27);
            tbCC.TabIndex = 14;
            tbCC.TextChanged += tbCC_TextChanged;
            // 
            // tbFrom
            // 
            tbFrom.Location = new Point(84, 42);
            tbFrom.Margin = new Padding(4, 5, 4, 5);
            tbFrom.Name = "tbFrom";
            tbFrom.Size = new Size(404, 27);
            tbFrom.TabIndex = 15;
            // 
            // tbSubject
            // 
            tbSubject.Location = new Point(84, 153);
            tbSubject.Margin = new Padding(4, 5, 4, 5);
            tbSubject.Name = "tbSubject";
            tbSubject.Size = new Size(404, 27);
            tbSubject.TabIndex = 16;
            tbSubject.TextChanged += tbSubject_TextChanged;
            // 
            // tbBody
            // 
            tbBody.Location = new Point(496, 42);
            tbBody.Margin = new Padding(4, 5, 4, 5);
            tbBody.Multiline = true;
            tbBody.Name = "tbBody";
            tbBody.Size = new Size(404, 138);
            tbBody.TabIndex = 17;
            // 
            // RptSched
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(1067, 692);
            Controls.Add(tbBody);
            Controls.Add(tbSubject);
            Controls.Add(tbFrom);
            Controls.Add(tbCC);
            Controls.Add(tbTo);
            Controls.Add(label1);
            Controls.Add(btnGetPK);
            Controls.Add(btnImportPK);
            Controls.Add(btnExportPK);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(button2);
            Margin = new Padding(4, 5, 4, 5);
            Name = "RptSched";
            Text = "RptSched";
            Load += RptSched_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnGetPK;
        private System.Windows.Forms.Button btnImportPK;
        private System.Windows.Forms.Button btnExportPK;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog decryptOpenFileDialog;
        private System.Windows.Forms.OpenFileDialog encryptOpenFileDialog;
        public System.Windows.Forms.TextBox tbTo;
        public System.Windows.Forms.TextBox tbCC;
        public System.Windows.Forms.TextBox tbFrom;
        public System.Windows.Forms.TextBox tbSubject;
        public System.Windows.Forms.TextBox tbBody;
        public System.Windows.Forms.Button button2;
    }
}