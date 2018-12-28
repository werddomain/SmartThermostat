using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.API.GoogleSmartHomeModel
{
    public abstract class PayLoadBase
    {
        /// <summary>
        /// String (up to 256 bytes). Required. Reﬂects the unique (and immutable) user ID on the agent's platform. The string is opaque to Google, so if there's an immutable form vs a mutable form on the agent side, use the immutable form (e.g. an account number rather than email).
        /// </summary>
        public string agentUserId { get; set; }
    }
}
