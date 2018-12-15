/*
 Name:		PieArduino.ino
 Created:	12/12/2018 9:59:16 PM
 Author:	Benoit R.
*/
// Test to use arduino readed data to Windows 10 IOT Core
//From this Blog http://theprogrammator.net/2016/06/07/read-arduino-sensor-data-from-a-raspberry-pi-using-i2c-and-windows-10-iot/

// the setup function runs once when you press reset or power the board

#include <DHT_U.h>
#include <DHT.h>
#include <Wire.h>

#define SPI_SLAVE_ADDRESS 0x40
#define DHTPIN 2
#define DHTTYPE DHT22
DHT dht(DHTPIN, DHTTYPE);

byte      ReceivedData[14];
byte      Response[14];
bool      DataReceived;

float humidity;
float temperature;

// ***
// *** Holds the last command and parameter sent by the master.
uint8_t _lastCommand = 0;
uint8_t _lastParameter = 0;

void setup() {
	// put your setup code here, to run once:
	dht.begin();

	Wire.begin(SPI_SLAVE_ADDRESS);
	Wire.onReceive(receiveData);
	Wire.onRequest(sendData);

	DataReceived = false;
}

void loop() {
	// put your main code here, to run repeatedly:
	if (!DataReceived) {
		// Reading temperature or humidity takes about 250 milliseconds!
		// Sensor readings may also be up to 2 seconds 'old' (its a very slow sensor)
		delay(2000);
		float h = dht.readHumidity();
		// Read temperature as Celsius (the default)
		float t = dht.readTemperature();
		if (isnan(h) || isnan(t)) {
			Serial.println("Failed to read from DHT sensor!");
			return;
		}
		humidity = h;
		temperature = t;
		Serial.print("H: ");
		Serial.print(h);
		Serial.print(" T: ");
		Serial.println(t);

	}
	//  if (DataReceived)
	//  {
	//    if (ReceivedData[0] = 1)
	//      HandleSetPinState();
	//    
	//    memset(ReceivedData, 0, sizeof(ReceivedData));
	//    DataReceived = false;
	//  }

}
void clearResponse()
{
	memset(Response, 0, sizeof(Response));
	// ***
  // *** Set all the bytes to 0
  // ***
	Serial.print("Clearing Response :");
	for (int i = 0; i < sizeof(Response); i++)
	{
		Response[i] = 0;
		Serial.print(i);
	}
	Serial.println(" Done");
}
void receiveData(int numOfBytesReceived)
{
	// ***
 // *** We are expecting 2 bytes from the master. The first byte is the command.
 // *** the second byte is the command parameter.
 // ***
 // *** Commands:
 // ***
 // *** 1 => GetData.
 // *** 2 => SetData.
 // ***
 // *** Parameters:
 // *** 10 => Temperature
 // *** 11 => Humidity
	Serial.print("Received Data: Size:");
	Serial.print(numOfBytesReceived);
	Serial.print(" ");

	if (numOfBytesReceived == 2)
	{
		// ***
		// *** Store the command and parameter.
		// ***
		_lastCommand = Wire.read();
		_lastParameter = Wire.read();
		Serial.print("Command:");
		Serial.print(_lastCommand);
		Serial.print(" Param:");
		Serial.println(_lastParameter);
		DataReceived = true;
	}
	else
	{
		// ***
		// *** Clear the receive buffer.
		// ***
		while (Wire.available())
		{
			Wire.read();
		}

		// ***
		// *** Reset
		// ***
		_lastCommand = 0;
		_lastParameter = 0;
	}
}

typedef union
{
	float number;
	uint8_t bytes[4];
} FLOATUNION_t;

const byte ID_Temperature = 10;
const byte ID_Humidity = 11;

const byte  Type_Float = 100;

void Pack(byte identifier, float value, byte data[])
{
	FLOATUNION_t u;
	u.number = value;
	data[0] = (byte)1;
	data[1] = identifier;
	data[2] = Type_Float;
	data[3] = u.bytes[0];
	data[4] = u.bytes[1];
	data[5] = u.bytes[2];
	data[6] = u.bytes[3];

}

void sendData()
{
	/*FLOATUNION_t Hum;
	FLOATUNION_t Temp;

	Hum.number = humidity;
	Temp.number = temperature;*/

	/*Response[0] = (byte)humidity;
	Response[1] = (byte)temperature;*/

	clearResponse();
	bool hit = false;
	if (_lastCommand == 1)
		switch (_lastParameter)
		{
		case ID_Humidity:
			Pack(ID_Humidity, humidity, Response);
			hit = true;
			break;
		case ID_Temperature:
			Pack(ID_Temperature, temperature, Response);
			hit = true;
			break;
		}
	if (!hit) {
		Response[0] = 40;
		Response[1] = 4;
		Response[3] = _lastCommand;
		Response[4] = _lastParameter;
	}
	Wire.write(Response, 14);
	DataReceived = false;
}