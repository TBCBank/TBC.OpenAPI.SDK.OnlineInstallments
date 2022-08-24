namespace TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests
{
    public class InitiateInstallmentRequest : RequestBaseMerchantKey
    {
        public string CampaignId { get; set; }
        public string InvoiceId { get; set; }
        public float PriceTotal { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}