﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC.OpenAPI.SDK.Core;
using TBC.OpenAPI.SDK.Core.Exceptions;
using TBC.OpenAPI.SDK.Core.Models;
using TBC.OpenAPI.SDK.OnlineInstallments.Interfaces;
using TBC.OpenAPI.SDK.OnlineInstallments.Models;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Requests;
using TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses;

namespace TBC.OpenAPI.SDK.OnlineInstallments
{
    public class OnlineInstallmentsClient : IOnlineInstallmentsClient
    {
        private readonly OnlineInstallmentsClientOptions _options;
        private readonly IHttpHelper<OnlineInstallmentsClient> _http;

        private static TokenResponse token { get; set; } = new TokenResponse();

        public OnlineInstallmentsClient(IHttpHelper<OnlineInstallmentsClient> http, IOptions<OnlineInstallmentsClientOptions> options)
        {
            _http = http;
            _options = options.Value;
            UpdateToken(CancellationToken.None);
        }


        public async Task<InitiateInstallmentResponce> InitiateOnlineInstallment(InitiateInstallmentRequest model, CancellationToken cancellationToken = default)
        {
            var result = await CallPost<InitiateInstallmentRequest, InitiateInstallmentResponce>(
                _http.PostJsonAsync<InitiateInstallmentRequest, InitiateInstallmentResponce>,
                "/applications",
                model,
                null,
                null,
                cancellationToken
                )
                .ConfigureAwait(false);

            if (!result.IsSuccess)
                throw new OpenApiException(result.Problem?.Title ?? "Unexpected error occurred", result.Exception);

            return result.Data;
        }

        public async Task<ConfirmApplicationResponse> ConfirmApplication(ConfirmApplicationRequest model, CancellationToken cancellationToken = default)
        {

            var test = await _http.PostJsonAsync<ConfirmApplicationRequest, ConfirmApplicationResponse>(
                $"/applications/{model.SessionId}/confirm",
                model,
                null,
                null, cancellationToken
                ).ConfigureAwait(false);


            var result = await CallPost<ConfirmApplicationRequest, ConfirmApplicationResponse>(
               _http.PostJsonAsync<ConfirmApplicationRequest, ConfirmApplicationResponse>,
               $"/applications/{model.SessionId}/confirm",
               model,
               null,
               null,
               cancellationToken
               )
               .ConfigureAwait(false);

            if (!result.IsSuccess)
                throw new OpenApiException(result.Problem?.Title ?? "Unexpected error occurred", result.Exception);

            return result.Data;
        }


        public async Task<GetApplicationStatusResponse> GetApplicationStatus(GetApplicationStatusRequest model, CancellationToken cancellationToken = default)
        {
            QueryParamCollection query = new QueryParamCollection
            {
                {"merchantKey", $"{model.MerchantKey}" }
            };

            var result = await CallGet<GetApplicationStatusResponse>(
                _http.GetJsonAsync<GetApplicationStatusResponse>,
                $"/applications/{model.SessionId}/status",
                query,
             null,
             cancellationToken
                ).ConfigureAwait(false);

            if (!result.IsSuccess)
                throw new OpenApiException(result.Problem?.Title ?? "Unexpected error occurred", result.Exception);

            return result.Data;
        }


        public async Task<CancelApplicationResponse> CancelApplication(CancelApplicationRequest model, CancellationToken cancellationToken = default)
        {
            var result = await CallPost<CancelApplicationRequest, CancelApplicationResponse>(
              _http.PostJsonAsync<CancelApplicationRequest, CancelApplicationResponse>,
              $"/applications/{model.SessionId}/cancel",
              model,
              null,
              null,
              cancellationToken
              )
              .ConfigureAwait(false);

            if (!result.IsSuccess)
                throw new OpenApiException(result.Problem?.Title ?? "Unexpected error occurred", result.Exception);

            return result.Data;
        }

        public async Task<MerchantApplicationStatusesResponse> GetMerchantApplicationStatuses(MerchantApplicationStatusRequest model, CancellationToken cancellationToken = default)
        {
            QueryParamCollection query = new QueryParamCollection
            {
                {"merchantKey", $"{model.MerchantKey}" },
                {"take", $"{model.Take}" }
            };

            var result = await CallGet<MerchantApplicationStatusesResponse>(
                _http.GetJsonAsync<MerchantApplicationStatusesResponse>,
                $"/merchant/applications/status-changes",
                query,
             null,
             cancellationToken
                ).ConfigureAwait(false);

            if (!result.IsSuccess)
                throw new OpenApiException(result.Problem?.Title ?? "Unexpected error occurred", result.Exception);

            return result.Data;
        }


        public async Task MerchantApplicationStatusSync(MerchantApplicationStatusSyncRequest model, CancellationToken cancellationToken = default)
        {

            var result = await CallPost<MerchantApplicationStatusSyncRequest, string>(
              _http.PostJsonAsync<MerchantApplicationStatusSyncRequest, string>,
              $"/merchant/applications/status-changes-sync",
              model,
              null,
              null,
              cancellationToken
              )
              .ConfigureAwait(false);

            if (!result.IsSuccess)
                throw new OpenApiException(result.Problem?.Title ?? "Unexpected error occurred", result.Exception);

        }


        private async Task<ApiResponse<TResult>> CallGet<TResult>(Func<string, QueryParamCollection, HeaderParamCollection, CancellationToken, Task<ApiResponse<TResult>>> fn,
            string path, QueryParamCollection query, HeaderParamCollection headers, CancellationToken cancellationToken)
        {
            headers = headers ?? new HeaderParamCollection();
            headers.Add("Authorization", token.Access_Token);

            ApiResponse<TResult> resp = await fn(path, query, headers, cancellationToken)
                .ConfigureAwait(false);

            if (resp?.Problem?.Code == "401")
            {
                UpdateToken(cancellationToken);
                headers["Authorization"] = token.Access_Token;
                resp = await fn(path, query, headers, cancellationToken)
                    .ConfigureAwait(false);
            }


            return resp;

        }

        private async Task<ApiResponse<TResult>> CallPost<TData, TResult>(Func<string, TData, QueryParamCollection, HeaderParamCollection, CancellationToken, Task<ApiResponse<TResult>>> fn,
            string path, TData data, QueryParamCollection query, HeaderParamCollection headers, CancellationToken cancellationToken)
        {

            headers = headers ?? new HeaderParamCollection();
            headers.Add("Authorization", token.Access_Token);

            ApiResponse<TResult> resp = await fn(path, data, query, headers, cancellationToken)
                .ConfigureAwait(false);

            if (resp?.Problem?.Code == "401")
            {
                UpdateToken(cancellationToken);
                headers["Authorization"] = token.Access_Token;
                resp = await fn(path, data, query, headers, cancellationToken)
                    .ConfigureAwait(false);
            }


            return resp;

        }

        private void UpdateToken(CancellationToken cancellationToken)
        {
            HeaderParamCollection headers = new HeaderParamCollection
            {
                {"client_secret", $"{_options.ClientSecret}"}
            };


            var responce = Task.Run(() =>
           _http.PostJsonAsync<TokenRequest, TokenResponse>("/oauth/token", new TokenRequest(), null, headers, cancellationToken)
           ).Result;

            token = responce?.Data;


        }
    }
}
