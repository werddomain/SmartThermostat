
# ST.Web.API
### This project is the core of the application. It's the link between all the parts of the application.

- Google, autenticated with [Web.OAuth](https://github.com/werddomain/SmartThermostat/tree/master/WinIot/ST.WinIot.App/Web/OAuth), will call this endpoint when new command is sent from the user.
- The [WinIot.App](https://github.com/werddomain/SmartThermostat/tree/master/WinIot/ST.WinIot.App/ST.WinIot.App) application, autenticated with Web.OAuth, is connected to this endpoint through SignalR, so it get instant callback when new command is isued by google.
- [Web.Angular](https://github.com/werddomain/SmartThermostat/tree/master/WinIot/ST.WinIot.App/Web/Angular), autenticated with Web.OAuth, manage devices and scenes data served by this endpoint.

This project use:
- EntityFramework for database communication
- IdentityServer 4 to validate OAuth token
- SignalR for communication with WinIot.App
- WebApi for communication with Web.Angular
- [Swagger](https://swagger.io/) to generate documentation about the API

## Configuration

 Build Database. There is a bat file called `builddb.bat` who will do all the stuff needed to create database shema. The database can be the same or different from the one used in API.
 If you have error, you can delete the migration folder `\Data\Migration` and run it again.



