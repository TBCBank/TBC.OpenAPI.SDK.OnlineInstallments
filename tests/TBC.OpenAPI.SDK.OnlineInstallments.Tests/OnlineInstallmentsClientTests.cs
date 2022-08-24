using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TBC.OpenAPI.SDK.Core;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses;
using Xunit;

namespace TBC.OpenAPI.SDK.OnlineInstallments.Tests
{
    public class OnlineInstallmentsClientTests
    {
        private readonly OnlineInstallmentsClient _client;

        public OnlineInstallmentsClientTests()
        {
            var helperMocks = new HttpHelperMocks();
            var mock = new Mock<IHttpClientFactory>();
            mock.Setup(x => x.CreateClient(typeof(OnlineInstallmentsClient).FullName)).Returns(helperMocks.HttpClient);
            var http = new HttpHelper<OnlineInstallmentsClient>(mock.Object);

            _client = new OnlineInstallmentsClient(http, helperMocks.OptionsMock.Object);
        }

        #region OkResults

        [Fact]
        public async Task InitiateOnlineInstallment_WhenResponceOk_ReturnsData()
        {
            var result = await _client.InitiateOnlineInstallment(new InitiateInstallmentRequest
            {
                CampaignId = "1",
                InvoiceId = "1",
                MerchantKey = "71ae20c4-03f3-466c-9692-624e88921b49",
                PriceTotal = 25.1f,
                Products = new List<Product>
                {
                    new Product()
                    {
                        Name = "Test Name",
                        Price = 1,
                        Quantity = 1
                    }
                }
            }).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result.SessionId));
        }

        [Fact]
        public async Task ConfirmApplication_WhenResponceOk_ReturnsData()
        {
            var result = await _client.ConfirmApplication(new ConfirmApplicationRequest
            {
                MerchantKey = "a60452bf-4a7f-4b52-892a-68b4aad3f1f7",
                SessionId = "181b867a-1feb-42f9-be34-e8de29810f13"
            }).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result.Id));
        }

        [Fact]
        public async Task GetApplicationStatus_WhenResponceOk_ReturnsData()
        {
            var expected = new GetApplicationStatusResponse
            {
                Amount = 1,
                ContributionAmount = "1",
                Description = "Test description",
                StatusId = ApplicationStatuses.Approved
            };

            var result = await _client.GetApplicationStatus(new GetApplicationStatusRequest
            {
                MerchantKey = "a60452bf-4a7f-4b52-892a-68b4aad3f1f7",
                SessionId = "181b867a-1feb-42f9-be34-e8de29810f13"
            }).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.Equal(expected.Amount, result.Amount);
            Assert.Equal(expected.ContributionAmount, result.ContributionAmount);
            Assert.Equal(expected.Description, result.Description);
            Assert.Equal(expected.StatusId, result.StatusId);
        }

        [Fact]
        public async Task GetApplicationStatus_CancelApplication_ReturnsData()
        {
            var result = await _client.CancelApplication(new CancelApplicationRequest
            {
                MerchantKey = "a60452bf-4a7f-4b52-892a-68b4aad3f1f7",
                SessionId = "181b867a-1feb-42f9-be34-e8de29810f13"
            }).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result.Id));
        }

        [Fact]
        public async Task GetApplicationStatus_GetMerchantApplicationStatusesReturnsData()
        {
            var expected = new MerchantApplicationStatusesResponse
            {
                SynchronizationRequestId = "3293a41f-1ad0-4542-968a-a8480495b2d6",
                TotalCount = 1,

                StatusChanges = new List<StatusChange>()
                            {
                                new StatusChange
                                {
                                    StatusId = 1,
                                    SessionId = "aeb32470-4999-4f05-b271-b393325c8d8f",
                                    ChangeDate = new DateTime(1991,07,22).ToString(CultureInfo.InvariantCulture),
                                    StatusDescription = "Test description"
                                }
                            }
            };

            var result = await _client.GetMerchantApplicationStatuses(new MerchantApplicationStatusRequest
            {
                MerchantKey = "a60452bf-4a7f-4b52-892a-68b4aad3f1f7",
                Take = 1
            }).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.Equal(result.SynchronizationRequestId, expected.SynchronizationRequestId);
            Assert.Equal(result.TotalCount, expected.TotalCount);
            //Assert.Equal(result.StatusChanges, expected.StatusChanges);
            result.StatusChanges.SequenceEqual(expected.StatusChanges);
        }

        #endregion OkResults
    }
}
