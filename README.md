# SmartThermostat


Windows 10 Iot on Raspberry Pie 3 connected with smart home control

I have started this project to test if this kind of project can be done with Win 10 IOT and try to integrate google home assistant.

The raspberry pie with Win 10 IOT will act as a hub in the house. It will be able to dispatch commands to others arduino in the house.
The same device will display sensors informations and will be in charge of enabling relays as a Thermostat will do.

I plan to use ESP8266 ESP-01S to communicate with others arduino.

A asp.net core 2.2 Web APP will talk with google with gRPC and we will connect to this web server to sync devices.

We will be able to add devices in the Hub (Wish have a touch screen) and using the web interface. Maybe later i will add a mobile app using xamarin.

I'M learning how all this stuf work together.
