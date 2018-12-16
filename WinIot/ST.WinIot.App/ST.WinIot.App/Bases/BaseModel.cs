using Microsoft.IoT.Lightning.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices;
using Windows.UI.Xaml;

namespace ST.WinIot.App
{
    public abstract class BaseModel: DependencyObject, INotifyPropertyChanged
    {
        public BaseModel() {
            
        }

        internal void InitGPIO() {
            if (!InDesing)
            {
                //Add support if the Controller driver is "Direct Memory Mapped Driver". See https://docs.microsoft.com/en-us/windows/iot-core/develop-your-app/lightningproviders
                if (LightningProvider.IsLightningEnabled)
                {
                    LowLevelDevicesController.DefaultProvider = LightningProvider.GetAggregateProvider();
                }
            }
        }
        /// <summary>
        /// Get if the current thread is inside visual studio designer or if it's normal app execution.
        /// </summary>
        public bool InDesing { get => Windows.ApplicationModel.DesignMode.DesignModeEnabled; }

        //INotifyPropertyChanged Implementation
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void RaisePropertyChange(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
