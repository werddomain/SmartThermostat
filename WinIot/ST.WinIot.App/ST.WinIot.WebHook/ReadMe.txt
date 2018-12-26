[WebSite]

Initialisation: (Make sure the default connection string is valid before calling these commands)
dotnet ef database update --context ApplicationDbContext
dotnet run /seed


You will need a certificate to run the website, get one free here: https://www.mikesdotnetting.com/article/305/free-ssl-certificates-on-iis-with-letsencrypt
You can alsow use this tool to create and manage Certificates : https://certifytheweb.com/ 

Setup Environement varriable in IIS : https://stackoverflow.com/questions/31049152/publish-to-iis-setting-environment-variable/31049392
*Note : You can add IIS environement varriable by using this command line:
appcmd.exe set config -section:system.applicationHost/applicationPools /+"[name='DefaultAppPool'].environmentVariables.[name='VAR',value='val']" /commit:apphost`

in the IIS Website, create 2 application : Auth and API (UI is at the root if the website)

self-signed certificate: Create a certificate (It can be the same as the one you created for iis) and put it's name in the environement varriable : "Security:CertificateCN" = "CN=MyCertificateName" 