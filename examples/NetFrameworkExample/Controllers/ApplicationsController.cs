using System.Threading.Tasks;
using System.Web.Http;
using TBC.OpenAPI.SDK.Core;
using TBC.OpenAPI.SDK.OnlineInstallments.Extensions;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;

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