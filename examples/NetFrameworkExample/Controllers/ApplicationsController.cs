using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;
using TBC.OpenAPI.SDK.Core;
using TBC.OpenAPI.SDK.OnlineInstallments.Extensions;

namespace NetFrameworkExample.Controllers
{
    public class ApplicationsController : ApiController
    {

        public async Task<IHttpActionResult> Get()
        {
            var onlineInstallmentsClient = OpenApiClientFactory.Instance.GetOnlineInstallmentsClient();

            var result = await onlineInstallmentsClient.GetApplicationStatus(new GetApplicationStatusRequest
            {
                MerchantKey = "aeb32470-4999-4f05-b271-b393325c8d8f",
                SessionId = "3293a41f-1ad0-4542-968a-a8480495b2d6"
            });

            return Ok(result);
        }
    }
}
