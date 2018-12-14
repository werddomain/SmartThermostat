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


	//  if (DataReceived)
	//  {
	//    if (ReceivedData[0] = 1)
	//      HandleSetPinState();
	//    
	//    memset(ReceivedData, 0, sizeof(ReceivedData));
	//    DataReceived = false;
	//  }

}

void receiveData(int numOfBytesReceived)
{
	int indexer = 0;
	while (Wire.available())
	{
		ReceivedData[indexer] = Wire.read();
		indexer++;
	}
	DataReceived = true;
}

void sendData()
{
	Response[0] = (byte)humidity;
	Response[1] = (byte)temperature;
	Response[2] = (byte)0;

	Wire.write(Response, 14);
}