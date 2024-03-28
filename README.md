# AxBcAdmin

## Introduction
This application is an administration tool for any version of Microsoft Business Central **on-premises** and it aims to make it easy to manage the Business Central Server configuration.

Microsoft has retired the native `Business Central Admin` application in the BC 2022 Release Wave 2 (v21) on-premises version. 

A non polite action.

## The settings file

Business Central Server configuration settings are stored in a file called `CustomSettings.config`.

The default location of the CustomSettings.config file is 

    `C:\Program Files\Microsoft Dynamics 365 Business Central\BC_VERSION\Service`.

That `CustomeSettings.config` is an XML file with multiple entries like the following

	`<add key="ServerInstance" value="BC230" />`

Configuration keys are predefined strings and are described in the [Configuring Business Central Server](https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/administration/configure-server-instance) topic, in Microsoft Docs.
	
The recommended way to manage CustomSettings.config settings is now to use the following PowerShell cmdlet, e.g.

	`Set-NAVServerConfiguration -ServerInstance "BC230" -KeyName ServerInstance -KeyValue "BC230_Prod"`

Not acceptable.

## The AxBcAdmin features

This application is not as elegant as the good-old Microsoft `Business Central Admin` tool was, but nevertheless achieves the same goal.

The administrator can

- start, restart or stop the BC service
- configure any available setting
- configure Database Credentials
- export and import BC License

## How AxBcAdmin works

Just uncompress the `AxBcAdmin.zip` file somewhere in the Business Central server machine and then run the AxBcAdmin.exe.

This application searches [Window Services](https://en.wikipedia.org/wiki/Windows_service) of the local machine, collects any service with a name starting as `Microsoft Dynamics 365 Business Central Server` and displays these services in a grid.

The administrator may select a BC service to start, restart, stop, edit its configuration and configure database credentials. This application writes any setting change directly to `CustomeSettings.config` file.

The application reads the `CustomeSettings.config` file of the selected BC service and creates an input control for any setting it founds in the file. It also splits settings into Categories. Each Category is displayed in its own tab page.

The `Database Credentials` toolbar button displays a dialog box where the administrator may configure the [database authentication](https://learn.microsoft.com/en-us/dynamics365/business-central/dev-itpro/administration/configure-sql-server-authentication) of the BC server.

The `Export License` and `Import License` toolbar buttons are used in exporting and importing licenses to the BC server.



 