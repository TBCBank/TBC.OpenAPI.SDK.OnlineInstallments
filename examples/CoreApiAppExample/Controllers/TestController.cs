using Microsoft.AspNetCore.Mvc;
using TBC.OpenAPI.SDK.OnlineInstallments.Interfaces;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses;

namespace CoreApiAppExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IOnlineInstallmentsClient _onlineInstallmentsClient;

        public TestController(IOnlineInstallmentsClient onlineInstallmentsClient)
        {
            _onlineInstallmentsClient = onlineInstallmentsClient;
        }

        [HttpGet]
        public async Task<ActionResult<GetApplicationStatusResponse>> GetApplicationStatus([FromQuery] string sessionId, [FromHeader] string merchantKey, CancellationToken cancellationToken = default)
        {
            var result = await _onlineInstallmentsClient.GetApplicationStatus(new GetApplicationStatusRequest { SessionId = sessionId, MerchantKey = merchantKey }, cancellationToken);

            return Ok(result);
        }
    }
}