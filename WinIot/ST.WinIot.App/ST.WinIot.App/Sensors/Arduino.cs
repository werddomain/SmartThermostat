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
    /// <summary>
    /// This class will handle communication with the arduino using i2c.
    /// </summary>
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

        private float pTemperature;
        public float Temperature
        {
            get { return pTemperature; }
            set { pTemperature = value; RaisePropertyChange("Temperature"); }
        }


        private float pHumidity;
        public float Humidity
        {
            get { return pHumidity; }
            set { pHumidity = value; RaisePropertyChange("Humidity"); }
        }

        public delegate void SensorReadDelegate(double TemperatureC, double Humidity);
        public event SensorReadDelegate SensorRead;

        private async void InitI2C()
        {
            InitGPIO();
            //var i2cController = await I2cController.GetDefaultAsync();
            
            var settings = new I2cConnectionSettings(0x40); // Arduino address
            settings.BusSpeed = I2cBusSpeed.StandardMode;
            //_device = i2cController.GetDevice(settings);
            string aqs = I2cDevice.GetDeviceSelector("I2C1");
            var dis = await DeviceInformation.FindAllAsync(aqs);
            _device = await I2cDevice.FromIdAsync(dis[0].Id, settings);
            _periodicTimer = new Timer(TimerCallback, null, 0, 1000); // Create a timer
        }
        private float GetFLOATUNION(byte[] r) {
            return ToFloat(new byte[] {r[3], r[4], r[5], r[6] });
        }
        private string GetBytes(byte[] r) {
            var i = r.Select(o => (int)o);
            return String.Join("-", i);

        }
        private async Task ProceadResponse(byte[] response) {
            await Dispatcher.RunAsync(
                    Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        System.Diagnostics.Debug.WriteLine("Procead Response: " + GetBytes(response));
                        if (response.Length == 14 && response[0] == 1)
                        {
                            switch (response[1])
                            {
                                case (byte)COMMANDS.Temperature: //Temperature
                                    Temperature = GetFLOATUNION(response);
                                    break;
                                case (byte)COMMANDS.Humidity: //Humidity
                                    Humidity = GetFLOATUNION(response);
                                    break;
                                default:
                                    break;
                            }
                        }

                    });
            
        }
        enum COMMANDS {
            Temperature = 10,
            Humidity = 11
        }
       

        const byte Type_Float = 100;

        private Task Get(COMMANDS command) {
            return Task.Run(async () => {
                byte[] ReadBuf = new byte[14];

                _device.WriteRead(new byte[] { 1, (byte)command }, ReadBuf);
                await ProceadResponse(ReadBuf);
                await Task.Delay(250);
            });


        }
        private async void TimerCallback(object state)
        {
            try
            {


                //Float communication in i2c : https://www.raspberrypi.org/forums/viewtopic.php?t=191208
                //Parse 4 byte to a float : https://stackoverflow.com/questions/4301623/problem-converting-4-bytes-array-to-float-in-c-sharp
                
                await Get(COMMANDS.Temperature);
                await Get(COMMANDS.Humidity);





            }
            catch (Exception f)
            {
                throw;
            }

        }
        static float ToFloat(byte[] input)
        {
            
            return BitConverter.ToSingle(input, 0);
        }


    }
}
