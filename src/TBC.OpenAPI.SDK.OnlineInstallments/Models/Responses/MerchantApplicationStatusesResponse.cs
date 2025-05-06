namespace TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses
{
    public class MerchantApplicationStatusesResponse
    {
        public string SynchronizationRequestId { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<StatusChange> StatusChanges { get; set; }
    }

    public class StatusChange
    {
        public string SessionId { get; set; }
        public int StatusId { get; set; }
        public string StatusDescription { get; set; }
        public string ChangeDate { get; set; }
    }
}