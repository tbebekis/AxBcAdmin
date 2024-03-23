using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using System.Web.Services.Description;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AxBcAdmin
{
    public partial class MainForm : Form
    {
        const string STitle = "AntyxSoft Business Central Admin";

        System.Windows.Forms.Timer fTimer;
        BindingSource bsServices;

        void AnyClick(object sender, EventArgs e)
        {
            if (btnExit == sender)
            {
                this.Close();
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
            else if (btnShowConfigText == sender)
            {
                ShowConfigText();
            }
            else if (btnShowServiceConfig == sender)
            {
                ShowServiceConfig();
            }
            else if (btnCloseServiceConfig == sender)
            {
                CloseServiceConfig();
            }
            else if (btnSaveServiceConfig == sender)
            {
                SaveServiceConfig();
            }
        }

        void gridServices_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowServiceConfig();
        }
        void bsServices_PositionChanged(object sender, EventArgs e)
        {
            this.Text = STitle;
            lblServiceName.Text = "";
            lblServiceConfigFilePath.Text = "";
            BcService SI = GetCurrentService();
            if (SI != null)
            {
                lblServiceName.Text = SI.InstanceName;
                lblServiceConfigFilePath.Text = SI.ConfigFilePath;
                this.Text = $"{STitle}: {SI.InstanceName}";
            }
        }
        void fTimer_Tick(object sender, EventArgs e)
        {
            bsServices.ResetBindings(false);
        }

        void FormInitialize()
        {
            App.MainForm = this;

            bsServices = new BindingSource();
  

            this.Text = STitle;
            lblServiceName.Text = "";
            lblServiceConfigFilePath.Text = "";

            btnExit.Click += AnyClick;
            btnStartService.Click += AnyClick;
            btnRestartService.Click += AnyClick;
            btnStopService.Click += AnyClick;
            btnShowConfigText.Click += AnyClick;
            btnShowServiceConfig.Click += AnyClick;

            btnCloseServiceConfig.Click += AnyClick;
            btnSaveServiceConfig.Click += AnyClick;

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
        }
 
        BcService GetCurrentService()
        {
            return bsServices.Current is BcService ? bsServices.Current as BcService : null;
        }
        void StartService()
        {
            BcService SI = GetCurrentService();
            if (SI == null)
            {
                Log("No Service selected");
                return;
            }

            if (SI.IsRunning)
            {
                Log("Service is already running.");
                return;
            }
            
            Application.DoEvents();

            SI.Start();

            if (SI.Status == ServiceControllerStatus.Running)
               LogEnd("DONE");
        }
        void RestartService()
        {
            BcService SI = GetCurrentService();
            if (SI == null)
            {
                Log("No Service selected");
                return;
            }
 
            Application.DoEvents();

            SI.Restart();

            if (SI.Status == ServiceControllerStatus.Running)
                LogEnd("DONE");
        }
        void StopService()
        {
            BcService SI = GetCurrentService();
            if (SI == null)
            {
                Log("No Service selected");
                return;
            }


            if (!SI.IsRunning)
            {
                Log("Service is already stopped.");
                return;
            }

 
            Application.DoEvents();

            SI.Stop();

            if (SI.Status == ServiceControllerStatus.Stopped)
                LogEnd("DONE");
        }
        void ShowConfigText()
        {
            BcService SI = GetCurrentService();
            if (SI != null && File.Exists(SI.ConfigFilePath))
            {
                // combine the arguments together
                // it doesn't matter if there is a space after ','
                string argument = "/select, \"" + SI.ConfigFilePath + "\"";
                System.Diagnostics.Process.Start("explorer.exe", argument);

                Process.Start("notepad.exe", SI.ConfigFilePath);

                Log(SI.ConfigFilePath);
            }
                
        }
        void ShowServiceConfig()
        {
            List<ConfigItem> GetCategoryItems(string Category, List<ConfigItem> SourceList)
            {
                List<ConfigItem> ResultList = SourceList.FindAll(x => x.Category == Category);
                SourceList.RemoveAll(x => x.Category == Category);
                return ResultList;
            }
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

            BcService SI = GetCurrentService();
            if (SI != null)
            {
                pnlServices.Visible = false;
                pnlSettings.Visible = true;

                List<ConfigItem> TempList = new List<ConfigItem>();
                TempList.AddRange(SI.ConfigList.ToArray());

                string[] Categories = [
                    "General", 
                    "Database", 
                    "Develompment", 
                    "Client services", 
                    "SOAP services", 
                    "OData services", 
                    "NAS services", 
                    "Management services",
                    "Azure key vault client identity", 
                    "Azure key vault extension secrets", 
                    "Microsoft Entra ID", 
                    "Data encryption", 
                    "Task scheduler", 
                    "Asynchronous processing",
                    "Reports", 
                    "Query", 
                    "Extensions", 
                    "Compatibility",
                ];

                foreach (string Category in Categories)
                {
                    List<ConfigItem> List = GetCategoryItems(Category, TempList);
                    if (List.Count > 0)
                        AddTabPage(Category, List);
                }

                if (TempList.Count > 0)
                {
                    TempList = TempList.OrderBy(item => item.Name).ToList();
                    AddTabPage("Miscs", TempList);
                }
                    
 
            }
        }

        void CloseServiceConfig()
        {
            pnlSettings.Visible = false;
            pnlServices.Visible = true;

            Pager.TabPages.Clear();
        }
        void SaveServiceConfig()
        {
            BcService SI = GetCurrentService();
            if (SI != null)
            {
                List<ConfigItem> ChangedList = SI.ConfigList.Where(item => item.IsChanged).ToList();
                if (ChangedList.Count <= 0)
                {
                    Log("No changes, nothing to save.");
                    MessageBox.Show("No changes, nothing to save.");
                }
                else
                {
                    SI.SaveConfig();
                    Log("Config is saved");

                    Log("Restart the service for the changes to take effect");
                    MessageBox.Show("Restart the service for the changes to take effect");
                }
            }
        }

        void ScrollToEnd()
        {
            edtLog.SelectionStart = edtLog.Text.Length;
            edtLog.ScrollToCaret();
        }
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

        public void LogStart(string LogText)
        {
            edtLog.AppendText(LogText);
        }
        public void LogAppend(string LogText)
        {
            edtLog.AppendText(LogText);
        }
        public void LogEnd(string LogText)
        {
            edtLog.AppendText(LogText + Environment.NewLine);
            ScrollToEnd();
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!DesignMode)
                FormInitialize();
        }

        public MainForm()
        {
            InitializeComponent();
        }




    }
}
