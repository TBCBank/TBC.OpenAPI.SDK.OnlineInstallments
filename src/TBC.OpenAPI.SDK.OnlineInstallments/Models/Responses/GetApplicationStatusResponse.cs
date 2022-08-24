namespace TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses
{
    public class GetApplicationStatusResponse
    {
        public int Amount { get; set; }
        public string ContributionAmount { get; set; }
        public ApplicationStatuses StatusId { get; set; }
        public string Description { get; set; }
    }
}