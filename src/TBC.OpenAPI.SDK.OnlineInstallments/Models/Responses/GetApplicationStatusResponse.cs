using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses
{
    public class GetApplicationStatusResponse
    {
        public int Amount { get; set; }
        public string ContributionAmount { get; set; }
        public ApplicationStatusEnum StatusId { get; set; }
        public string Description { get; set; }
    }


}
