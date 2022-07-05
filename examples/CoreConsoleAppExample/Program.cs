// See https://aka.ms/new-console-template for more information



using TBC.OpenAPI.SDK.Core;
using TBC.OpenAPI.SDK.OnlineInstallments;
using TBC.OpenAPI.SDK.OnlineInstallments.Extensions;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;

var factory = new OpenApiClientFactoryBuilder()
    .AddOnlineInstallmentsClient(new OnlineInstallmentsClientOptions
    {
        BaseUrl = "https://test-api.tbcbank.ge/v1/online-installments/",
        ApiKey = "{apikey}",
        ClientSecret = "{clientSecret}"
    })
    .Build();


var client = factory.GetOnlineInstallmentsClient();

var result = client.GetApplicationStatus(new GetApplicationStatusRequest 
{
    MerchantKey = "aeb32470-4999-4f05-b271-b393325c8d8f",
    SessionId = "3293a41f-1ad0-4542-968a-a8480495b2d6"
}).GetAwaiter().GetResult();

Console.WriteLine($"Result: {result.StatusId}");

Console.ReadLine();
