using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AxBcAdmin
{
    internal class BcService
    {
        /* private */
        static readonly string ServicePrefix = "Microsoft Dynamics 365 Business Central Server";
        static List<BcService> fServices;

        ServiceController Service;
        PsCommand Command;

        bool WaitForStatus(ServiceControllerStatus DesiredStatus)
        {
            TimeSpan Timeout = new TimeSpan(0, 0, 20);

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Service.WaitForStatus(DesiredStatus, Timeout);
                }
                catch  
                {
                }

                Application.DoEvents();

                if (Service.Status == DesiredStatus)
                {
                    return true;
                }
            }

            return false;
        }
        List<ConfigItem> LoadConfig(string FilePath)
        {
            List<ConfigItem> List = new List<ConfigItem>();

            XmlDocument Doc = new XmlDocument();
            Doc.Load(FilePath);
            XmlNode AppSettingsNode = Doc.SelectSingleNode("//appSettings");

            ConfigItem Item;
            XmlComment Comment = null;
            foreach (XmlNode Node in AppSettingsNode)
            {
                if (Node.NodeType == XmlNodeType.Comment)
                {
                    Comment = Node as XmlComment;
                }
                else if (Node.NodeType == XmlNodeType.Element)
                {
                    Item = new ConfigItem(Node as XmlElement, Comment);
                    List.Add(Item);

                    Comment = null;
                }
            }

            return List;
        }


        /* construction */
        public BcService(ServiceController Service)
        {
            this.Service = Service;

            string S = Service.DisplayName.Remove(0, ServicePrefix.Length).Trim();
            if (S.StartsWith("["))
                S = S.Remove(0, 1);
            if (S.EndsWith("]"))
                S = S.Remove(S.Length - 1, 1);

            this.DisplayName = Service.DisplayName;
            this.ServiceName = Service.ServiceName;
            this.InstanceName = S;

            using (ManagementObject wmiService = new ManagementObject($"Win32_Service.Name='{Service.ServiceName}'")) // ("Win32_Service.Name='" + Service.ServiceName + "'"))
            {
                wmiService.Get();
                S = wmiService["PathName"].ToString().Trim();

                // "C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\Microsoft.Dynamics.Nav.Server.exe" $BC230 /config "C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\Microsoft.Dynamics.Nav.Server.dll.config"
                if (S[0] == '"')
                {
                    int Index = S.IndexOf('"', 1);
                    S = S.Substring(1, Index - 1);

                    ServiceFolder = Path.GetDirectoryName(S);
                    S = Path.Combine(ServiceFolder, "CustomSettings.config");

                    if (!File.Exists(S))
                        App.Throw($"Settings File {S} not found");

                    ConfigFilePath = S;

                    ConfigList = LoadConfig(ConfigFilePath);
                }
            }
        }

        /* public */
        public override string ToString()
        {
            return !string.IsNullOrWhiteSpace(InstanceName) ? InstanceName : base.ToString();
        }

        public void Restart()
        {
            try
            {
  
                bool IsRunningFlag = Service.Status == ServiceControllerStatus.Running || Service.Status == ServiceControllerStatus.StartPending;

                if (IsRunningFlag)
                {
                    App.Log($"{InstanceName}: Stopping Service. Please wait...");
                    Application.DoEvents();
                    Service.Stop();
                    if (!WaitForStatus(ServiceControllerStatus.Stopped))
                        App.Throw($"{InstanceName}: Cannot stop service. Please consult System EventLog.");
                      App.Log($"{InstanceName}: Service is stopped");
                    Application.DoEvents();
                }

                App.Log($"{InstanceName}: Starting Service. Please wait...");
                Application.DoEvents();
                Service.Start();
                if (!WaitForStatus(ServiceControllerStatus.Running))
                    App.Throw($"{InstanceName}: Cannot start service. Please consult System EventLog.");
                App.Log($"{InstanceName}: Service is restarted");
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                App.Log(ex.Message);
            }
        }
        public void Start()
        {
            if (!IsRunning)
            {
                try
                { 
                    App.Log($"{InstanceName}: Starting Service. Please wait....");
                    Application.DoEvents();
                    Service.Start();
                    if (!WaitForStatus(ServiceControllerStatus.Running))
                        App.Throw($"{InstanceName}: Cannot start service. Please consult System EventLog.");
                    App.Log($"{InstanceName}: Service is started");
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    App.Log(ex.Message);
                }
            }
            else
            {
                App.Log($"{InstanceName}: Service is running");
            }

        }
        public void Stop()
        {
            try
            {
                if (IsRunning)
                {
 
                    App.Log($"{InstanceName}: Stopping Service. Please wait... ");
                    Application.DoEvents();
                    Service.Stop();
                    if (!WaitForStatus(ServiceControllerStatus.Stopped))
                        App.Throw($"{InstanceName}: Cannot stop service. Please consult System EventLog.");
                    App.Log($"{InstanceName}: Service is stopped");
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                App.Log(ex.Message);
            }
        }

        public void SaveConfig()
        {
            List<ConfigItem> ChangedList = ConfigList.Where(item => item.IsChanged).ToList();
            if (ChangedList.Count > 0)
            {
                App.Log($"{InstanceName}: Nothing changed.");
                return;
            }

            if (Command == null)
            {
                Command = new PsCommand(this);
            }

            Command.SaveChanges(ChangedList);

        }
        public DataTable GetConfigTable()
        {
            DataTable Table = new DataTable();

            Table.Columns.Add("Category");
            Table.Columns.Add("Name");
            Table.Columns.Add("Value");
            Table.Columns.Add("OBJECT", typeof(ConfigItem));

            foreach (ConfigItemInfo CIInfo in ConfigItemInfo.List)
            {
                ConfigItem CI = ConfigList.FirstOrDefault(x => x.Key == CIInfo.Key);
                if (CI != null)
                {
                    CI.Category = CIInfo.Category;
                    CI.Name = CIInfo.Name;

                    DataRow Row = Table.AddNewRow();
                    Row["Category"] = CI.Category;
                    Row["Name"] = CI.Name;
                    Row["Value"] = CI.Value;
                    Row["OBJECT"] = CI;
                }
            }

            foreach (ConfigItem CI in ConfigList)
            {
                if (CI.Category == "Miscs")
                {
                    DataRow Row = Table.AddNewRow();
                    Row["Category"] = CI.Category;
                    Row["Name"] = CI.Name;
                    Row["Value"] = CI.Value;
                    Row["OBJECT"] = CI;
                }
            }

            return Table;
        }

        /* properties */
        static public List<BcService> Services
        {
            get
            {
                if (fServices == null)
                {
                    ServiceController[] List = ServiceController.GetServices();
                    fServices = new List<BcService>();

                    foreach (ServiceController Service in List)
                    {
                        // example name: 
                        // Microsoft Dynamics 365 Business Central Server [BC230]
                        if (Service.DisplayName.ToLower().Contains(ServicePrefix.ToLower()))
                        {
                            BcService Item = new BcService(Service);
                            fServices.Add(Item);
                        }
                    }
                }

                return fServices;

            }
        }
        public ServiceControllerStatus Status { get { return Service.Status; } }
        public string StatusText { get { return Service.Status.ToString(); } } 
        public string DisplayName { get; }      // e.g. Microsoft Dynamics 365 Business Central Server [BC230]
        public string ServiceName { get; }      // e.g. ??
        public string InstanceName { get; }     // e.g. BC230
        public string ServiceFolder { get; }    // e.g. C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\
        public string ConfigFilePath { get; }   // e.g. C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\CustomSettings.config
        public List<ConfigItem> ConfigList { get; }
        public bool IsRunning { get { return Service.Status == ServiceControllerStatus.Running || Service.Status == ServiceControllerStatus.StartPending; } }
 

    }
}
