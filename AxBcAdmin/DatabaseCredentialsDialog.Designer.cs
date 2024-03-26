namespace AxBcAdmin
{
    partial class DatabaseCredentialsDialog
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
            cboMode = new ComboBox();
            edtUserName = new TextBox();
            edtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            SuspendLayout();
            // 
            // cboMode
            // 
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.FormattingEnabled = true;
            cboMode.Location = new Point(120, 12);
            cboMode.Name = "cboMode";
            cboMode.Size = new Size(221, 23);
            cboMode.TabIndex = 0;
            // 
            // edtUserName
            // 
            edtUserName.Font = new Font("Cascadia Code", 9F);
            edtUserName.Location = new Point(120, 41);
            edtUserName.Name = "edtUserName";
            edtUserName.Size = new Size(221, 21);
            edtUserName.TabIndex = 1;
            // 
            // edtPassword
            // 
            edtPassword.Font = new Font("Cascadia Code", 9F);
            edtPassword.Location = new Point(120, 70);
            edtPassword.Name = "edtPassword";
            edtPassword.Size = new Size(221, 21);
            edtPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 15);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "Mode";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 45);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 4;
            label2.Text = "Login Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 74);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(284, 138);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 32);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.Location = new Point(205, 138);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 32);
            btnOK.TabIndex = 7;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // DatabaseCredentialsDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 174);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(edtPassword);
            Controls.Add(edtUserName);
            Controls.Add(cboMode);
            Name = "DatabaseCredentialsDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Database Credentials";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboMode;
        private TextBox edtUserName;
        private TextBox edtPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCancel;
        private Button btnOK;
    }
}