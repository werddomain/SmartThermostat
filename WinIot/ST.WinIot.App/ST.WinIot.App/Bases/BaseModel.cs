using GalaSoft.MvvmLight.Command;
using Microsoft.IoT.Lightning.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
            CreateNavigateRelayCmd(); 
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

        #region Navigate 
        public RelayCommand<string> NavigateCmd { get; set; }
        public bool CanNavigate { get { return true; } }
        private void CreateNavigateRelayCmd()
        {
            NavigateCmd = new RelayCommand<string>(OnNavigate, (o) => CanNavigate);
        }
        private void OnNavigate(string obj)
        {
            Navigate(obj);
        }
        #endregion
        public void Navigate(string Uri) {
            var ns = Uri.Replace("/", ".");
            var s = ns.DirectSplit(".");
            var type = s.Last();
            if (s.Length > 1)
            {
                ns = string.Join('.', s.Take(s.Length - 1));
            }
            ns = "ST.WinIot.App." + ns;

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == ns && t.Name == type
                    select t;
            if (q.HasValue())
                Navigate(q.First());
        }
        public void Navigate(Type type)
        {
            App.MainPage.MainFrame.Navigate(type);

        }

        public void LogException(Exception ex, string where) {

        }

    }
}
