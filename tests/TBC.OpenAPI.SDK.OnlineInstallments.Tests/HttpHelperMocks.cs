using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Tests
{
    public class HttpHelperMocks
    {
        private readonly WireMockServer _mockServer;
        private readonly HttpClient _httpClient;

        public HttpClient HttpClient => _httpClient;
        public Mock<IOptions<OnlineInstallmentsClientOptions>> OptionsMock = new Mock<IOptions<OnlineInstallmentsClientOptions>>();

        public HttpHelperMocks()
        {
            _mockServer = WireMockServer.Start();
            _httpClient = new HttpClient();
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
                            StatusId = ApplicationStatusEnum.Approved
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
                                    ChangeDate = new DateTime(1991,07,22).ToString(),
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
                            Access_Token = Guid.NewGuid().ToString(),
                            Expires_In = DateTime.Now.ToString(),
                            Issued_At = DateTime.Now.ToString(),
                            Scope = "Test Scope",
                            Token_Type = "Test Type"
                        })
                );

            #endregion


        }
    }
}
