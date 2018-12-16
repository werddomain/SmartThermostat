using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.WinIot.App.Pages
{
    public class HomePageVM:BaseModel
    {
        public HomePageVM() {
            Arduino = App.MainPageVM.Arduino;
        }

        public Sensors.Arduino Arduino { get; set; }
    }
}
