using RTF.Mobile.Infrastructure.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RTF.Mobile.Infrastructure.Abstractions.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<EventDto>> GetEventsAsync(CancellationToken cancellationToken = default);

        Task<LoginResponseDto> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken = default);

        Task RegisterAsync(RegisterDto registerDto, CancellationToken cancellationToken = default);

        Task<IEnumerable<ShopItemDto>> GetShopItems(CancellationToken cancellationToken = default);

        Task<FullShopItemInfoDto> GetShopItemInfoDto(Guid id, CancellationToken cancellationToken = default);

        Task<Guid> GetUserQrIdAsync(CancellationToken cancellationToken = default);

        Task<BasketDto> GetBasketAsync(CancellationToken cancellationToken = default);

        Task AddItemToBasketAsync(NewBasketItemDto newBasketItemDto, CancellationToken cancellationToken = default);

        Task RemoveItemFromBasketAsync(NewBasketItemDto basketItemDto, CancellationToken cancellationToken = default);

        Task IncrementProductCountAsync(NewBasketItemDto basketItemDto, CancellationToken cancellationToken = default);

        Task<int> GetCurrentUserBalanceAsync();

        Task DecrementProductCountAsync(NewBasketItemDto basketItemDto, CancellationToken cancellationToken = default);

        Task MakeOrder(IEnumerable<Guid> basketIds);

        Task<List<OrderDto>> GetOrdersAsync();

        Task CancelOrderAsync(Guid orderId);
    }
}
    