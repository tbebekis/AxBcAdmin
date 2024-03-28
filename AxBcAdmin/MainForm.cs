 
namespace AxBcAdmin
{
    public partial class MainForm : Form
    {
        /* private */
        const string STitle = "AntyxSoft Business Central Admin";
        const string SInfo = @"
Business Central Server configuration settings are stored in a file called CustomSettings.config.

The default location of the CustomSettings.config file is 
     	C:\Program Files\Microsoft Dynamics 365 Business Central\BC_VERSION\Service.

The CustomeSettings.config is an XML file with multiple entries like
	<add key=""ServerInstance"" value=""BC230"" />
where ""key"" is predefined.

Configuration keys are described in the following link
	https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/administration/configure-server-instance

The administrator may use the Set-NAVServerConfiguration PowerShell cmdlet to edit these configuration settings.
	Set-NAVServerConfiguration -ServerInstance ""BC230"" -KeyName ServerInstance -KeyValue ""BC230_Prod""

Microsoft has retired the Business Central Admin application in the BC 2022 Release Wave 2 (v21) on-premises version. A non polite action.

This application can be used with any Business Central version and it aims to make it easy to manage the Business Central Server configuration.
------------------------------------------------------------------------------
";

        System.Windows.Forms.Timer fTimer;
        BindingSource bsServices;

        /* event handlers */
        void AnyClick(object sender, EventArgs e)
        {
            if (btnExit == sender)
            {
                this.Close();
            }
            else if (btnAboutDialog == sender)
            {
                using (AboutDialog F = new AboutDialog())
                    F.ShowDialog();
            }
            else if (btnClearLog == sender || btnClearLog2 == sender)
            {
                edtLog.Clear();
            }
            else if (btnStartService == sender)
            {
                StartService();
            }
            else if (btnRestartService == sender)
            {
                RestartService();
            }
            else if (btnStopService == sender)
            {
                StopService();
            }
            else if (btnRefreshStatus == sender)
            {
                RefreshStatus();
            }
            else if (btnShowConfigFile == sender)
            {
                ShowConfigFile();
            }
            else if (btnShowServiceConfig == sender)
            {
                ShowServiceConfigUI();
            }
            else if (btnCloseServiceConfig == sender)
            {
                CloseServiceConfigUI();
            }
            else if (btnSaveServiceConfig == sender)
            {
                SaveServiceConfig();
            }
            else if (btnDatabaseCredentialsDialog == sender)
            {
                ShowDatabaseCredentialsDialog();
            }
            else if (btnExportLicense == sender)
            {
                ExportLicense();
            }
            else if (btnImportLicense == sender)
            {
                ImportLicense();
            }

        }

        void gridServices_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowServiceConfigUI();
        }
        void bsServices_PositionChanged(object sender, EventArgs e)
        {
            this.Text = STitle;
            lblServiceName.Text = "";
            lblServiceConfigFilePath.Text = "";
            BcService BCS = GetCurrentService();
            if (BCS != null)
            {
                lblServiceName.Text = BCS.InstanceName;
                lblServiceConfigFilePath.Text = BCS.ConfigFilePath;
                this.Text = $"{STitle}: {BCS.InstanceName}";
            }
        }
        void fTimer_Tick(object sender, EventArgs e)
        {
            RefreshStatus();
        }

        /* private */
        /// <summary>
        /// Initializes this form
        /// </summary>
        void FormInitialize()
        {
            App.MainForm = this;

            bsServices = new BindingSource();  

            this.Text = STitle;
            lblServiceName.Text = "";
            lblServiceConfigFilePath.Text = "";

            btnExit.Click += AnyClick;
            btnAboutDialog.Click += AnyClick;
            btnStartService.Click += AnyClick;
            btnRestartService.Click += AnyClick;
            btnStopService.Click += AnyClick;
            btnShowConfigFile.Click += AnyClick;
            btnShowServiceConfig.Click += AnyClick;
            btnRefreshStatus.Click += AnyClick;
            btnDatabaseCredentialsDialog.Click += AnyClick;

            btnCloseServiceConfig.Click += AnyClick;
            btnSaveServiceConfig.Click += AnyClick; 

            btnClearLog.Click += AnyClick;
            btnClearLog2.Click += AnyClick;

            btnExportLicense.Click += AnyClick;
            btnImportLicense.Click += AnyClick;

            bsServices.PositionChanged += bsServices_PositionChanged;
            gridServices.MouseDoubleClick += gridServices_MouseDoubleClick;
    

            bsServices.DataSource = BcService.Services;
            App.InitializeGrid(bsServices, gridServices);

            pnlSettings.Visible = false;

            pnlServices.Dock = DockStyle.Fill;
            pnlSettings.Dock = DockStyle.Fill;

            fTimer = new System.Windows.Forms.Timer();
            fTimer.Tick += fTimer_Tick;
            fTimer.Interval = 1000 * 5;
            fTimer.Enabled = true;

            Log(SInfo);
        }
 
        /// <summary>
        /// Returns the currently selected BC service, if any, else null.
        /// </summary>
        /// <returns></returns>
        BcService GetCurrentService()
        {
            return bsServices.Current is BcService ? bsServices.Current as BcService : null;
        }
        
        /// <summary>
        /// Starts the service
        /// </summary>
        void StartService()
        {
            BcService BCS = GetCurrentService();
            if (BCS == null)
            {
                Log("No Service selected");
                return;
            }

            if (BCS.IsRunning)
            {
                Log("Service is already running.");
                return;
            }
            
            Application.DoEvents();

            BCS.Start();
            RefreshStatus();

            if (BCS.Status == ServiceControllerStatus.Running)
               LogEnd("DONE");
        }
        /// <summary>
        /// Restarts the service
        /// </summary>
        void RestartService()
        {
            BcService BCS = GetCurrentService();
            if (BCS == null)
            {
                Log("No Service selected");
                return;
            }
 
            Application.DoEvents();

            BCS.Restart();
            RefreshStatus();

            if (BCS.Status == ServiceControllerStatus.Running)
                LogEnd("DONE");
        }
        /// <summary>
        /// Stops the service
        /// </summary>
        void StopService()
        {
            BcService BCS = GetCurrentService();
            if (BCS == null)
            {
                Log("No Service selected");
                return;
            }


            if (!BCS.IsRunning)
            {
                Log("Service is already stopped.");
                return;
            }

 
            Application.DoEvents();

            BCS.Stop();
            RefreshStatus();

            if (BCS.Status == ServiceControllerStatus.Stopped)
                LogEnd("DONE");
        }

        /// <summary>
        /// Refreshes the display in the services grid
        /// </summary>
        void RefreshStatus()
        {
            bsServices.ResetBindings(true);
        }
        /// <summary>
        /// Opens Windows File Explorer in the BC service folder and selects the <c>CustomSettings.config</c> file.
        /// </summary>
        void ShowConfigFile()
        {
            BcService BCS = GetCurrentService();
            if (BCS != null && File.Exists(BCS.ConfigFilePath))
            {
                // combine the arguments together
                // it doesn't matter if there is a space after ','
                string argument = "/select, \"" + BCS.ConfigFilePath + "\"";
                System.Diagnostics.Process.Start("explorer.exe", argument);

                //Process.Start("notepad.exe", BCS.ConfigFilePath);

                Log(BCS.ConfigFilePath);
            }
                
        }
        /// <summary>
        /// Creates a <see cref="TabPage"/> for each Category and then adds a <see cref="ConfigItemUserControl"/> for each <see cref="ConfigItem"/> in the page.
        /// <para>Actually creates the User Interface for editing the <c>CustomSettings.config</c> file</para>
        /// </summary>
        void ShowServiceConfigUI()
        {
            // nested functions
            // ----------------------------------------------------------
            List<ConfigItem> GetCategoryItems(string Category, List<ConfigItem> SourceList)
            {
                List<ConfigItem> ResultList = SourceList.FindAll(x => string.Equals(x.Category ,Category, StringComparison.InvariantCultureIgnoreCase));
                SourceList.RemoveAll(x => string.Equals(x.Category, Category, StringComparison.InvariantCultureIgnoreCase));
                return ResultList;
            }
            // ----------------------------------------------------------
            void AddTabPage(string Category, List<ConfigItem>  ItemList)
            {
                TabPage Page;
                FlowLayoutPanel FlowPanel;
                ConfigItemUserControl ConfigControl;

                Page = new TabPage();
                Page.Text = Category;
                Pager.TabPages.Add(Page);

                FlowPanel = new FlowLayoutPanel();
                Page.Controls.Add(FlowPanel);
                FlowPanel.Dock = DockStyle.Fill;
                FlowPanel.AutoScroll = true;
                FlowPanel.FlowDirection = FlowDirection.TopDown;
                FlowPanel.WrapContents = true;

                foreach (var Item in ItemList)
                {
                    ConfigControl = new ConfigItemUserControl(Item);
                    FlowPanel.Controls.Add(ConfigControl);
                }
            }
            // ----------------------------------------------------------
            void LogMiscs(List<ConfigItem> List)
            {
                StringBuilder SB = new StringBuilder();
                SB.AppendLine("=========================================================");
                foreach (var Item in List)
                    SB.AppendLine($"{Item.Name}  -> {Item.Key}");
                SB.AppendLine("=========================================================");
                Log(SB.ToString());
            }
            // ----------------------------------------------------------

            BcService BCS = GetCurrentService();
            if (BCS != null)
            {
                Log("Click on any label to see the description of the associated Key and its possible Values.");

                BCS.LoadConfig();

                pnlServices.Visible = false;
                pnlSettings.Visible = true;

                List<ConfigItem> TempList = new List<ConfigItem>(BCS.ConfigList.ToArray()); 
 
                // all categories, except Miscs
                foreach (string Category in ConfigItemInfo.CategoryList)
                {
                    List<ConfigItem> List = GetCategoryItems(Category, TempList);
                    if (List.Count > 0)
                        AddTabPage(Category, List);
                }

                // Miscs category
                if (TempList.Count > 0)
                {
                    TempList = TempList.OrderBy(item => item.Name).ToList();
                    LogMiscs(TempList);
                    AddTabPage("Miscs", TempList);
                }                    
 
            }
        }
        /// <summary>
        /// Destroys the User Interface used in editing the <c>CustomSettings.config</c> file
        /// </summary>
        void CloseServiceConfigUI()
        {
            BcService BCS = GetCurrentService();
            if (BCS != null)
                BCS.ClearConfig();

            pnlSettings.Visible = false;
            pnlServices.Visible = true;

            Pager.TabPages.Clear();
        }
        /// <summary>
        /// Saves any changed settings (<see cref="ConfigItem"/> items) in the <c>CustomSettings.config</c> file
        /// </summary>
        void SaveServiceConfig()
        {
            BcService BCS = GetCurrentService();
            if (BCS != null)
            {
                List<ConfigItem> ChangedList = BCS.ConfigList.Where(item => item.IsChanged).ToList();
                if (ChangedList.Count <= 0)
                {
                    Log("No changes, nothing to save.");
                    MessageBox.Show("No changes, nothing to save.");
                }
                else
                {
                    if (BCS.SaveConfig())
                        ShowRestartServerMessages(BCS);
                }
            }
        }
        /// <summary>
        /// Helper for reminding the user to restart the service.
        /// </summary>
        /// <param name="BCS"></param>
        void ShowRestartServerMessages(BcService BCS)
        {
            Log("Config is saved");

            Log("Restart the service for the changes to take effect");
            MessageBox.Show("Restart the service for the changes to take effect");

            Log($"A backup of the CustomSettings.config file is saved at \n {BCS.LastBackupFilePath}");
        }
        /// <summary>
        /// Displays the <see cref="DatabaseCredentialsDialog"/>
        /// </summary>
        void ShowDatabaseCredentialsDialog()
        {
            BcService BCS = GetCurrentService();
            if (BCS != null)
            {
                string UserName = "";
                string Password = "";
                if (DatabaseCredentialsDialog.ShowModal(ref UserName, ref Password))
                {
                    BCS.SetDatabaseCredentials(UserName, Password);
                    ShowRestartServerMessages(BCS);
                }
            }
        }
 
        /// <summary>
        /// Exports the current BC license
        /// </summary>
        void ExportLicense()
        {
            BcService BCS = GetCurrentService();
            if (BCS != null)
            {
                BCS.ExportLicense();
                MessageBox.Show("Please, check the last log entry");
            }
                
        }
        /// <summary>
        /// Imports a license in the BC server
        /// </summary>
        void ImportLicense()
        {
            BcService BCS = GetCurrentService();
            if (BCS != null)
            {
                string LicenseFilePath = "";
                using(OpenFileDialog F = new OpenFileDialog())
                {
                    F.Filter = @"FLF files (*.flf)|*.flf|BcLicense files (*.bclicense)|*.bclicense|All files (*.*)|*.*";
                    if (F.ShowDialog() == DialogResult.OK)
                    {
                        LicenseFilePath = F.FileName;
                    }
                }

                if (File.Exists(LicenseFilePath))
                    BCS.ImportLicense(LicenseFilePath);
            }
                
        }

        /// <summary>
        /// Scrolls to the last line of the log control.
        /// </summary>
        void ScrollToEnd()
        {
            edtLog.SelectionStart = edtLog.Text.Length;
            edtLog.ScrollToCaret();
        }

        /* public */
        /// <summary>
        /// Log method
        /// </summary>
        public void Log(string LogText)
        {
            if (!InvokeRequired)
            {
                edtLog.AppendText(LogText + Environment.NewLine);
                ScrollToEnd();
            }
            else
            {
                Invoke(new Action(() =>
                {
                    edtLog.AppendText(LogText + Environment.NewLine);
                    ScrollToEnd();
                }));
            }
        }
        /// <summary>
        /// Log method
        /// </summary>
        public void LogStart(string LogText)
        {
            edtLog.AppendText(LogText);
        }
        /// <summary>
        /// Log method
        /// </summary>
        public void LogAppend(string LogText)
        {
            edtLog.AppendText(LogText);
        }
        /// <summary>
        /// Log method
        /// </summary>
        public void LogEnd(string LogText)
        {
            edtLog.AppendText(LogText + Environment.NewLine);
            ScrollToEnd();
        }

        /* overrides */
        /// <summary>
        /// Override
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!DesignMode)
                FormInitialize();
        }

        /* construction */
        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }




    }
}
