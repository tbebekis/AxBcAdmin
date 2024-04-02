using System;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AxBcAdmin
{

    /// <summary>
    /// Represents a Business Central service (Windows Service)
    /// </summary>
    internal class BcService
    {
        /* private */
        static readonly string ServicePrefix = "Microsoft Dynamics 365 Business Central Server";
        static List<BcService> fServices;
        ServiceController Service;

        /// <summary>
        /// Waits for the BC service to reach a specified status.
        /// <para>It tries a specified number of times with a specified timeout in between.</para>
        /// </summary>
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
        /// <summary>
        /// Backups the <c>CustomSettings.config</c> file, just before write any change to it.
        /// </summary>
        void BackupConfigFile()
        {
            string BackupFolder = Path.Combine(App.AppFolder, "Backup");
            Directory.CreateDirectory(BackupFolder);
            string FileName = "CustomSettings Backup " + DateTime.Now.ToFileName() + ".XML";
            LastBackupFilePath = Path.Combine(BackupFolder, FileName);

            File.Copy(ConfigFilePath, LastBackupFilePath, true);
        }

        /* construction */
        /// <summary>
        /// Constructor.
        /// <para>Uses the <see cref="ManagementObject"/> class to get the "PathName" entry of the BC service. </para>
        /// <para>Analyzes the "PathName" entry and and gets the service folder and the path to <c>CustomSettings.config</c>. </para>
        /// </summary>
        public BcService(ServiceController Service)
        {
            this.Service = Service;

            // DisplayName example: Microsoft Dynamics 365 Business Central Server [BC230]
            string S = Service.DisplayName.Remove(0, ServicePrefix.Length).Trim();
            if (S.StartsWith("["))
                S = S.Remove(0, 1);
            if (S.EndsWith("]"))
                S = S.Remove(S.Length - 1, 1);

            this.DisplayName = Service.DisplayName;
            this.ServiceName = Service.ServiceName;
            this.InstanceName = S; 

            using (ManagementObject wmiService = new ManagementObject($"Win32_Service.Name='{Service.ServiceName}'"))  
            {
                wmiService.Get();
                S = wmiService["PathName"].ToString().Trim();                

                // "C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\Microsoft.Dynamics.Nav.Server.exe" $BC230 /config "C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\Microsoft.Dynamics.Nav.Server.dll.config"
                if (S[0] == '"')
                {
                    int Index = S.IndexOf('"', 1);
                    S = S.Substring(1, Index - 1);

                    ServiceFolder = Path.GetDirectoryName(S);                    
                }
            }

            if (string.IsNullOrWhiteSpace(ServiceFolder))
                App.Throw("Cannot find Business Central service path.");

            ConfigFilePath = Path.Combine(ServiceFolder, "CustomSettings.config");

            if (!File.Exists(ConfigFilePath))
                App.Throw($"Settings File '{ConfigFilePath}' not found"); 
        }

        /* public */
        /// <summary>
        /// Override. Returns a string representation of this instance.
        /// </summary>
        public override string ToString()
        {
            return !string.IsNullOrWhiteSpace(InstanceName) ? InstanceName : base.ToString();
        }

        /// <summary>
        /// Restarts the service.
        /// </summary>
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
        /// <summary>
        /// Starts the service.
        /// </summary>
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
        /// <summary>
        /// Stops the service.
        /// </summary>
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


        /// <summary>
        /// Removes all items from the <see cref="ConfigList"/>.
        /// <para><see cref="ConfigList"/> is a list of <see cref="ConfigItem"/> instances. </para>
        /// <para>A <see cref="ConfigItem"/> instance represents a settings in the <c>CustomSettings.config</c> file.</para>
        /// </summary>
        public void ClearConfig()
        {
            ConfigList.Clear();
        }
        /// <summary>
        /// Loads <see cref="ConfigList"/> with <see cref="ConfigItem"/> instances, by reading the <c>CustomSettings.config</c> file.
        /// <para>A <see cref="ConfigItem"/> instance represents a settings in the <c>CustomSettings.config</c> file.</para>
        /// </summary>
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
        /// <summary>
        /// Saves any changes made to <see cref="ConfigItem"/> instances, to the <c>CustomSettings.config</c> file.
        /// <para>A <see cref="ConfigItem"/> instance represents a settings in the <c>CustomSettings.config</c> file.</para>
        /// </summary>
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
 
        /// <summary>
        /// Uses the <see cref="Process"/> class in order to execute PowerShell a list of specified commands.
        /// </summary>
        void ExecutePowerShell(List<string> SourceLines)
        {
            StringBuilder sbErrors = new StringBuilder();
            StringBuilder sbOutput = new StringBuilder();

            ProcessStartInfo PSI = new ProcessStartInfo();
            PSI.UseShellExecute = false;
            PSI.FileName = "powershell.exe";
            PSI.WindowStyle = ProcessWindowStyle.Hidden;
            PSI.CreateNoWindow = true;
            PSI.RedirectStandardError = true;
            PSI.RedirectStandardInput = true;
            PSI.RedirectStandardOutput = true;

            using (Process P = new Process())
            {
                P.StartInfo = PSI;
                P.ErrorDataReceived += (sender, e) => { sbErrors.AppendLine(e.Data); };
                P.OutputDataReceived += (sender, e) => { sbOutput.AppendLine(e.Data); };

                P.Start();

                using (StreamWriter SW = P.StandardInput)
                {
                    if (SW.BaseStream.CanWrite)
                    {
                        foreach (string Line in SourceLines)
                            SW.WriteLine(Line);
                    }
                }

                P.BeginOutputReadLine();
                P.BeginErrorReadLine();
                P.WaitForExit();
            }


            if (sbErrors.ToString().Trim().Length > 0)
                App.Throw(sbErrors.ToString());

            if (sbOutput.Length > 0)
                App.Log(sbOutput.ToString());

        }
        
        /// <summary>
        /// Sets Windows Authentication as authentication mode of the service to its database.
        /// </summary>
        bool SetWindowsAuthentication()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load(ConfigFilePath);
            XmlNode AppSettingsNode = Doc.SelectSingleNode("//appSettings");

            string[] DatabaseKeys = { "DatabaseUserName", "ProtectedDatabasePassword" };
            int Count = 0;

            foreach (string Key in DatabaseKeys)
            {
                foreach (XmlNode Node in AppSettingsNode)
                {
                    if (Node.NodeType == XmlNodeType.Element)
                    {
                        XmlElement Element = Node as XmlElement; //CI.Key

                        XmlAttribute Attr = Element.Attributes.GetNamedItem("key") as XmlAttribute;

                        if (Attr != null && Attr.Value == Key)
                        {
                            Attr = Element.Attributes.GetNamedItem("value") as XmlAttribute;
                            if (Attr != null)
                            {
                                Attr.Value = "";
                                Count++;
                                break;
                            }
                        }
                    }
                }
            }

            BackupConfigFile();
            Doc.Save(ConfigFilePath);

            return Count == DatabaseKeys.Length;
        }
        /// <summary>
        /// Sets SQL Server Authentication as authentication mode of the service to its database.
        /// </summary>
        bool SetSqlServerAuthentication(string UserName, string Password)
        {
            BackupConfigFile();

            List<string> SourceLines = new List<string>();

            SourceLines.Add($"Import-Module '{NavAdminToolFilePath}'");
            SourceLines.Add($"$UserName = '{UserName}'");
            SourceLines.Add($"$Password = '{Password}'");
            SourceLines.Add($"$Password = ConvertTo-SecureString -String $Password -AsPlainText -Force");
            SourceLines.Add($"$Creds = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $UserName, $Password");
            SourceLines.Add($"Set-NAVServerConfiguration -ServerInstance '{InstanceName}' -DatabaseCredentials $Creds");

            ExecutePowerShell(SourceLines);

            return true;
        }

        /// <summary>
        /// Sets the database credentials used by the service in order to authenticate to its database.
        /// <para>Passing empty strings means Windows Authentication, else SQL Server Authentication is used. </para>
        /// </summary>
        public bool SetDatabaseCredentials(string UserName, string Password)
        {
            // Windows Authentication -> Clear Database Credentials
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password)) 
                return SetWindowsAuthentication();
            else // SQL Server Authentication -> Set Database Credentials
                return SetSqlServerAuthentication(UserName, Password);
        }

        /// <summary>
        /// Exports the current BC license to the log.
        /// </summary>
        public void ExportLicense()
        {
            List<string> SourceLines = new List<string>();

            SourceLines.Add($"Import-Module '{NavAdminToolFilePath}'");
            SourceLines.Add($"Export-NAVServerLicenseInformation -ServerInstance '{InstanceName}'");

            ExecutePowerShell(SourceLines);             
        }
        /// <summary>
        /// Imports a BC lincense to the BC server.
        /// </summary>
        public void ImportLicense(string LicenseFilePath)
        {
            List<string> SourceLines = new List<string>(); 

            SourceLines.Add($"Import-Module '{NavAdminToolFilePath}'");
            SourceLines.Add($"$LicensePath = '{LicenseFilePath}'");
            SourceLines.Add($"Import-NAVServerLicense -ServerInstance '{InstanceName}' -LicenseFile $LicensePath");
            ExecutePowerShell(SourceLines);             
        }

        /* properties */
        /// <summary>
        /// Returns a list of all BC services in the local machine.
        /// </summary>
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
                        if (Service.DisplayName.Contains(ServicePrefix, StringComparison.InvariantCultureIgnoreCase))
                        {
                            BcService Item = new BcService(Service);
                            fServices.Add(Item);
                        }
                        else
                        {
                            Service.Dispose();
                        }
                    }
                }

                return fServices;

            }
        }
        
        /// <summary>
        /// The status of the BC service
        /// </summary>
        public ServiceControllerStatus Status { get { return Service.Status; } }
        /// <summary>
        /// A string representation of the status of the BC service
        /// </summary>
        public string StatusText { get { return Service.Status.ToString(); } }
        /// <summary>
        /// Service Display Name, e.g. <c> Microsoft Dynamics 365 Business Central Server [BC230]</c>
        /// </summary>
        public string DisplayName { get; private set; }      // e.g. Microsoft Dynamics 365 Business Central Server [BC230]
        /// <summary>
        /// Service Name, e.g. <c>MicrosoftDynamicsNavServer$BC230</c>
        /// </summary>
        public string ServiceName { get; private set; }      // e.g. MicrosoftDynamicsNavServer$BC230
        /// <summary>
        /// Instance Name, e.g. <c>BC230</c>
        /// </summary>
        public string InstanceName { get; private set; }     // e.g. BC230
        /// <summary>
        /// Service folder, e.g. <c>C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\</c>
        /// </summary>
        public string ServiceFolder { get; private set; }    // e.g. C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\
        /// <summary>
        /// Config path, e.g. <c>C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\CustomSettings.config</c>
        /// </summary>
        public string ConfigFilePath { get; private set; }   // e.g. C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\CustomSettings.config
        /// <summary>
        /// Path to the BC Admin Power Shell module, e.g. <c>C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\NavAdminTool.ps1</c>
        /// </summary>
        public string NavAdminToolFilePath { get { return Path.Combine(ServiceFolder, "NavAdminTool.ps1"); } }
        /// <summary>
        /// <para>A list of <see cref="ConfigItem"/> instances. </para>
        /// <para>A <see cref="ConfigItem"/> instance represents a settings in the <c>CustomSettings.config</c> file.</para>
        /// </summary>
        public List<ConfigItem> ConfigList { get; } = new List<ConfigItem>();
        /// <summary>
        /// True when BC service is running.
        /// </summary>
        public bool IsRunning { get { return Service.Status == ServiceControllerStatus.Running || Service.Status == ServiceControllerStatus.StartPending; } }
        /// <summary>
        /// The path of the last backup of the <c>CustomSettings.config</c>  file
        /// </summary>
        public string LastBackupFilePath { get; private set; }

    }
}
