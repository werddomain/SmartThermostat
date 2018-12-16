using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.WinIot.App.Controls
{
    public class Dth22DisplayVM:BaseModel
    {
        public Dth22DisplayVM() {
            if (InDesing)
            {
                Temperature = "24.5 °c";
                Humidity = "30 %";
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
    }
}
