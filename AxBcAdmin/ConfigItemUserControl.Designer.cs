namespace AxBcAdmin
{
    partial class ConfigItemUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblKey = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            edtValue = new TextBox();
            cboValueList = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblKey
            // 
            lblKey.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblKey.AutoEllipsis = true;
            lblKey.Location = new Point(3, 3);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(239, 23);
            lblKey.TabIndex = 0;
            lblKey.Text = "Key";
            lblKey.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblKey);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 30);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(edtValue);
            panel2.Controls.Add(cboValueList);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(248, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(243, 30);
            panel2.TabIndex = 2;
            // 
            // edtValue
            // 
            edtValue.Location = new Point(0, 23);
            edtValue.Multiline = true;
            edtValue.Name = "edtValue";
            edtValue.Size = new Size(243, 23);
            edtValue.TabIndex = 5;
            // 
            // cboValueList
            // 
            cboValueList.DropDownStyle = ComboBoxStyle.DropDownList;
            cboValueList.FormattingEnabled = true;
            cboValueList.Location = new Point(0, 0);
            cboValueList.Name = "cboValueList";
            cboValueList.Size = new Size(243, 23);
            cboValueList.TabIndex = 4;
            // 
            // ConfigItemUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ConfigItemUserControl";
            Size = new Size(491, 30);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        public Label lblKey;
        public ComboBox cboValueList;
        public TextBox edtValue;
    }
}
