using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TBC.OpenAPI.SDK.Core.Extensions;
using TBC.OpenAPI.SDK.OnlineInstallments.Interfaces;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOnlineInstallmentsClient(this IServiceCollection services, OnlineInstallmentsClientOptions options) 
            => AddOnlineInstallmentsClient(services, options, null, null);

        public static IServiceCollection AddOnlineInstallmentsClient(this IServiceCollection services, OnlineInstallmentsClientOptions options,
            Action<HttpClient> configureClient = null,
            Func<HttpClientHandler> configureHttpMessageHandler = null)
        {
            services.AddOpenApiClient<IOnlineInstallmentsClient, OnlineInstallmentsClient, OnlineInstallmentsClientOptions>(options, configureClient, configureHttpMessageHandler);
            services.AddValidatorsFromAssemblyContaining<InitiateInstallmentRequest>();
            return services;
        }
    }
}
