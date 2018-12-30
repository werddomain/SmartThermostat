using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.SmartDevices.Google
{
    public class GoogleRequest: IGoogleRequestResponse
    {
        public Input[] inputs { get; set; }
        public string requestId { get; set; }
        
    }
}
