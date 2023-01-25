using RestSharp;
using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RTF.Mobile.Infrastructure.Abstractions.Implementations
{
    public class ApiService : IApiService
    {
        private readonly IUserStorage userStorage;
        private RestClient client;

        public ApiService()
        {
            this.userStorage = DependencyService.Get<IUserStorage>();
            UpdateRestClientAsync();
        }

        public Task<IEnumerable<EventDto>> GetEventsAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto dto, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest("account/login", Method.Post);
            request.AddJsonBody(dto);
            var response = await ExecuteRequest<LoginResponseDto>(request, cancellationToken);
            var userSettings = new UserSettings(response.FirstName, response.LastName, response.Group, dto.Email, response.Token, response.Role);
            userStorage.SaveSettings(userSettings);
            return response;
        }

        public async Task GetVisited(CancellationToken cancellationToken)
        {
            var request = new RestRequest("events/getVisited/");
            await ExecuteRequest(request, cancellationToken);
        }

        public async Task RegisterAsync(RegisterDto dto, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest("account/register", Method.Post);
            request.AddJsonBody(dto);
            await ExecuteRequest(request, cancellationToken);
        }

        public async Task<IEnumerable<ShopItemDto>> GetShopItems(CancellationToken cancellationToken)
        {
            var request = new RestRequest("store/getAllProducts");
            return await ExecuteRequest<List<ShopItemDto>>(request, cancellationToken);
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

        private async Task UpdateRestClientAsync(bool getInfoFromSettings = false)
        {
            client = new RestClient((string)Application.Current.Properties["ApiUrl"]);
            if (getInfoFromSettings)
            {
                var settings = await userStorage.GetSettingsAsync(default);
                if (settings != null)
                {
                    client.AddDefaultHeader("Authorization", $"Bearer {settings.Token}");
                }
            }
        }

        public Task<Guid> GetUserQrIdAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<BasketDto> GetBasketAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task AddItemToBasketAsync(NewBasketItemDto newBasketItemDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemFromBasketAsync(NewBasketItemDto basketItemDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task IncrementProductCountAsync(NewBasketItemDto basketItemDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DecrementProductCountAsync(NewBasketItemDto basketItemDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<FullShopItemInfoDto> GetShopItemInfoDto(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCurrentUserBalanceAsync()
        {
            throw new NotImplementedException();
        }

        public Task MakeOrder(IEnumerable<Guid> basketIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDto>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task CancelOrderAsync(Guid orderId)
        {
            throw new NotImplementedException();
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
