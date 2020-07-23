using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ST.WinIot.App.Pages
{
    public class TermostatVM : BaseModel
    {
        public TermostatVM()
        {
            CreateRelayCommands();
            App.MainPageVM.Arduino.SensorRead += Arduino_SensorRead;
        }

        private void Arduino_SensorRead(float TemperatureC, float Humidity)
        {
            CurrentTemperature = TemperatureC;
        }

        //The Target temperature
        private double pTargetTemperature;
        public double TargetTemperature
        {
            get { return pTargetTemperature; }
            set { pTargetTemperature = value; RaisePropertyChange("TargetTemperature"); }
        }

        //Current reported temperature by sensor
        private double pCurrentTemperature;
        public double CurrentTemperature
        {
            get { return pCurrentTemperature; }
            set { pCurrentTemperature = value; RaisePropertyChange("CurrentTemperature"); }
        }
        DispatcherTimer timeoutTimer;
        void TimeoutSetTemperature() {
            if (timeoutTimer != null)
            {
                timeoutTimer.Stop();
                timeoutTimer.Start();
                return;
            }
            timeoutTimer = new DispatcherTimer();
            timeoutTimer.Interval = new TimeSpan(0, 0, 1);//1 seconds
        }

        #region RelayCommands
        void CreateRelayCommands()
        {
            CreateLowerTemperatureRelayCmd();
            CreateRaiseTemperatureRelayCmd();
        }

        #region RaiseTemperature 
        public RelayCommand<object> RaiseTemperatureCmd { get; set; }
        public bool CanRaiseTemperature { get { return true; } }
        private void CreateRaiseTemperatureRelayCmd()
        {
            RaiseTemperatureCmd = new RelayCommand<object>(OnRaiseTemperature, (o) => CanRaiseTemperature);
        }
        private void OnRaiseTemperature(object obj)
        {

        }
        #endregion


        #region LowerTemperature 
        public RelayCommand<object> LowerTemperatureCmd { get; set; }
        public bool CanLowerTemperature { get { return true; } }
        private void CreateLowerTemperatureRelayCmd()
        {
            LowerTemperatureCmd = new RelayCommand<object>(OnLowerTemperature, (o) => CanLowerTemperature);
        }
        private void OnLowerTemperature(object obj)
        {

        }
        #endregion
        #endregion



    }
}
