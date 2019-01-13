# SmartThermostat

## Introduction
I have started this project to play around with Google Home using technologies im confortable with.
I dit not find anything using c# to work with Google SmartHome and DialogFlow API so i decide to make my own.

A raspberry pie 3 with a touch screen will be the Main Hub in the home.
Each arduino will receive commands and send sensor info to the Raspberry pie using [ESP8266 ESP-01S](https://www.banggood.com/5Pcs-ESP8266-ESP-01S-Remote-Serial-Port-WIFI-Transceiver-Wireless-Module-p-1116390.html?rmmds=myorder&cur_warehouse=CN) and/or  [NRF24L01+ SI24R1](https://www.banggood.com/5Pcs-NRF24L01-SI24R1-2_4G-Wireless-Power-Enhanced-Communication-Receiver-Module-p-1059601.html?rmmds=myorder&cur_warehouse=CN) to communicate with the pie

- Google will autenticate the user using our OAuth project, then it will get devices from the API Project.
- We will modify devices and Raspberry Pie screen with a web project using Angular. (Later maybe a mobile app using xamarin)
- I did not figure how devices will be syncronised or connected with the hub for now.

To configure all online stuff, read the Setup Readme

## RoadMap

 - [x] Oauth autentication
 - [x]  Google API endpoint in API
 - [x] API endpoint with authentication to Update Database objects
 - [x] SignalR setup to talk to Win IOT when google send commands
 - [x] SignalR authentication
 - [x] Base projects setup
 - [ ] Angular webproject authentication
 - [ ] Angular Pages to manage devices and scenes
 - [ ] Win 10 Iot Api/Autentication/SignalR
 - [ ] Arduino base projects for different uses

## Projects
![Project Diagram](https://github.com/werddomain/SmartThermostat/blob/master/Projects%20Diagram.svg)
[Diagram](https://mermaidjs.github.io/mermaid-live-editor/#/edit/eyJjb2RlIjoiZ3JhcGggTFJcbkEoKEdvb2dsZSBIb21lKSlcbkJ7U1QuV2ViLk9BdXRofVxuQyhTVC5XZWIuQW5ndWxhcilcbkR7U1QuV2ViLkFQSX1cbkV7U1QuV2luSW90LkFwcH1cbkZ7UGllQXJkdWlub31cbkEgLS0gQ29ubmVjdCAtLT4gQlxuQSAtLT4gRFxuQyAtLT4gRFxuRSAtLSBTaWduYWxSLS0-IERcbkMgLS0-IEJcbkUgLS0-IEJcbkUgLS0-IEZcbiIsIm1lcm1haWQiOnsidGhlbWUiOiJkZWZhdWx0In19)
|Project                   | Description                                               |
|--------------------------|-----------------------------------------------------------|
| PieArduino               | Arduino project who talk with Raspberry pie by I2C        |
| ST.SmartDevices          | Object For calls with the API                             |
| ST.WinIot.App            | Win 10 IOT Core for the raspberry pie                     |
| ST.WinIot.App.Web.Config | Static configuration for urls, names and api scoope       |
| ST.Web.API               | Asp .net Core 2.2 for API and SignalR                     |
| ST.Web.OAuth             | Asp .net Core 2.2 for OAuth with IdentityServer4          |
| ST.Web.Angular           | Asp .net Core 2.2 with Angular 7 to interact with the API |
|  |  |

### Technologies utilised
- [Arduino](https://www.arduino.cc/) (Hardware)
- [RaspberryPie](https://www.raspberrypi.org/) (Hardware)
- [Windows 10 IOT Core](https://developer.microsoft.com/en-us/windows/iot) (OS)
- [Universal Windows Platform (UWP)](https://docs.microsoft.com/en-us/windows/uwp/design/basics/design-and-ui-intro) (Framework)
- [Asp .net Core](https://www.asp.net/core/overview/aspnet-vnext) (Framework)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) (Flamework)
- [Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-2.2&tabs=visual-studio)(Framework)
- [Identity Server 4](https://identityserver.io/) (Library)
- [Angular 7](https://angular.io/) (Framework)
- [SignalR](https://www.asp.net/signalr) (Library)


<!--stackedit_data:
eyJoaXN0b3J5IjpbMjA5OTE0ODU3MCwxMzcyODEyMjgwXX0=
-->