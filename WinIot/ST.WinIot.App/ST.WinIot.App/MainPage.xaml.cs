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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ST.WinIot.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            App.MainPage = this;
            this.Loaded += MainPage_Loaded;
           
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            App.MainPageVM.Navigate(typeof(Pages.HomePage));
        }
        public bool IsLeftMenuOpen { get; private set; }
        public void OpenLeftMenu(bool Open) {
            this.LeftMenuOverlay.Visibility = Open ? Visibility.Visible : Visibility.Collapsed;
            if (Open)
                VisualStateManager.GoToState(this, "LeftMenuOpen", true);
            else
                VisualStateManager.GoToState(this, "LeftMenuClose", true);
            IsLeftMenuOpen = Open;
        }
        //Menu Button Click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenLeftMenu(!IsLeftMenuOpen);
        }

        private void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            OpenLeftMenu(false);
        }
    }
}
