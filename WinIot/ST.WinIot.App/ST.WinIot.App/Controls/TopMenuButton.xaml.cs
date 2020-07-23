using FontAwesome.UWP;
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
    public sealed partial class TopMenuButton : Button
    {
        public TopMenuButton()
        {
            this.InitializeComponent();
        }


        #region ButtonText
        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(TopMenuButton), new PropertyMetadata(null, OnButtonTextChanged));

        private async static void OnButtonTextChanged(DependencyObject dp, DependencyPropertyChangedEventArgs arg)
        {
            var obj = dp as TopMenuButton;
            var value = arg.NewValue as string;
            await obj.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                //UI code here
                obj.btnText.Text = value;
            });
            

        }
        #endregion

        #region ButtonIcon
        public FontAwesomeIcon ButtonIcon
        {
            get { return (FontAwesomeIcon)GetValue(ButtonIconProperty); }
            set { SetValue(ButtonIconProperty, value); }
        }

        public static readonly DependencyProperty ButtonIconProperty =
            DependencyProperty.Register("ButtonIcon", typeof(FontAwesomeIcon), typeof(TopMenuButton), new PropertyMetadata(FontAwesomeIcon.None, OnButtonIconChanged));

        private async static void OnButtonIconChanged(DependencyObject dp, DependencyPropertyChangedEventArgs arg)
        {
            var obj = dp as TopMenuButton;
            var value = (FontAwesomeIcon)arg.NewValue;
            await obj.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                obj.btnIcon.Icon = value;
            });
        }
        #endregion



    }
}
