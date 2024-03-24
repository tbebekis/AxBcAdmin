

namespace AxBcAdmin
{

    // NOTE: I tried to do it "by the book"
    // but I found no way to make ImportPSModulesFromPath() to work
    // so the last resort is to use the XmlDoc



    /*
    

using Microsoft.PowerShell.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

    internal class PsCommand
    {
 
        const string CommandName = "Set-NavServerConfiguration";
        BcService BCS;
        InitialSessionState SessionState;
        SessionStateVariableEntry SessionStateEntry;
        Runspace Runspace;
        //ModuleSpecification Module;
        string AdminModulePath;             // e.g. C:\Program Files\Microsoft Dynamics 365 Business Central\230\Service\NavAdminTool.ps1
 
        public PsCommand(BcService BCS) 
        { 
            this.BCS = BCS;
            AdminModulePath = Path.Combine(BCS.ServiceFolder, "NavAdminTool.ps1");   

            SessionState = InitialSessionState.CreateDefault2();
            SessionState.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.Unrestricted;

            // CAUTION: NOT WORKING
            // Module.Count is always 0
            SessionState.ImportPSModulesFromPath(AdminModulePath);

            Runspace = RunspaceFactory.CreateRunspace(SessionState);
            Runspace.Open();

            //SessionStateEntry = new SessionStateVariableEntry("AllowedCommands", new[] { CommandName }, "Allowed command list.");
            //SessionState.Variables.Add(SessionStateEntry);
        }
 
 
        public void SaveChanges(List<ConfigItem> ChangedList)
        {
            Collection<PSObject> InvokeResult;
            foreach (ConfigItem Item in ChangedList)
            {
                // Set-NAVServerConfiguration -ServerInstance $InstanceName -KeyName DatabaseName -KeyValue "DATABASE_NAME"
                using (PowerShell PS = PowerShell.Create(SessionState))
                {
                    PS.Runspace = Runspace;
                    try
                    {    

                        PS.AddCommand(CommandName, true); // Set-NAVServerConfiguration
                        PS.AddParameter("-ServerInstance", BCS.InstanceName);
                        PS.AddParameter("-KeyName", Item.Key);
                        PS.AddParameter("-KeyValue", Item.Value);
                        InvokeResult = PS.Invoke();
                    }
                    catch (Exception ex)
                    {
                        App.Log($"{BCS.InstanceName}: Error on saving. Key = {Item.Key}, Value = {Item.Value}");
                        App.Log($"ERROR: {ex.Message}");
                    }
                }
            }

        }

 
    }
    */
}
