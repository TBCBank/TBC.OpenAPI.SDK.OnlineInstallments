namespace TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests
{
    public static class TokenRequest
    {
        public static string GrantType { get; set; } = "client_credentials";
        public static string Scope { get; set; } = "online_installments";
    }
}