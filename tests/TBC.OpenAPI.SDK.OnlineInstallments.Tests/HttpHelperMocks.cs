using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Tests
{
    public class HttpHelperMocks
    {
        private readonly WireMockServer _mockServer;
        private readonly HttpClient _httpClient = new();

        public HttpClient HttpClient => _httpClient;
        public Mock<IOptions<OnlineInstallmentsClientOptions>> OptionsMock = new();

        public HttpHelperMocks()
        {
            _mockServer = WireMockServer.Start();
            _httpClient.BaseAddress = new Uri($"{_mockServer.Urls[0]}/");

            AddMocks();
        }

        private void AddMocks()
        {
            #region OkResults

            OptionsMock.Setup(x => x.Value)
                .Returns(new OnlineInstallmentsClientOptions
                {
                    ApiKey = Guid.NewGuid().ToString(),
                    BaseUrl = "//BaseUrl",
                    ClientSecret = "ClientSecret"
                });

            _mockServer
                .Given(
                    Request.Create()
                    .WithPath("/applications")
                    .UsingMethod("POST")
                )
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new InitiateInstallmentResponce
                        {
                            SessionId = Guid.NewGuid().ToString(),
                        })
                );

            _mockServer
                .Given(
                    Request.Create()
                    .WithPath("/applications/181b867a-1feb-42f9-be34-e8de29810f13/confirm")
                    .UsingMethod("POST")

                )
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new ConfirmApplicationResponse
                        {
                            Id = Guid.NewGuid().ToString()
                        })
                );

            _mockServer
                .Given(
                    Request.Create()
                    .WithPath("/applications/181b867a-1feb-42f9-be34-e8de29810f13/status")
                    .UsingMethod("GET")

                )
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new GetApplicationStatusResponse
                        {
                            Amount = 1,
                            ContributionAmount = "1",
                            Description = "Test description",
                            StatusId = ApplicationStatuses.Approved
                        })
                );

            _mockServer
                .Given(
                    Request.Create()
                    .WithPath("/applications/181b867a-1feb-42f9-be34-e8de29810f13/cancel")
                    .UsingMethod("POST")

                )
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new CancelApplicationResponse
                        {
                            Id = Guid.NewGuid().ToString()
                        })
                );

            _mockServer
                .Given(
                    Request.Create()
                    .WithPath("/merchant/applications/status-changes")
                    .UsingMethod("GET")

                )
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new MerchantApplicationStatusesResponse
                        {
                            StatusChanges = new List<StatusChange>()
                            {
                                new StatusChange
                                {
                                    StatusId = 1,
                                    SessionId ="aeb32470-4999-4f05-b271-b393325c8d8f",
                                    ChangeDate = new DateTime(1991,07,22).ToString(CultureInfo.InvariantCulture),
                                    StatusDescription = "Test description"
                                }
                            },

                            SynchronizationRequestId = "3293a41f-1ad0-4542-968a-a8480495b2d6",
                            TotalCount = 1
                        })
                );

            _mockServer
                .Given(
                    Request.Create()
                    .WithPath("/merchant/applications/status-changes-sync")
                    .UsingMethod("POST")
                )
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new MerchantApplicationStatusesResponse
                        { })
                );

            _mockServer
                .Given(
                    Request.Create()
                    .WithPath("/oauth/token")
                    .UsingMethod("POST")
                )
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(new TokenResponse
                        {
                            AccessToken = Guid.NewGuid().ToString(),
                            ExpiresIn = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            IssuedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            Scope = "Test Scope",
                            TokenType = "Test Type"
                        })
                );

            #endregion OkResults
        }
    }
}
