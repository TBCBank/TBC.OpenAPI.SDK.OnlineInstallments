namespace TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests
{
    public class TokenRequest
    {
        public string Grant_Type { get; set; } = "client_credentials";
        public string Scope { get; set; } = "online_installments";
    }
}
