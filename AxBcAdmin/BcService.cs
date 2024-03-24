﻿namespace AxBcAdmin
{
    internal class BcService
    {
        /* private */
        static readonly string ServicePrefix = "Microsoft Dynamics 365 Business Central Server";
        static List<BcService> fServices;
        ServiceController Service;
        //PsCommand Command;

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
        void BackupConfigFile()
        {
            string BackupFolder = Path.Combine(App.AppFolder, "Backup");
            Directory.CreateDirectory(BackupFolder);
            string FileName = "CustomSettings Backup " + DateTime.Now.ToFileName() + ".XML";
            LastBackupFilePath = Path.Combine(BackupFolder, FileName);

            File.Copy(ConfigFilePath, LastBackupFilePath, true);
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

        public void ClearConfig()
        {
            ConfigList.Clear();
        }
        public void LoadConfig()
        {
            ConfigList.Clear();

            XmlDocument Doc = new XmlDocument();
            Doc.Load(ConfigFilePath);
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
                    if (!ConfigItemInfo.ExcludeSettings.Any(item => string.Equals(item, Item.Key, StringComparison.OrdinalIgnoreCase)))
                       ConfigList.Add(Item);

                    Comment = null;
                }
            }

        }
        public bool SaveConfig()
        {
            List<ConfigItem> ChangedList = ConfigList.Where(item => item.IsChanged).ToList();
            if (ChangedList.Count <= 0)
            {
                App.Log($"{InstanceName}: Nothing changed.");
                return false;
            }

            XmlDocument Doc = new XmlDocument();
            Doc.Load(ConfigFilePath);
            XmlNode AppSettingsNode = Doc.SelectSingleNode("//appSettings");

            foreach (ConfigItem CI in ChangedList)
            {
                foreach (XmlNode Node in AppSettingsNode)
                {
                    if (Node.NodeType == XmlNodeType.Element)
                    {
                        XmlElement Element = Node as XmlElement; //CI.Key

                        XmlAttribute Attr = Element.Attributes.GetNamedItem("key") as XmlAttribute;

                        if (Attr != null && Attr.Value == CI.Key)
                        {
                            Attr = Element.Attributes.GetNamedItem("value") as XmlAttribute;
                            if (Attr != null)
                            {
                                Attr.Value = CI.Value;
                                break;
                            }
                        }
                    }
                }
            }

            BackupConfigFile();
            Doc.Save(ConfigFilePath);

            return true;

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
        public string DisplayName { get; private set; }      // e.g. Microsoft Dynamics 365 Business Central Server [BC230]
        public string ServiceName { get; private set; }      // e.g. ??
        public string InstanceName { get; private set; }     // e.g. BC230
        public string ServiceFolder { get; private set; }    // e.g. C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\
        public string ConfigFilePath { get; private set; }   // e.g. C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\CustomSettings.config
        public List<ConfigItem> ConfigList { get; } = new List<ConfigItem>();
        public bool IsRunning { get { return Service.Status == ServiceControllerStatus.Running || Service.Status == ServiceControllerStatus.StartPending; } }
        public string LastBackupFilePath { get; private set; }

    }
}
