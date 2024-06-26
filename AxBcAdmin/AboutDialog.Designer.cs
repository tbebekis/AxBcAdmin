﻿namespace AxBcAdmin
{
    partial class AboutDialog
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
            label1 = new Label();
            label2 = new Label();
            lblGenerator = new LinkLabel();
            lblGithub = new LinkLabel();
            btnClose = new Button();
            label3 = new Label();
            label4 = new Label();
            lblAntyxSoft = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(150, 5);
            label1.Name = "label1";
            label1.Size = new Size(116, 25);
            label1.TabIndex = 0;
            label1.Text = "AxBcAdmin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 43);
            label2.Name = "label2";
            label2.Size = new Size(271, 15);
            label2.TabIndex = 1;
            label2.Text = "Administration tool for Microsoft Business Central";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGenerator
            // 
            lblGenerator.AutoSize = true;
            lblGenerator.Location = new Point(92, 75);
            lblGenerator.Name = "lblGenerator";
            lblGenerator.Size = new Size(225, 15);
            lblGenerator.TabIndex = 2;
            lblGenerator.TabStop = true;
            lblGenerator.Text = "https://github.com/tbebekis/AxBcAdmin";
            // 
            // lblGithub
            // 
            lblGithub.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblGithub.AutoSize = true;
            lblGithub.Location = new Point(128, 113);
            lblGithub.Name = "lblGithub";
            lblGithub.Size = new Size(158, 15);
            lblGithub.TabIndex = 3;
            lblGithub.TabStop = true;
            lblGithub.Text = "https://github.com/tbebekis";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClose.DialogResult = DialogResult.OK;
            btnClose.Location = new Point(349, 132);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 32);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(12, 113);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 5;
            label3.Text = "This app is made by";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(106, 132);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 6;
            label4.Text = "at";
            // 
            // lblAntyxSoft
            // 
            lblAntyxSoft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblAntyxSoft.AutoSize = true;
            lblAntyxSoft.Location = new Point(128, 132);
            lblAntyxSoft.Name = "lblAntyxSoft";
            lblAntyxSoft.Size = new Size(127, 15);
            lblAntyxSoft.TabIndex = 7;
            lblAntyxSoft.TabStop = true;
            lblAntyxSoft.Text = "https://antyxsoft.com/";
            // 
            // AboutDialog
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(434, 171);
            Controls.Add(lblAntyxSoft);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnClose);
            Controls.Add(lblGithub);
            Controls.Add(lblGenerator);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private LinkLabel lblGenerator;
        private LinkLabel lblGithub;
        private Button btnClose;
        private Label label3;
        private Label label4;
        private LinkLabel lblAntyxSoft;
    }
}