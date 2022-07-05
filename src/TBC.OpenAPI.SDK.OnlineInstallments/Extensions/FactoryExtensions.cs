using TBC.OpenAPI.SDK.Core;
using TBC.OpenAPI.SDK.OnlineInstallments.Interfaces;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Extensions
{
    public static class FactoryExtensions
    {
        public static OpenApiClientFactoryBuilder AddOnlineInstallmentsClient(this OpenApiClientFactoryBuilder builder,
            OnlineInstallmentsClientOptions options) => AddOnlineInstallmentsClient(builder, options, null, null);

        public static OpenApiClientFactoryBuilder AddOnlineInstallmentsClient(this OpenApiClientFactoryBuilder builder,
            OnlineInstallmentsClientOptions options,
            Action<HttpClient> configureClient = null,
            Func<HttpClientHandler> configureHttpMessageHandler = null)
        {
            return builder.AddClient<IOnlineInstallmentsClient, OnlineInstallmentsClient, OnlineInstallmentsClientOptions>(options, configureClient, configureHttpMessageHandler);
        }

        public static IOnlineInstallmentsClient GetOnlineInstallmentsClient(this OpenApiClientFactory factory) =>
            factory.GetOpenApiClient<IOnlineInstallmentsClient>();

    }
}