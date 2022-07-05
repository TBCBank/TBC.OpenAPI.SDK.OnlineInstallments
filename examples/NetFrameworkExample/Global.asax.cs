using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TBC.OpenAPI.SDK.Core;
using TBC.OpenAPI.SDK.OnlineInstallments;
using TBC.OpenAPI.SDK.OnlineInstallments.Extensions;

namespace NetFrameworkExample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            new OpenApiClientFactoryBuilder()
                .AddOnlineInstallmentsClient(new OnlineInstallmentsClientOptions
                {
                    BaseUrl = ConfigurationManager.AppSettings["OnlineInstallmentsUrl"],
                    ApiKey = ConfigurationManager.AppSettings["OnlineInstallmentsKey"],
                    ClientSecret = ConfigurationManager.AppSettings["OnlineInstallmentsClientSecret"]
                })
                .Build();
        }
    }
}
