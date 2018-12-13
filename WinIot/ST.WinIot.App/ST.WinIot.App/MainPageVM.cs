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
            EnvironementSensor = new Sensors.Arduino();
        }
        public Sensors.Arduino EnvironementSensor { get; set; }
    }
}
