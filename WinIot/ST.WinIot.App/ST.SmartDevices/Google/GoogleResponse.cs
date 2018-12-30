using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.SmartDevices.Google
{
    public class GoogleResponse<T>: IGoogleRequestResponse
        where T : PayLoads.PayLoadBase
    {
        public GoogleResponse(string requestId)
        {
            this.requestId = requestId;
        }
        public GoogleResponse(GoogleRequest request)
        {
            this.requestId = request.requestId;
        }
        /// <summary>
        /// The same request id from the request
        /// </summary>
        public string requestId { get; set; }
        public T payload { get; set; }
    }
}
