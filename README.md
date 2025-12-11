# TBC.OpenAPI.SDK.OnlineInstallments
​
[![NuGet version (TBC.OpenAPI.SDK.OnlineInstallments)](https://img.shields.io/nuget/v/TBC.OpenAPI.SDK.OnlineInstallments.svg?label=TBC.OpenAPI.SDK.OnlineInstallments)](https://www.nuget.org/packages/TBC.OpenAPI.SDK.OnlineInstallments/) [![CI](https://github.com/TBCBank/TBC.OpenAPI.SDK.OnlineInstallments/actions/workflows/main.yml/badge.svg?branch=master)](https://github.com/TBCBank/TBC.OpenAPI.SDK.OnlineInstallments/actions/workflows/main.yml)\
​
Online Installments SDKs for TBC OpenAPI
​
## Online Installments SDK
​
Repository contains the SDK for simplifying TBC Open API Online Installments API invocations on C# client application side.\
​
Library is written in the C # programming language and is compatible with .netstandard2.0 and .net6.0.
​
## Prerequisites
​
In order to use the SDK it is mandatory to have **apikey** from TBC Bank's OpenAPI Devportal.\
​
[See more details how to get apikey](https://developers.tbcbank.ge/docs/get-apikey-and-secret)
​
## .Net Core Usage
​
First step is to configure appsettings.json file with Online Installments endpoint, TBC Portal **apikey** and ClientSecret\
​
appsettings.json
​
```json
​
"OnlineInstallments": {
​
"BaseUrl": "https://tbcbank-test.apigee.net/v1/online-installments/",
​
"ApiKey": "{apikey}",

"ClientSecret" : "{ClientSecret}"
​
}
​
```
​
Then add Online Installments client as an dependency injection\
​
Program.cs
​
```cs
​
builder.Services.AddOnlineInstallmentsClient(builder.Configuration.GetSection("OnlineInstallments").Get<OnlineInstallmentsClientOptions>());
​
```
​
After two steps above, setup is done and  Online Installments client can be injected in any container class:
​
Injection example:
​
```cs
​
private readonly IOnlineInstallmentsClient _onlineInstallmentsClient;
​
public TestController(IOnlineInstallmentsClient onlineInstallmentsClient)
​
{
​
_onlineInstallmentsClient = onlineInstallmentsClient;
​
}
​
```
​
Api invocation example:
​
```cs
​
var result = await _onlineInstallmentsClient.GetApplicationStatus(
​
new GetApplicationStatusRequest
            {
                MerchantKey = "aeb32470-4999-4f05-b271-b393325c8d8f",
                SessionId = "3293a41f-1ad0-4542-968a-a8480495b2d6"
            },
​
cancellationToken
​
);
​
```
​
## NetFramework Usage
​
First step is to configure appsettings.json file with Online Installments endpoint, TBC Portal **apikey** and ClientSecret\
​
Web.config
​
```xml

​
<add key="OnlineInstallmentsUrl" value="https://tbcbank-test.apigee.net/v1/online-installments/" />
​
<add key="OnlineInstallmentsKey" value="{apikey}" />

<add key="OnlineInstallmentsClientSecret" value="{clientSecret}" />
​
```
​
In the Global.asax file at Application_Start() add following code\
​
Global.asax
​
```cs
​
new OpenApiClientFactoryBuilder()
​
.AddOnlineInstallmentsClient(new OnlineInstallmentsClientOptions
​
{
​
BaseUrl = ConfigurationManager.AppSettings["OnlineInstallmentsUrl"],
​
ApiKey = ConfigurationManager.AppSettings["OnlineInstallmentsKey"],

ApiKey = ConfigurationManager.AppSettings["OnlineInstallmentsClientSecret"]
​
})
​
.Build();
​
```
​
This code reads config parameters and then creates singleton OpenApiClientFactory, which is used to instantiate Online Installments client.\
​
OnlineInstallmentsClient class instantiation and invocation example:
​
```cs
​
var onlineInstallmentsClient = OpenApiClientFactory.Instance.GetOnlineInstallmentsClient();
​
var result = await onlineInstallmentsClient.GetApplicationStatus(new GetApplicationStatusRequest
            {
                MerchantKey = "aeb32470-4999-4f05-b271-b393325c8d8f",
                SessionId = "3293a41f-1ad0-4542-968a-a8480495b2d6"
            });
​
```
​
For more details see examples in repo:
​
​

[CoreApiAppExample](https://github.com/TBCBank/TBC.OpenAPI.SDK.OnlineInstallments/tree/master/examples/CoreApiAppExample)
​

[CoreConsoleAppExample](https://github.com/TBCBank/TBC.OpenAPI.SDK.OnlineInstallments/tree/master/examples/CoreConsoleAppExample)
​

[NetFrameworkExample](https://github.com/TBCBank/TBC.OpenAPI.SDK.OnlineInstallments/tree/master/examples/NetFrameworkExample)
