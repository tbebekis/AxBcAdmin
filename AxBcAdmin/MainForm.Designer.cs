namespace AxBcAdmin
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            lblServiceName = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblServiceConfigFilePath = new ToolStripStatusLabel();
            Splitter = new SplitContainer();
            edtLog = new RichTextBox();
            pnlServices = new Panel();
            gridServices = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            ToolBar = new ToolStrip();
            btnStartService = new ToolStripButton();
            btnRestartService = new ToolStripButton();
            btnStopService = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnShowServiceConfig = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnExit = new ToolStripButton();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Splitter).BeginInit();
            Splitter.Panel1.SuspendLayout();
            Splitter.Panel2.SuspendLayout();
            Splitter.SuspendLayout();
            pnlServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridServices).BeginInit();
            ToolBar.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblServiceName, toolStripStatusLabel1, lblServiceConfigFilePath });
            statusStrip1.Location = new Point(0, 684);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(978, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblServiceName
            // 
            lblServiceName.Name = "lblServiceName";
            lblServiceName.Size = new Size(89, 17);
            lblServiceName.Text = "lblServiceName";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.AutoSize = false;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(8, 17);
            // 
            // lblServiceConfigFilePath
            // 
            lblServiceConfigFilePath.Name = "lblServiceConfigFilePath";
            lblServiceConfigFilePath.Size = new Size(135, 17);
            lblServiceConfigFilePath.Text = "lblServiceConfigFilePath";
            // 
            // Splitter
            // 
            Splitter.Dock = DockStyle.Fill;
            Splitter.Location = new Point(0, 0);
            Splitter.Name = "Splitter";
            Splitter.Orientation = Orientation.Horizontal;
            // 
            // Splitter.Panel1
            // 
            Splitter.Panel1.Controls.Add(pnlServices);
 
            // 
            // Splitter.Panel2
            // 
            Splitter.Panel2.Controls.Add(edtLog);
            Splitter.Size = new Size(978, 684);
            Splitter.SplitterDistance = 617;
            Splitter.SplitterWidth = 6;
            Splitter.TabIndex = 2;
            // 
            // edtLog
            // 
            edtLog.BackColor = Color.Gainsboro;
            edtLog.Dock = DockStyle.Fill;
            edtLog.Font = new Font("Cascadia Code", 9F);
            edtLog.Location = new Point(0, 0);
            edtLog.Name = "edtLog";
            edtLog.ReadOnly = true;
            edtLog.Size = new Size(978, 61);
            edtLog.TabIndex = 3;
            edtLog.Text = "";
            // 
            // pnlServices
            // 
            pnlServices.Controls.Add(gridServices);
            pnlServices.Controls.Add(ToolBar);
            pnlServices.Location = new Point(38, 23);
            pnlServices.Name = "pnlServices";
            pnlServices.Size = new Size(253, 523);
            pnlServices.TabIndex = 1;
            // 
            // gridServices
            // 
            gridServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridServices.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, colStatus });
            gridServices.Dock = DockStyle.Fill;
            gridServices.Location = new Point(0, 31);
            gridServices.Name = "gridServices";
            gridServices.Size = new Size(253, 492);
            gridServices.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            dataGridViewTextBoxColumn1.HeaderText = "Name";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            // 
            // ToolBar
            // 
            ToolBar.ImageScalingSize = new Size(24, 24);
            ToolBar.Items.AddRange(new ToolStripItem[] { btnStartService, btnRestartService, btnStopService, toolStripSeparator1, btnShowServiceConfig, toolStripSeparator2, btnExit });
            ToolBar.Location = new Point(0, 0);
            ToolBar.Name = "ToolBar";
            ToolBar.Size = new Size(253, 31);
            ToolBar.TabIndex = 1;
            ToolBar.Text = "toolStrip1";
            // 
            // btnStartService
            // 
            btnStartService.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStartService.Image = Properties.Resources.gear_in;
            btnStartService.ImageTransparentColor = Color.Magenta;
            btnStartService.Name = "btnStartService";
            btnStartService.Size = new Size(28, 28);
            btnStartService.Text = "Start";
            // 
            // btnRestartService
            // 
            btnRestartService.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRestartService.Image = Properties.Resources.restart_services;
            btnRestartService.ImageTransparentColor = Color.Magenta;
            btnRestartService.Name = "btnRestartService";
            btnRestartService.Size = new Size(28, 28);
            btnRestartService.Text = "Restart";
            // 
            // btnStopService
            // 
            btnStopService.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStopService.Image = Properties.Resources.control_stop_blue;
            btnStopService.ImageTransparentColor = Color.Magenta;
            btnStopService.Name = "btnStopService";
            btnStopService.Size = new Size(28, 28);
            btnStopService.Text = "Stop";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // btnShowServiceConfig
            // 
            btnShowServiceConfig.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnShowServiceConfig.Image = Properties.Resources.setting_tools;
            btnShowServiceConfig.ImageTransparentColor = Color.Magenta;
            btnShowServiceConfig.Name = "btnShowServiceConfig";
            btnShowServiceConfig.Size = new Size(28, 28);
            btnShowServiceConfig.Text = "Configuration";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // btnExit
            // 
            btnExit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExit.Image = Properties.Resources.door_open;
            btnExit.ImageTransparentColor = Color.Magenta;
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(28, 28);
            btnExit.Text = "Exit";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 706);
            Controls.Add(Splitter);
            Controls.Add(statusStrip1);
            Name = "MainForm";
            Text = "MainForm";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            Splitter.Panel1.ResumeLayout(false);
            Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Splitter).EndInit();
            Splitter.ResumeLayout(false);
            pnlServices.ResumeLayout(false);
            pnlServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridServices).EndInit();
            ToolBar.ResumeLayout(false);
            ToolBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblServiceName;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblServiceConfigFilePath;
        private SplitContainer Splitter;
        private RichTextBox edtLog;
        private Panel pnlServices;
        private DataGridView gridServices;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn colStatus;
        private ToolStrip ToolBar;
        private ToolStripButton btnStartService;
        private ToolStripButton btnRestartService;
        private ToolStripButton btnStopService;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnShowServiceConfig;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnExit;
    }
}
