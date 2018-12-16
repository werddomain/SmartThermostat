using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ST.WinIot.App.Controls
{
    public sealed partial class Dth22Display : UserControl
    {
        Dth22DisplayVM vm;
        public Dth22Display()
        {
            this.InitializeComponent();
            this.SizeChanged += Dth22Display_SizeChanged;
           
            vm = MainGrid.DataContext as Dth22DisplayVM;
        }

        private void Dth22Display_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var minSize = this.ActualHeight > this.ActualWidth ? this.ActualWidth : this.ActualHeight;
            MainGrid.Width = minSize;
            MainGrid.Height = minSize;
        }

        #region Temperature
        public float? Temperature
        {
            get { return (float?)GetValue(TemperatureProperty); }
            set { SetValue(TemperatureProperty, value); }
        }

        public static readonly DependencyProperty TemperatureProperty =
            DependencyProperty.Register("Temperature", typeof(object), typeof(Dth22Display), new PropertyMetadata(null, OnTemperatureChanged));

        private static void OnTemperatureChanged(DependencyObject dp, DependencyPropertyChangedEventArgs arg)
        {
            var obj = dp as Dth22Display;
            var value = arg.NewValue as float?;
            string display = "!!";
            if (value.HasValue)
                display = Math.Round(value.Value, 1, MidpointRounding.AwayFromZero).ToString("0.0");
            if (obj.vm != null)
                obj.vm.Temperature = $"{display}°c";
        }
        #endregion

        #region Humidity
        public float? Humidity
        {
            get { return (float?)GetValue(HumidityProperty); }
            set { SetValue(HumidityProperty, value); }
        }

        public static readonly DependencyProperty HumidityProperty =
            DependencyProperty.Register("Humidity", typeof(object), typeof(Dth22Display), new PropertyMetadata(null, OnHumidityChanged));

        private static void OnHumidityChanged(DependencyObject dp, DependencyPropertyChangedEventArgs arg)
        {
            var obj = dp as Dth22Display;
            var value = arg.NewValue as float?;
            string display = "!!";
            if (value.HasValue)
                display = Math.Round(value.Value, 1, MidpointRounding.AwayFromZero).ToString("0.0");
            if (obj.vm != null)
                obj.vm.Humidity = $"{display}%";
        }
        #endregion
    }
}
