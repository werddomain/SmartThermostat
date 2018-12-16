using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.WinIot.App
{
    public class MainPageVM:BaseModel
    {
        public MainPageVM() {
            //EnvironementSensor = new Sensors.Arduino();
            App.MainPageVM = this;
            Arduino = new Sensors.Arduino();
        }
        public Sensors.Arduino Arduino { get; set; }

        #region Shutdown 
        public RelayCommand<object> ShutdownCmd { get; set; }
        public bool CanShutdown { get { return true; } }
        private void CreateShutdownRelayCmd()
        {
            ShutdownCmd = new RelayCommand<object>(OnShutdown, (o) => CanShutdown);
        }
        private void OnShutdown(object obj)
        {
            Windows.System.ShutdownManager.BeginShutdown(Windows.System.ShutdownKind.Shutdown, TimeSpan.FromSeconds(1));		//Delay is not relevant to shutdown
        }
        #endregion


        #region Restart 
        public RelayCommand<object> RestartCmd { get; set; }
        public bool CanRestart { get { return true; } }
        private void CreateRestartRelayCmd()
        {
            RestartCmd = new RelayCommand<object>(OnRestart, (o) => CanRestart);
        }
        private void OnRestart(object obj)
        {
            Windows.System.ShutdownManager.BeginShutdown(Windows.System.ShutdownKind.Restart, TimeSpan.FromSeconds(1));		//Delay before restart after shutdown
        }
        #endregion


        //public Sensors.Arduino EnvironementSensor { get; set; }
    }
}
