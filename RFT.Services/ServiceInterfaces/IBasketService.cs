using RFT.Services.DtoModels;
using RTF.Core.Models;

namespace RFT.Services.ServiceInterfaces;

public interface IBasketService
{
    Task<Basket> GetStudentBasket(Guid studentId);

    Task AddProductToBasket(OrderProductDto orderProductDto, Guid studentId, CancellationToken ct);

    Task RemoveProductFromBasket(OrderProductDto orderProductDto, Guid studentId, CancellationToken ct);

    Task IncrementProductCount(Guid productId, Guid studentId, CancellationToken ct);

    Task DecrementProductCount(Guid productId, Guid studentId, CancellationToken ct);
}