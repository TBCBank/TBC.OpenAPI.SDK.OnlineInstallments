namespace TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
        public string IssuedAt { get; set; }
        public string ExpiresIn { get; set; }
    }
}
