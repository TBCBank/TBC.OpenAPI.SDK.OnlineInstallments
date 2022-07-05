using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests
{
    public class MerchantApplicationStatusSyncRequest : RequestBaseMerchantKey
    {
        public string SynchronizationRequestId { get; set; }
    }
}
