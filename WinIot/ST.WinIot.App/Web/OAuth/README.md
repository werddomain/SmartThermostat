# Web.OAuth
Using identity server 4 this project is only in charge of authentication. 


## Configuration
You will need an ssl certificate. I recommand using https://Certifytheweb.com to get free certificate. It's an application to generate free certificates. You can alsow use [win-acme](https://github.com/PKISharp/win-acme) , it create windows tasks to renew the certificate automatically.

## 1) Set configurations

 **[appsettings.json]**
This settings will be use when using `dotnet run` command or when debugging using IISExpres
- **Authentication.Google** is OAuth Client ID/Secret keys
- **Google.Apikey** is your google HomeGraph API Key
- **Google.GoogleProjectId** is the [google action](https://console.actions.google.com) project Id
- **Google.OurOpenId** is the ClientId and Secret you give to google to authencicate users
- **Security.CertificateCN** is the certificate name in the certificate store
- **AngularConfig.AuthClientId** is the ClientId used in angular

**[launchSettings.json]**
you will need to set environement varriables in this file to debug it ussing IIS. In production, you will need to setup each one in IIS. 
Sames setting from **appsettings.json** :

    "environmentVariables": {
			"ASPNETCORE_ENVIRONMENT": "Development",
			"Authentication:Google:ClientId": "",
			"Authentication:Google:ClientSecret": "",
			"Google:ApiKey": "",
			"Google:GoogleClientId": "",
			"Google:OurOpenId:ClientId": "",
			"Google:OurOpenId:ClientSecret": "",
			"Security:CertificateCN": "CN=NAME",
			"ConnectionStrings:DefaultConnection": "Data Source=localhost;Initial Catalog=DataBaseName;Integrated Security=True",
			"AngularConfig:AuthClientId": ""

		}
**[Config.cs]**
Here is the configuration used to generate database config using the /seed command.
If you need to add some other authentication, you need to run `dotnet run /seed` to populate the changes to the database.

 **[ST.Web.Config (Project)]**
In this project, i store configurations about static and **non sensible** configuration.

### 2) Build Database

There is a bat file called `builddb.bat` who will do all the stuff needed to create database shema. The database can be the same or different from the one used in API