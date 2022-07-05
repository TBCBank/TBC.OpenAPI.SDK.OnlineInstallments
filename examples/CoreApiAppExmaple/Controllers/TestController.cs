using Microsoft.AspNetCore.Mvc;
using TBC.OpenAPI.SDK.OnlineInstallments.Interfaces;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses;

namespace CoreApiAppExmaple.Controllers
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
        public async Task<ActionResult<GetApplicationStatusResponse>> GetApplicationStatus(GetApplicationStatusRequest model, CancellationToken cancellationToken = default)
        {
            var result = await _onlineInstallmentsClient.GetApplicationStatus(model, cancellationToken);

            return Ok(result);
        }
    }
}