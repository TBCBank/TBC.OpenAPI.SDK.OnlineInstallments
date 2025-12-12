

using TBC.OpenAPI.SDK.Core;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Interfaces
{
    public interface IOnlineInstallmentsClient : IOpenApiClient
    {
        Task<InitiateInstallmentResponse> InitiateOnlineInstallment(InitiateInstallmentRequest model, CancellationToken cancellationToken = default);
        Task<ConfirmApplicationResponse> ConfirmApplication(ConfirmApplicationRequest model, CancellationToken cancellationToken = default);
        Task<CancelApplicationResponse> CancelApplication(CancelApplicationRequest model, CancellationToken cancellationToken = default);
        Task<GetApplicationStatusResponse> GetApplicationStatus(GetApplicationStatusRequest model, CancellationToken cancellationToken = default);
        Task<MerchantApplicationStatusesResponse> GetMerchantApplicationStatuses(MerchantApplicationStatusRequest model, CancellationToken cancellationToken = default);
        Task MerchantApplicationStatusSync(MerchantApplicationStatusSyncRequest model, CancellationToken cancellationToken = default);
    }
}
