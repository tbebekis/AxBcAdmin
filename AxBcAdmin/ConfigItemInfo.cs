namespace AxBcAdmin
{
    internal class ConfigItemInfo
    {
        static public List<string> ExcludeSettings = new List<string>() {
             "ProtectedDatabasePassword"
            ,""
        };

        static public readonly List<ConfigItemInfo> List = new List<ConfigItemInfo>()
        {

            new ConfigItemInfo("General", "AL Function Logging Threshold - Application Insights", "ALLongRunningFunctionTracingThresholdForApplicationInsights"),
            new ConfigItemInfo("General", "Application Insights Connection String", "ApplicationInsightsConnectionString"),
            new ConfigItemInfo("General", "Application Insights Instrumentation Key", "ApplicationInsightsInstrumentationKey"),
            new ConfigItemInfo("General", "Build Restriction", "ClientBuildRestriction"),
            new ConfigItemInfo("General", "Century Cutoff for 2-Digit Years", "CalendarTwoDigitYearMax"),
            new ConfigItemInfo("General", "Certificate Thumbprint", "ServicesCertificateThumbprint"),
            new ConfigItemInfo("General", "Compile and Load Business Application", "CompileBusinessApplicationAtStartup"),
            new ConfigItemInfo("General", "Credential Type", "ClientServicesCredentialType"),
            new ConfigItemInfo("General", "Data Cache Size", "DataCacheSize"),
            new ConfigItemInfo("General", "Default Client", "DefaultClient"),
            new ConfigItemInfo("General", "Default Language", "DefaultLanguage"),
            new ConfigItemInfo("General", "Default StartSession Timeout", "DefaultStartSessionTimeout"),
            new ConfigItemInfo("General", "Diagnostic Trace Level", "TraceLevel"),
            new ConfigItemInfo("General", "Diagnostic Trace Level for External Proxies", "ExternalTraceLevel"),
            new ConfigItemInfo("General", "Disable Token-Signing Certificate Validation", "DisableTokenSigningCertificateValidation"),
            new ConfigItemInfo("General", "Enable AL Function Timing", "ALFunctionTimingEnabled"),
            new ConfigItemInfo("General", "Enable Certificate Validation", "ServicesCertificateValidationEnabled"),
            new ConfigItemInfo("General", "Enable Debugging", "EnableDebugging"),
            new ConfigItemInfo("General", "Enable Event Logging to Windows Application Log", "EnableApplicationChannelLog"),
            new ConfigItemInfo("General", "Enable File Access by AL Functions", "EnableALServerFileAccess"),
            new ConfigItemInfo("General", "Enable Full AL Function Tracing", "EnableFullALFunctionTracing"),
            new ConfigItemInfo("General", "Enable Incremental Company Deletion", "UseIncrementalCompanyDelete"),
            new ConfigItemInfo("General", "Enable Partial Records", "EnablePartialRecords"),
            new ConfigItemInfo("General", "AllowSessionWhileSyncAndDataUpgrade	", "AllowSessionWhileSyncAndDataUpgrade"),
            new ConfigItemInfo("General", "Lockout Sign-In Attempts Count", "LockoutPolicyFailedAuthenticationCount"),
            new ConfigItemInfo("General", "Lockout Failed Sign-In Attempts Window", "LockoutPolicyFailedAuthenticationWindow"),
            new ConfigItemInfo("General", "Max Concurrent Calls", "MaxConcurrentCalls"),
            new ConfigItemInfo("General", "Max Data Rows Allowed to Send to Excel", "MaxRowsToExportToExcel"),
            new ConfigItemInfo("General", "Maximum Session Recursion", "MaximumSessionRecursionDepth"),
            new ConfigItemInfo("General", "Maximum Stream Read Size", "MaxStreamReadSize"),
            new ConfigItemInfo("General", "Multitenant", "Multitenant"),
            new ConfigItemInfo("General", "Network Protocol", "NetworkProtocol"),
            new ConfigItemInfo("General", "Services Default Company", "ServicesDefaultCompany"),
            new ConfigItemInfo("General", "Services Default Time Zone", "ServicesDefaultTimeZone"),
            new ConfigItemInfo("General", "Services Language", "ServicesLanguage"),
            new ConfigItemInfo("General", "Services Option Text Source", "ServicesOptionFormat"),
            new ConfigItemInfo("General", "Session Event Table Retain Interval", "SessionEventTableRetainInterval"),
            new ConfigItemInfo("General", "Non-Interactive Sessions Log Retain Interval", "NonInteractiveSessionsLogRetainInterval"),
            new ConfigItemInfo("General", "SessionEventTablePurgeLookupPeriod", "SessionEventTablePurgeLookupPeriod"),
            new ConfigItemInfo("General", "Supported Languages", "SupportedLanguages"),
            new ConfigItemInfo("General", "Token Signing Validation Mode", "TokenSigningCertificateValidationMode"),
            new ConfigItemInfo("General", "UI Elements Removal", "UIElementRemovalOption"),
            new ConfigItemInfo("General", "Use NTLM Authentication", "ServicesUseNTLMAuthentication"),
            new ConfigItemInfo("General", "GlobalSymbolReferenceCacheSize", "GlobalSymbolReferenceCacheSize"),
            new ConfigItemInfo("General", "GlobalSymbolReferenceCacheTTLInHours", "GlobalSymbolReferenceCacheTTLInHours"),
            new ConfigItemInfo("General", "PTESymbolReferenceCacheSize", "PTESymbolReferenceCacheSize"),
            new ConfigItemInfo("General", "PTESymbolReferenceCacheTTLInHours", "PTESymbolReferenceCacheTTLInHours"),
            new ConfigItemInfo("General", "XmlMetadataCacheSize", "XmlMetadataCacheSize"),


            new ConfigItemInfo("Database", "Database Instance", "DatabaseInstance"),
            new ConfigItemInfo("Database", "Database Name", "DatabaseName"),
            new ConfigItemInfo("Database", "Database Server", "DatabaseServer"),
            new ConfigItemInfo("Database", "Disable SmartSQL", "DisableSmartSql"),
            new ConfigItemInfo("Database", "Disable SQL Query Hint FORCE ORDER", "DisableQueryHintForceOrder"),
            new ConfigItemInfo("Database", "Disable SQL Query Hint LOOP JOIN", "DisablQueryHintLoopJoin"),
            new ConfigItemInfo("Database", "Disable SQL Query OPTIMIZE FOR UNKNOWN", "DisableQueryHintOptimizeForUnknown"),
            new ConfigItemInfo("Database", "Enable Buffered Insert", "BufferedInsertEnabled"),
            new ConfigItemInfo("Database", "Enable Deadlock Monitoring", "EnableDeadlockMonitoring"),
            new ConfigItemInfo("Database", "Enable Encryption on SQL Server Connections", "EnableSqlConnectionEncryption"),
            new ConfigItemInfo("Database", "Enable Lock Timeout Monitoring", "EnableLockTimeoutMonitoring"),
            new ConfigItemInfo("Database", "Enable SQL Read-Only Replica Support", "EnableSqlReadOnlyReplicaSupport"),
            new ConfigItemInfo("Database", "EnableTriStateLocking", "EnableTriStateLocking"),
            new ConfigItemInfo("Database", "Enable Trust of SQL Server Certificate", "TrustSQLServerCertificate"),
            new ConfigItemInfo("Database", "Search Timeout", "SearchTimeout"),
            new ConfigItemInfo("Database", "SQL Bulk Import Batch Size", "SqlBulkImportBatchSize"),
            new ConfigItemInfo("Database", "SQL Command Timeout", "SqlCommandTimeout"),
            new ConfigItemInfo("Database", "SQL Connection Idle Timeout", "SqlConnectionIdleTimeout"),
            new ConfigItemInfo("Database", "SQL Connection Timeout", "SqlConnectionTimeout"),
            new ConfigItemInfo("Database", "SQL Management Command Timeout", "SqlManagementCommandTimeout"),
            new ConfigItemInfo("Database", "Enable SQL Parameters by Ordinal", "SqlParametersByOrdinal"),
            new ConfigItemInfo("Database", "SQL Query Logging Threshold", "SqlLongRunningThreshold"),


            new ConfigItemInfo("Develompment", "Allowed Extension Target Level", "ExtensionAllowedTargetLevel"),
            new ConfigItemInfo("Develompment", "Debugger – Long Running SQL Statements Threshold", "LongRunningSqlStatementsInDebuggerThreshold"),
            new ConfigItemInfo("Develompment", "Debugger - Number of SQL Statements to Show", "AmountOfSqlStatementsInDebugger"),
            new ConfigItemInfo("Develompment", "Debugger - Show Long Running SQL Statements", "EnableLongRunningSqlStatementsInDebugger"),
            new ConfigItemInfo("Develompment", "Debugger - Show Long Running SQL Statements", "EnableSqlInformationDebugger"),
            new ConfigItemInfo("Develompment", "Debugging Allowed", "DebuggingAllowed"),
            new ConfigItemInfo("Develompment", "Enable Debugging", "EnableDebugging"),
            new ConfigItemInfo("Develompment", "Enable Developer Service Endpoint", "DeveloperServicesEnabled"),
            new ConfigItemInfo("Develompment", "Enable Loading Application Symbol References at Server Startup", "EnableSymbolLoadingAtServerStartup"),
            new ConfigItemInfo("Develompment", "Enable Multithreaded Compilation of Published Extensions Service Endpoint", "EnableMultithreadedCompilation"),
            new ConfigItemInfo("Develompment", "Enable SSL", "DeveloperServicesSSLEnabled"),
            new ConfigItemInfo("Develompment", "Enable Test Automation", "TestAutomationEnabled"),
            new ConfigItemInfo("Develompment", "HttpClient AL Function Maximum Timeout", "NavHttpClientMaxTimeout"),
            new ConfigItemInfo("Develompment", "HttpClient AL Function Response Size", "NavHttpClientMaxResponseContentSize"),
            new ConfigItemInfo("Develompment", "Port", "DeveloperServicesPort"),
            new ConfigItemInfo("Develompment", "ForceExtensionAllowedTargetLevel", "ForceExtensionAllowedTargetLevel"),


            new ConfigItemInfo("Client services", "Allowed File Types", "ClientServicesAllowedFileTypes"),
            new ConfigItemInfo("Client services", "Chunk Size", "ClientServicesChunkSize"),
            new ConfigItemInfo("Client services", "Compression Threshold", "ClientServicesCompressionThreshold"),
            new ConfigItemInfo("Client services", "Enable Client Services", "ClientServicesEnabled"),
            new ConfigItemInfo("Client services", "Exchange Auth. Metadata Location", "ExchangeAuthenticationMetadataLocation"),
            new ConfigItemInfo("Client services", "Idle Client Timeout", "ClientServicesIdleClientTimeout"),
            new ConfigItemInfo("Client services", "Keep Alive Interval", "ClientServicesKeepAliveInterval"),
            new ConfigItemInfo("Client services", "Max Concurrent Connections", "ClientServicesMaxConcurrentConnections"),
            new ConfigItemInfo("Client services", "Max Items in Object Graph", "ClientServicesMaxItemsInObjectGraph"),
            new ConfigItemInfo("Client services", "Max Number of Orphaned Connections", "ClientServicesMaxNumberOfOrphanedConnections"),
            new ConfigItemInfo("Client services", "Max Upload Size", "ClientServicesMaxUploadSize"),
            new ConfigItemInfo("Client services", "Operation Timeout", "ClientServicesOperationTimeout"),
            new ConfigItemInfo("Client services", "Port", "ClientServicesPort"),
            new ConfigItemInfo("Client services", "Prohibited File Types", "ClientServicesProhibitedFileTypes"),
            new ConfigItemInfo("Client services", "Protection Level", "ClientServicesProtectionLevel"),
            new ConfigItemInfo("Client services", "Reconnect Period", "ClientServicesReconnectPeriod"),
            new ConfigItemInfo("Client services", "ClientServicesSSLEnabled", "ClientServicesSSLEnabled"),
            new ConfigItemInfo("Client services", "Token Signing Key", "ClientServicesTokenSigningKey"),
            new ConfigItemInfo("Client services", "Use the Simplified Filters", "UseSimplifiedFilters"),
            new ConfigItemInfo("Client services", "Web Client Base URL", "PublicWebBaseUrl"),
            new ConfigItemInfo("Client services", "Windows Client Base URL", "PublicWinBaseUrl"),


            new ConfigItemInfo("SOAP services", "Enable SOAP Services", "SOAPServicesEnabled"),
            new ConfigItemInfo("SOAP services", "Enable SSL", "SOAPServicesSSLEnabled"),
            new ConfigItemInfo("SOAP services", "Max Connections", "SOAPMaxConnections"),
            new ConfigItemInfo("SOAP services", "Max Connections Per Tenant", "SOAPMaxConnectionsPerTenant"),
            new ConfigItemInfo("SOAP services", "Max Concurrent Requests", "SOAPMaxConcurrentRequests"),
            new ConfigItemInfo("SOAP services", "Max Queued Requests", "SOAPRequestQueueSize"),
            new ConfigItemInfo("SOAP services", "Max Message Size", "SOAPServicesMaxMsgSize"),
            new ConfigItemInfo("SOAP services", "Port", "SOAPServicesPort"),
            new ConfigItemInfo("SOAP services", "SOAP Base URL", "PublicSOAPBaseUrl"),
            new ConfigItemInfo("SOAP services", "Timeout", "SOAPServicesOperationTimeout"),


            new ConfigItemInfo("OData services", "APISubscriptionEnabled", "APISubscriptionEnabled"),
            new ConfigItemInfo("OData services", "APISubscriptionExpirtation", "APISubscriptionExpirtation"),
            new ConfigItemInfo("OData services", "APISubscriptionNotificationUrlTimeout", "APISubscriptionNotificationUrlTimeout"),
            new ConfigItemInfo("OData services", "APISubscriptionSendingNotificationTimeout", "APISubscriptionSendingNotificationTimeout"),
            new ConfigItemInfo("OData services", "APISubscriptionDelayTime", "APISubscriptionDelayTime"),
            new ConfigItemInfo("OData services", "APISubscriptionMaxNoOfNotifications", "APISubscriptionMaxNoOfNotifications"),
            new ConfigItemInfo("OData services", "APISubscriptionMaxNoOfSubscriptions", "APISubscriptionMaxNoOfSubscriptions"),
            new ConfigItemInfo("OData services", "Enable Add-in Annotations", "ODataEnableExcelAddInAnnotations"),
            new ConfigItemInfo("OData services", "Enable API Services", "ApiServicesEnabled"),
            new ConfigItemInfo("OData services", "Enable OData Services", "ODataServicesEnabled"),
            new ConfigItemInfo("OData services", "Enable Read-Only Intent-on GET Requests", "ODataReadonlyGetEnabled"),
            new ConfigItemInfo("OData services", "Enable SSL", "ODataServicesSSLEnabled"),
            new ConfigItemInfo("OData services", "Enable V3 Endpoint", "ODataServicesV3EndpointEnabled"),
            new ConfigItemInfo("OData services", "Enable V4 Endpoint", "ODataServicesV4EndpointEnabled"),
            new ConfigItemInfo("OData services", "ODataMaxBodySize", "ODataMaxBodySize"),
            new ConfigItemInfo("OData services", "Max Connections", "ODataMaxConnections"),
            new ConfigItemInfo("OData services", "Max Connections Per Tenant", "ODataMaxConnectionsPerTenant"),
            new ConfigItemInfo("OData services", "Max Page Size", "ODataServicesMaxPageSize"),
            new ConfigItemInfo("OData services", "Objects Exempt from Read-Only Intent on GET Requests", "ODataReadonlyGetDisabledForObjects"),
            new ConfigItemInfo("OData services", "OData Base URL", "PublicODataBaseUrl"),
            new ConfigItemInfo("OData services", "Port", "ODataServicesPort"),
            new ConfigItemInfo("OData services", "V3 Max Concurrent Requests", "ODataV4MaxConcurrentRequests"),
            new ConfigItemInfo("OData services", "V3 Max Queued Requests", "ODataV4MaxRequestQueueSize"),
            new ConfigItemInfo("OData services", "V4 Max Concurrent Requests", "ODataV4MaxConcurrentRequests"),
            new ConfigItemInfo("OData services", "V4 Max Queued Requests", "ODataV4MaxRequestQueueSize"),
            new ConfigItemInfo("OData services", "Timeout", "ODataServicesOperationTimeout"),
 
            new ConfigItemInfo("NAS services", "Enable Debugging", "NASServicesEnableDebugging"),
            new ConfigItemInfo("NAS services", "Run NAS Services with Admin Rights", "NASServicesRunWithAdminRights"),
            new ConfigItemInfo("NAS services", "Startup Argument", "NASServicesStartupArgument"),
            new ConfigItemInfo("NAS services", "Startup Codeunit", "NASServicesStartupCodeunit"),
            new ConfigItemInfo("NAS services", "Startup Method", "NASServicesStartupMethod"),


            new ConfigItemInfo("Management services", "Enable Management Services", "ManagementServicesEnabled"),
            new ConfigItemInfo("Management services", "Idle Client Timeout", "ManagementServicesIdleClientTimeout"),
            new ConfigItemInfo("Management services", "Port", "ManagementServicesPort"),
            new ConfigItemInfo("Management services", "ManagementApiServicesEnabled", "ManagementApiServicesEnabled"),
            new ConfigItemInfo("Management services", "ManagementApiServicesPort", "ManagementApiServicesPort"),
            new ConfigItemInfo("Management services", "ManagementApiServicesSSLEnabled", "ManagementApiServicesSSLEnabled"),



            new ConfigItemInfo("Azure key vault client identity", "Client Certificate Store Location", "AzureKeyVaultClientCertificateStoreLocation"),
            new ConfigItemInfo("Azure key vault client identity", "Client Certificate Store Name", "AzureKeyVaultClientCertificateStoreName"),
            new ConfigItemInfo("Azure key vault client identity", "Client Certificate Thumbprint", "AzureKeyVaultClientCertificateThumbprint"),
            new ConfigItemInfo("Azure key vault client identity", "Client ID", "AzureKeyVaultClientId"),


            new ConfigItemInfo("Azure key vault extension secrets", "Enable Publisher Validation", "AzureKeyVaultAppSecretsPublisherValidationEnabled"),



            new ConfigItemInfo("Microsoft Entra ID", "ADOpenIdMetadataLocation", "ADOpenIdMetadataLocation"),
            new ConfigItemInfo("Microsoft Entra ID", "Application Client Certificate Thumbprint", "AzureActiveDirectoryClientCertificateThumbprint"),
            new ConfigItemInfo("Microsoft Entra ID", "Application Client ID", "AzureActiveDirectoryClientId"),
            new ConfigItemInfo("Microsoft Entra ID", "Application Client Secret", "AzureActiveDirectoryClientSecret"),
            new ConfigItemInfo("Microsoft Entra ID", "Microsoft Entra app ID URI", "AppIdUri"),
            new ConfigItemInfo("Microsoft Entra ID", "Enable Membership Entitlement", "EnableMembershipEntitlement"),
            new ConfigItemInfo("Microsoft Entra ID", "Excel add-in AAD client app ID", "ExcelAddInAzureActiveDirectoryClientId"),
            new ConfigItemInfo("Microsoft Entra ID", "Extended Security Token Lifetime", "ExtendedSecurityTokenLifetime"),
            new ConfigItemInfo("Microsoft Entra ID", "Valid Audiences", "ValidAudiences"),
            new ConfigItemInfo("Microsoft Entra ID", "WS-Federation Login Endpoint", "WSFederationLoginEndpoint"),
            new ConfigItemInfo("Microsoft Entra ID", "WS-Federation Metadata Location", "ClientServicesFederationMetadataLocation"),



            new ConfigItemInfo("Data encryption", "Encryption Key Provider", "EncryptionProvider"),
            new ConfigItemInfo("Data encryption", "Key URI", "AzureKeyVaultKeyUri"),


            new ConfigItemInfo("Task scheduler", "Default Task Scheduler Session Timeout", "DefaultTaskSchedulerSessionTimeout"),
            new ConfigItemInfo("Task scheduler", "Enable Task Scheduler", "EnableTaskScheduler"),
            new ConfigItemInfo("Task scheduler", "Execution Retry Exceptions", "TaskSchedulerExecutionRetryExceptions"),
            new ConfigItemInfo("Task scheduler", "Maximum Concurrent Running Tasks", "TaskSchedulerMaximumConcurrentRunningTasks"),
            new ConfigItemInfo("Task scheduler", "System Task Start Time", "TaskSchedulerSystemTaskStartTime"),
            new ConfigItemInfo("Task scheduler", "System Task End Time", "TaskSchedulerSystemTaskEndTime"),
            new ConfigItemInfo("Task scheduler", "MaxTaskSchedulerSessionTimeout", "MaxTaskSchedulerSessionTimeout"),
            new ConfigItemInfo("Task scheduler", "XmlMetadataCacheSize", "XmlMetadataCacheSize"),


            new ConfigItemInfo("Asynchronous processing", "Background Sessions - Default Timeout", "BackgroundSessionsDefaultTimeout"),
            new ConfigItemInfo("Asynchronous processing", "Background Sessions - Default Wait Timeout", "BackgroundSessionsDefaultWaitTimeout"),
            new ConfigItemInfo("Asynchronous processing", "Background Sessions - Max Concurrent", "BackgroundSessionsMaxConcurrent"),
            new ConfigItemInfo("Asynchronous processing", "Background Sessions - Max Concurrent", "BackgroundSessionsMaxQueued"),
            new ConfigItemInfo("Asynchronous processing", "Child Sessions Max Concurrency", "ChildSessionsMaxConcurrency"),
            new ConfigItemInfo("Asynchronous processing", "Child Sessions Max Queue Length", "ChildSessionsMaxQueueLength"),
            new ConfigItemInfo("Asynchronous processing", "Page Background Task Allowed Automation Methods", "PageBackgroundTaskAllowedAutomationMethods"),
            new ConfigItemInfo("Asynchronous processing", "Page Background Task Default Timeout", "PageBackgroundTaskDefaultTimeout"),
            new ConfigItemInfo("Asynchronous processing", "Page Background Task Max Timeout", "PageBackgroundTaskMaxTimeout"),


            new ConfigItemInfo("Reports", "Default Max Documents", "ReportDefaultMaxDocuments"),
            new ConfigItemInfo("Reports", "Default Max Rendering Timeout", "ReportDefaultTimeout"),
            new ConfigItemInfo("Reports", "Default Max Rows", "ReporDefaultMaxRows"),
            new ConfigItemInfo("Reports", "Enable Application Domain Isolation", "ReportAppDomainIsolation"),
            new ConfigItemInfo("Reports", "Enable Save as Excel on Request Pages of RDLC-layout Reports", "EnableSaveToExcelForRdlcReports"),
            new ConfigItemInfo("Reports", "Enable Save as Word on Request Pages of RDLC-layout Reports", "EnableSaveToWordForRdlcReports"),
            new ConfigItemInfo("Reports", "Enable Save from Report Preview", "EnableSaveFromReportPreview"),
            new ConfigItemInfo("Reports", "Enforce Cloud Print Support", "ReportCloudPrintingEnforced"),
            new ConfigItemInfo("Reports", "Max Documents (hard limit)", "ReportMaxDocuments"),
            new ConfigItemInfo("Reports", "Max Rendering Timeout (hard limit)", "ReportTimeout"),
            new ConfigItemInfo("Reports", "Max Rows (hard limit)", "ReportMaxRows"),
            new ConfigItemInfo("Reports", "Report PDF Font Embedding", "ReportPDFFontEmbedding"),
            new ConfigItemInfo("Reports", "ReportingServicePort", "ReportingServicePort"),
            new ConfigItemInfo("Reports", "CalculateBestPaperSizeForReportPrinting", "CalculateBestPaperSizeForReportPrinting"),


            new ConfigItemInfo("Query", "Max Execution Timeout", "QueryTimeout"),
            new ConfigItemInfo("Query", "Max Rows", "QueryMaxRows"),


            new ConfigItemInfo("Extensions", "Enable Profile Cache Synchronization", "EnableProfileCacheSynchronization"),
            new ConfigItemInfo("Extensions", "Overwrite Existing Translations", "OverwriteExistingTranslations"),
            new ConfigItemInfo("Extensions", "Required Extensions", "RequiredExtensions"),
            new ConfigItemInfo("Extensions", "Solution Version Extension", "SolutionVersionExtension"),




            new ConfigItemInfo("Compatibility", "AL Legacy Compatible Date Format Culture List", "ALCompatibleDateFormatCultureList"),
            new ConfigItemInfo("Compatibility", "Enable Client Callbacks in Write Transactions", "AllowSessionCallSuspendWhenWriteTransactionStarted"),
            new ConfigItemInfo("Compatibility", "Enable Cloud Replication Maintenance", "EnableCloudReplicationMaintenance"),
            new ConfigItemInfo("Compatibility", "Security Protocol", "SecurityProtocol"),
            new ConfigItemInfo("Compatibility", "Unsupported Language IDs", "UnsupportedLanguageIds"),
            new ConfigItemInfo("Compatibility", "Use Client Timestamp For Report Execution Timestamp", "ReplaceReportExecutionTimeWithClientTime"),
            new ConfigItemInfo("Compatibility", "Use FIND('-') to Populate Pages Instead of FIND('=><')", "UseFindMinusWhenPopulatingPage"),
            new ConfigItemInfo("Compatibility", "Use Permission Sets From Extensions", "UsePermissionSetsFromExtensions"),

        };

        /* construction */
        public ConfigItemInfo() { }
        public ConfigItemInfo(string Category, string Name, string Key)
        {
            this.Category = Category;
            this.Name = Name;
            this.Key = Key;
        }

        /* properties */
        public string Category { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
    }

}
