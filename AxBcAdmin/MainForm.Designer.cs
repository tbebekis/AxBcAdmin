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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStrip1 = new StatusStrip();
            lblServiceName = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblServiceConfigFilePath = new ToolStripStatusLabel();
            Splitter = new SplitContainer();
            pnlSettings = new Panel();
            Pager = new TabControl();
            toolStrip1 = new ToolStrip();
            btnSaveServiceConfig = new ToolStripButton();
            btnClearDatabaseCredentials = new ToolStripButton();
            btnSetDatabaseCredentials = new ToolStripButton();
            btnClearLog2 = new ToolStripButton();
            btnCloseServiceConfig = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            pnlServices = new Panel();
            gridServices = new DataGridView();
            coName = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            coConfigFilePath = new DataGridViewTextBoxColumn();
            ToolBar = new ToolStrip();
            btnStartService = new ToolStripButton();
            btnRestartService = new ToolStripButton();
            btnStopService = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnShowConfigFile = new ToolStripButton();
            btnShowServiceConfig = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnClearLog = new ToolStripButton();
            btnAboutDialog = new ToolStripButton();
            btnExit = new ToolStripButton();
            edtLog = new RichTextBox();
            btnRefreshStatus = new ToolStripButton();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Splitter).BeginInit();
            Splitter.Panel1.SuspendLayout();
            Splitter.Panel2.SuspendLayout();
            Splitter.SuspendLayout();
            pnlSettings.SuspendLayout();
            toolStrip1.SuspendLayout();
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
            Splitter.Panel1.Controls.Add(pnlSettings);
            Splitter.Panel1.Controls.Add(pnlServices);
            // 
            // Splitter.Panel2
            // 
            Splitter.Panel2.Controls.Add(edtLog);
            Splitter.Size = new Size(978, 684);
            Splitter.SplitterDistance = 587;
            Splitter.SplitterWidth = 6;
            Splitter.TabIndex = 2;
            // 
            // pnlSettings
            // 
            pnlSettings.Controls.Add(Pager);
            pnlSettings.Controls.Add(toolStrip1);
            pnlSettings.Location = new Point(576, 35);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(593, 500);
            pnlSettings.TabIndex = 2;
            // 
            // Pager
            // 
            Pager.Dock = DockStyle.Fill;
            Pager.Location = new Point(0, 31);
            Pager.Name = "Pager";
            Pager.SelectedIndex = 0;
            Pager.Size = new Size(593, 469);
            Pager.TabIndex = 5;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnSaveServiceConfig, btnClearDatabaseCredentials, btnSetDatabaseCredentials, btnClearLog2, btnCloseServiceConfig, toolStripSeparator3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(593, 31);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnSaveServiceConfig
            // 
            btnSaveServiceConfig.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSaveServiceConfig.Image = Properties.Resources.table_save;
            btnSaveServiceConfig.ImageTransparentColor = Color.Magenta;
            btnSaveServiceConfig.Name = "btnSaveServiceConfig";
            btnSaveServiceConfig.Size = new Size(28, 28);
            btnSaveServiceConfig.Text = "Save Settings";
            // 
            // btnClearDatabaseCredentials
            // 
            btnClearDatabaseCredentials.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnClearDatabaseCredentials.Image = Properties.Resources.user;
            btnClearDatabaseCredentials.ImageTransparentColor = Color.Magenta;
            btnClearDatabaseCredentials.Name = "btnClearDatabaseCredentials";
            btnClearDatabaseCredentials.Size = new Size(28, 28);
            btnClearDatabaseCredentials.Text = "Clear Database Credentials";
            // 
            // btnSetDatabaseCredentials
            // 
            btnSetDatabaseCredentials.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSetDatabaseCredentials.Image = Properties.Resources.user_add;
            btnSetDatabaseCredentials.ImageTransparentColor = Color.Magenta;
            btnSetDatabaseCredentials.Name = "btnSetDatabaseCredentials";
            btnSetDatabaseCredentials.Size = new Size(28, 28);
            btnSetDatabaseCredentials.Text = "Set Database Credentials";
            // 
            // btnClearLog2
            // 
            btnClearLog2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnClearLog2.Image = Properties.Resources.bin_empty;
            btnClearLog2.ImageTransparentColor = Color.Magenta;
            btnClearLog2.Name = "btnClearLog2";
            btnClearLog2.Size = new Size(28, 28);
            btnClearLog2.Text = "Clear Log";
            // 
            // btnCloseServiceConfig
            // 
            btnCloseServiceConfig.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCloseServiceConfig.Image = Properties.Resources.door_open;
            btnCloseServiceConfig.ImageTransparentColor = Color.Magenta;
            btnCloseServiceConfig.Name = "btnCloseServiceConfig";
            btnCloseServiceConfig.Size = new Size(28, 28);
            btnCloseServiceConfig.Text = "Close";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 31);
            // 
            // pnlServices
            // 
            pnlServices.Controls.Add(gridServices);
            pnlServices.Controls.Add(ToolBar);
            pnlServices.Location = new Point(12, 12);
            pnlServices.Name = "pnlServices";
            pnlServices.Size = new Size(498, 523);
            pnlServices.TabIndex = 1;
            // 
            // gridServices
            // 
            gridServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridServices.Columns.AddRange(new DataGridViewColumn[] { coName, colStatus, coConfigFilePath });
            gridServices.Dock = DockStyle.Fill;
            gridServices.Location = new Point(0, 31);
            gridServices.Name = "gridServices";
            gridServices.Size = new Size(498, 492);
            gridServices.TabIndex = 3;
            // 
            // coName
            // 
            coName.DataPropertyName = "InstanceName";
            coName.HeaderText = "Name";
            coName.Name = "coName";
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            // 
            // coConfigFilePath
            // 
            coConfigFilePath.DataPropertyName = "ConfigFilePath";
            coConfigFilePath.HeaderText = "Config File Path";
            coConfigFilePath.Name = "coConfigFilePath";
            // 
            // ToolBar
            // 
            ToolBar.ImageScalingSize = new Size(24, 24);
            ToolBar.Items.AddRange(new ToolStripItem[] { btnStartService, btnRestartService, btnStopService, btnRefreshStatus, toolStripSeparator1, btnShowConfigFile, btnShowServiceConfig, toolStripSeparator2, btnClearLog, btnAboutDialog, btnExit });
            ToolBar.Location = new Point(0, 0);
            ToolBar.Name = "ToolBar";
            ToolBar.Size = new Size(498, 31);
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
            btnStopService.Image = Properties.Resources.control_stop;
            btnStopService.ImageTransparentColor = Color.Magenta;
            btnStopService.Name = "btnStopService";
            btnStopService.Size = new Size(28, 28);
            btnStopService.Text = "Stop";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // btnShowConfigFile
            // 
            btnShowConfigFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnShowConfigFile.Image = Properties.Resources.folder;
            btnShowConfigFile.ImageTransparentColor = Color.Magenta;
            btnShowConfigFile.Name = "btnShowConfigFile";
            btnShowConfigFile.Size = new Size(28, 28);
            btnShowConfigFile.Text = "Show Configuration File";
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
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // btnClearLog
            // 
            btnClearLog.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnClearLog.Image = Properties.Resources.bin_empty;
            btnClearLog.ImageTransparentColor = Color.Magenta;
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(28, 28);
            btnClearLog.Text = "Clear Log";
            // 
            // btnAboutDialog
            // 
            btnAboutDialog.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAboutDialog.Image = Properties.Resources.information;
            btnAboutDialog.ImageTransparentColor = Color.Magenta;
            btnAboutDialog.Name = "btnAboutDialog";
            btnAboutDialog.Size = new Size(28, 28);
            btnAboutDialog.Text = "About";
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
            // edtLog
            // 
            edtLog.BackColor = Color.Gainsboro;
            edtLog.Dock = DockStyle.Fill;
            edtLog.Font = new Font("Cascadia Code", 9F);
            edtLog.Location = new Point(0, 0);
            edtLog.Name = "edtLog";
            edtLog.ReadOnly = true;
            edtLog.Size = new Size(978, 91);
            edtLog.TabIndex = 3;
            edtLog.Text = "";
            // 
            // btnRefreshStatus
            // 
            btnRefreshStatus.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRefreshStatus.Image = Properties.Resources.arrow_refresh_small;
            btnRefreshStatus.ImageTransparentColor = Color.Magenta;
            btnRefreshStatus.Name = "btnRefreshStatus";
            btnRefreshStatus.Size = new Size(28, 28);
            btnRefreshStatus.Text = "Refresh Status";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 706);
            Controls.Add(Splitter);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            Splitter.Panel1.ResumeLayout(false);
            Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Splitter).EndInit();
            Splitter.ResumeLayout(false);
            pnlSettings.ResumeLayout(false);
            pnlSettings.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
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
        private ToolStrip ToolBar;
        private ToolStripButton btnStartService;
        private ToolStripButton btnRestartService;
        private ToolStripButton btnStopService;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnShowServiceConfig;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnExit;
        private Panel pnlSettings;
        private ToolStrip toolStrip1;
        private ToolStripButton btnCloseServiceConfig;
        private ToolStripSeparator toolStripSeparator3;
        private TabControl Pager;
        private ToolStripButton btnShowConfigFile;
        private ToolStripButton btnSaveServiceConfig;
        private DataGridViewTextBoxColumn coName;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn coConfigFilePath;
        private ToolStripButton btnAboutDialog;
        private ToolStripButton btnClearLog;
        private ToolStripButton btnClearLog2;
        private ToolStripButton btnClearDatabaseCredentials;
        private ToolStripButton btnSetDatabaseCredentials;
        private ToolStripButton btnRefreshStatus;
    }
}
