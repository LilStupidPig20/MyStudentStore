using RFT.Services.DtoModels;
using RTF.Core.Models;

namespace RFT.Services.ServiceInterfaces;

public interface IBasketService
{
    Task<Basket> GetStudentBasket(Guid studentId, CancellationToken ct);

    Task AddProductToBasket(OrderProductDto orderProductDto, Guid studentId, CancellationToken ct);

    Task RemoveProductFromBasket(OrderProductDto orderProductDto, Guid studentId, CancellationToken ct);

    Task IncrementProductCount(Guid basketProductId, Guid studentId, CancellationToken ct);

    Task DecrementProductCount(Guid basketProductId, Guid studentId, CancellationToken ct);
}