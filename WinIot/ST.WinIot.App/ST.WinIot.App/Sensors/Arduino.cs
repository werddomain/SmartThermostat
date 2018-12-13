using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;
using Windows.UI.Xaml;

namespace ST.WinIot.App.Sensors
{
    public class Arduino: BaseModel
    {
        private I2cDevice _device;
        private Timer _periodicTimer;



        public Arduino():base() {
            if (!InDesing)
            {
                InitI2C();
            }
        }

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

        private async void InitI2C()
        {
            var settings = new I2cConnectionSettings(0x40); // Arduino address
            settings.BusSpeed = I2cBusSpeed.StandardMode;
            string aqs = I2cDevice.GetDeviceSelector("I2C1");
            var dis = await DeviceInformation.FindAllAsync(aqs);
            _device = await I2cDevice.FromIdAsync(dis[0].Id, settings);
            _periodicTimer = new Timer(TimerCallback, null, 0, 1000); // Create a timer
        }

        private void TimerCallback(object state)
        {
            try
            {
                byte[] ReadBuf = new byte[14];
                
                _device.Read(ReadBuf);
                //Float communication in i2c : https://www.raspberrypi.org/forums/viewtopic.php?t=191208
                var humid = (int)ReadBuf[0];
                var temp = (int)ReadBuf[1];
                //var soil = (float)ReadBuf[2];

                //if (temp < 30 && humid < 50 && soil < 50)
                //{
                //    _device.Write(new byte[] { I2cConstants.SET_PINSTATE, 3, I2cConstants.PINSTATE_HIGH });
                //}
                //else
                //{
                //    _device.Write(new byte[] { I2cConstants.SET_PINSTATE, 3, I2cConstants.PINSTATE_LOW });
                //}

                var task = Dispatcher.RunAsync(
                    Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                        Temperature = temp.ToString();
                        Humidity = humid.ToString();
                        
                    });

            }
            catch (Exception f)
            {
                throw;
            }

        }

    }
}
