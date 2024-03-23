using Microsoft.PowerShell.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace AxBcAdmin
{
    internal class PsCommand
    {
        const string CommandName = "Set-NAVServerConfiguration";
        BcService Service;
        InitialSessionState SessionState;
        SessionStateVariableEntry SessionStateEntry;
        //ModuleSpecification Module;
        string AdminModulePath;             // e.g. C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\NavAdminTool.ps1

 

        public PsCommand(BcService Service) 
        { 
            this.Service = Service;
            AdminModulePath = Path.Combine(Service.ServiceFolder, "NavAdminTool.ps1");   

            SessionState = InitialSessionState.Create(); 
            SessionState.ImportPSModulesFromPath(AdminModulePath);

            SessionStateEntry = new SessionStateVariableEntry("AllowedCommands", new[] { CommandName }, "Allowed command list.");
            SessionState.Variables.Add(SessionStateEntry);
        }

        public void SaveChanges(List<ConfigItem> ChangedList)
        {
            Collection<PSObject> InvokeResult;
            foreach (ConfigItem Item in ChangedList)
            {
                // Set-NAVServerConfiguration -ServerInstance $InstanceName -KeyName DatabaseName -KeyValue "DATABASE_NAME"
                using (PowerShell PS = PowerShell.Create(SessionState))
                {
                    try
                    {
                        PS.AddCommand(CommandName); // Set-NAVServerConfiguration
                        PS.AddParameter("-ServerInstance", Service.InstanceName);
                        PS.AddParameter("-KeyName", Item.Key);
                        PS.AddParameter("-KeyValue", Item.Value);
                        InvokeResult = PS.Invoke();
                    }
                    catch (Exception ex)
                    {
                        App.Log($"{Service.InstanceName}: Error on saving. Key = {Item.Key}, Value = {Item.Value}");
                        App.Log($"ERROR: {ex.Message}");
                    }
                }
            }

        }

 
    }
}
