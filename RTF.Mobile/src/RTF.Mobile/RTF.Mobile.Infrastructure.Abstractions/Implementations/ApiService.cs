﻿using AutoMapper;
using RestSharp;
using RTF.Mobile.Infrastructure.Abstractions.Implementations;
using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: Dependency(nameof(ApiService), LoadHint.Always)]
namespace RTF.Mobile.Infrastructure.Abstractions.Implementations
{
    public class ApiService : IApiService
    {
        private readonly IMapper mapper;
        private readonly IUserStorage userStorage;
        private RestClient client;

        public ApiService(IUserStorage userStorage, IMapper mapper)
        {
            this.userStorage = userStorage;
            this.mapper = mapper;
            UpdateRestClientAsync();
        }

        public Task<IEnumerable<EventDto>> GetEventsAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto dto, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest("login", Method.Post);
            request.AddJsonBody(dto);
            var response = await ExecuteRequest<LoginResponseDto>(request, cancellationToken);
            userStorage.SaveSettings(mapper.Map<UserSettings>(response));
            return await ExecuteRequest<LoginResponseDto>(request, cancellationToken);
        }

        public async Task RegisterAsync(RegisterDto dto, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest("register", Method.Post);
            request.AddJsonBody(dto);
            await ExecuteRequest(request, cancellationToken);
        }

        private async Task<TResponse> ExecuteRequest<TResponse>(RestRequest request, CancellationToken cancellationToken)
        where TResponse : new()
        {
            var response = await client.ExecuteAsync<TResponse>(request, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            if (!response.IsSuccessful)
            {
                //if (response.StatusCode == HttpStatusCode.Unauthorized)
                //{
                //    await RefreshToken(cancellationToken);
                //    response = await client.ExecuteAsync<TResponse>(request, cancellationToken);
                //    return response.Data;
                //}
                throw RestHelper.CreateException(response.StatusCode, response.Content);
            }

            return response.Data;
        }

        private async Task<RestResponse> ExecuteRequest(RestRequest request, CancellationToken cancellationToken)
        {
            var response = await client.ExecuteAsync(request, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            if (!response.IsSuccessful)
            {
                //if (response.StatusCode == HttpStatusCode.Unauthorized)
                //{
                //    await RefreshToken(cancellationToken);
                //    response = await client.ExecuteAsync(request, cancellationToken);
                //    return response;
                //}
                throw RestHelper.CreateException(response.StatusCode, response.Content);
            }
            return response;
        }

        private async Task UpdateRestClientAsync()
        {
            var settings = await userStorage.GetSettingsAsync(default);
            client = new RestClient();
            if (settings != null)
            {
                client.AddDefaultHeader("Authorization", $"Bearer {settings.Token}");
            }
        }

        //private async Task RefreshToken(CancellationToken cancellationToken)
        //{
        //    var request = new RestRequest("auth", Method.Put);

        //    request.AddJsonBody(new { Token = currentJwtToken });

        //    var response = await client.ExecuteAsync<LoginResponseDto>(request, cancellationToken);
        //    if (!response.IsSuccessful)
        //    {
        //        throw new UnauthorizedException();
        //    }
        //    SaveAuthTokenData(response.Data);
        //}
    }
}
