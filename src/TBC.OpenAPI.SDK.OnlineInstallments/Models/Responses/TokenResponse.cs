namespace TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses
{
    public class TokenResponse
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; }
        public string Scope { get; set; }
        public string Issued_At { get; set; }
        public string Expires_In { get; set; }
    }
}
