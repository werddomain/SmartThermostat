using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.WinIot.App.Processor
{
    public class SensorsLinks
    {

        private List<Devices> devices;
        public IEnumerable<Devices> Devices
        {
            get { return devices; }
            
        }

    }
}
