using FontAwesome.UWP;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ST.WinIot.App.Models
{
    public class TopMenuButtonModel: INotifyPropertyChanged
    {
        public TopMenuButtonModel() { }

        /// <summary>
        /// Create an Url Button
        /// </summary>
        /// <param name="Icon"></param>
        /// <param name="Text"></param>
        /// <param name="Url"> Exemple: Pages/HomePage</param>
        public TopMenuButtonModel(FontAwesomeIcon Icon, string Text, string Url) {
            this.Icon = Icon;
            this.Text = Text;

            Parameter = Url;
            Command = new RelayCommand<object>((o) => {
                //Execute
                if (o is string)
                    App.MainPageVM.NavigateCmd.Execute(o);
            }, 
            o=> {
                //CanExecute
                return o is string && App.MainPageVM.NavigateCmd.CanExecute(o);
            });

        }
        public TopMenuButtonModel(FontAwesomeIcon Icon, string Text, RelayCommand<object> Command, object Parameter = null)
        {
            this.Icon = Icon;
            this.Text = Text;

            if (Parameter != null)
                this.Parameter = Parameter;

            this.Command = Command;

        }

        private string pText;
        public string Text
        {
            get { return pText; }
            set { pText = value; RaisePropertyChange("Text"); }
        }


        private RelayCommand<object> pCommand;
        public RelayCommand<object> Command
        {
            get { return pCommand; }
            set { pCommand = value; RaisePropertyChange("Command"); }
        }


        private object pParameter;
        public object Parameter
        {
            get { return pParameter; }
            set {
                pParameter = value;
                RaisePropertyChange("Parameter");
                if (Command != null)
                    Command.RaiseCanExecuteChanged();
            }
        }


        private FontAwesomeIcon pIcon;
        public FontAwesomeIcon Icon
        {
            get { return pIcon; }
            set { pIcon = value; RaisePropertyChange("Icon"); }
        }
        


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
