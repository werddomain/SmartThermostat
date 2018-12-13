
using Microsoft.IoT.Lightning.Providers;
using Sensors.Dht;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices;
using Windows.Devices.Gpio;
using Windows.UI.Xaml;

namespace ST.WinIot.App.Sensors
{
    public class DHT22: BaseModel
    {
        private const int DHTPIN = 4;

        private IDht dht = null;

        private GpioPin dhtPin = null;

        private DispatcherTimer sensorTimer = new DispatcherTimer();


        private string pTemperature;
        public string Temperature
        {
            get { return pTemperature; }
            set { pTemperature = value; RaisePropertyChange("Temperature"); }
        }


        private string pHumidity;
        public string Humidity
        {
            get { return pHumidity; }
            set { pHumidity = value; RaisePropertyChange("Humidity"); }
        }

        public delegate void SensorReadDelegate(double TemperatureC, double Humidity);
        public event SensorReadDelegate SensorRead;

        public DHT22() {
            if (!InDesing)
            {
                if (LightningProvider.IsLightningEnabled)
                {
                    LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
                }

                dhtPin = GpioController.GetDefault().OpenPin(DHTPIN, GpioSharingMode.Exclusive);

                dht = new Dht22(dhtPin, GpioPinDriveMode.Input);

                sensorTimer.Interval = TimeSpan.FromSeconds(3);

                sensorTimer.Tick += sensorTimer_Tick;

                sensorTimer.Start();
            }
        }
        private void sensorTimer_Tick(object sender, object e)

        {

            readSensor();

        }

        private async void readSensor()

        {

            double temp = 0;

            double humidity = 0;



            DhtReading reading = await dht.GetReadingAsync().AsTask();

            if (reading.IsValid)

            {
                
                temp = reading.Temperature;

                humidity = reading.Humidity;



                Temperature = string.Format("{0:0.0}", temp);

                Humidity = string.Format("{0:0}", humidity);

                SensorRead?.Invoke(temp, humidity);
            }

        }
    }
}
