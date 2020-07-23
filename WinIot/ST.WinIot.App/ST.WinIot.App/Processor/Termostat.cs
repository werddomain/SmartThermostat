using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.WinIot.App.Processor
{
    public class Termostat
    {
        public Termostat() {

        }

        private double targetTemperature;

        public double TargetTemperature
        {
            get { return targetTemperature; }
            set { targetTemperature = value; }
        }

    }
}
