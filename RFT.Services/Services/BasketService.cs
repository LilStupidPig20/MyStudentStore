using RFT.Services.DtoModels;
using RFT.Services.ServiceInterfaces;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RFT.Services.Services;

public class BasketService : IBasketService
{
    private readonly IUnitOfWork _unitOfWork;

    public BasketService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Basket> GetStudentBasket(Guid studentId, CancellationToken ct)
    {
        var repo = (UserInfoRepository)_unitOfWork.GetRepository<UserInfo>();
        var userInfo = await repo.GetUserIncludeFullBasket(studentId, ct);
        if (userInfo != null)
        {
            var basket = userInfo.Basket;
            return basket;
        };

        throw new Exception("Пользователь не найден");
    }

    public async Task AddProductToBasket(OrderProductDto orderProductDto, Guid studentId, CancellationToken ct)
    {
        var userRepo = (UserInfoRepository)_unitOfWork.GetRepository<UserInfo>();
        var userInfo = await userRepo.GetUserIncludeFullBasket(studentId, ct);
        if (userInfo == null)
        {
            throw new Exception("Пользователь не найден"); 
        }

        var basket = userInfo.Basket;
        var productsRepo = _unitOfWork.GetRepository<StoreProduct>();
        var product = await productsRepo.GetAsync(orderProductDto.ProductId);
        if (product.TotalQuantity < orderProductDto.Count)
        {
            throw new ArgumentException("Недостаточно товара на складе");
        }

        if (basket == null)
        {
            throw new Exception("Не найдена сущность корзины для текущего пользователя");
        }

        basket.BasketProducts.Add(new BasketProduct
        {
            Count = orderProductDto.Count,
            Product = product,
            Size = orderProductDto.Size
        });
        
        await userRepo.UpdateAsync(userInfo);

        await _unitOfWork.SaveChangesAsync(ct);
    }

    public async Task RemoveProductFromBasket(OrderProductDto orderProductDto, Guid studentId, CancellationToken ct)
    {
        var userRepo = (UserInfoRepository)_unitOfWork.GetRepository<UserInfo>();
        var userInfo = await userRepo.GetUserIncludeFullBasket(studentId, ct);
        if (userInfo == null)
        {
            throw new Exception("Пользователь не найден"); 
        }

        var basket = userInfo.Basket;
        BasketProduct? orderProduct;
        if (orderProductDto.Size != null)
        {
            orderProduct = basket.BasketProducts.FirstOrDefault(x =>
                x.Product.Id == orderProductDto.ProductId && orderProductDto.Size == x.Size);
        }
        else
        {
            orderProduct = basket.BasketProducts.FirstOrDefault(x =>
                x.Product.Id == orderProductDto.ProductId);
        }

        if (orderProduct != null)
        {
            userInfo.Basket.BasketProducts.Remove(orderProduct);
        }

        await _unitOfWork.SaveChangesAsync(ct);
    }

    public async Task IncrementProductCount(Guid basketProductId, Guid studentId, CancellationToken ct)
    {
        var userRepo = (UserInfoRepository)_unitOfWork.GetRepository<UserInfo>();
        var userInfo = await userRepo.GetUserIncludeFullBasket(studentId, ct);
        if (userInfo == null)
        {
            throw new Exception("Пользователь не найден"); 
        }

        var orderProduct = userInfo.Basket.BasketProducts.FirstOrDefault(x => x.Id == basketProductId);
        
        if (orderProduct == null)
        {
            throw new Exception("Товар не найден");
        }

        if (orderProduct.Product.TotalQuantity <= 0)
        {
            throw new ArgumentException("Недостаточно товара на складе");
        }

        orderProduct.Count++;

        await _unitOfWork.SaveChangesAsync(ct);
    }

    public async Task DecrementProductCount(Guid basketProductId, Guid studentId, CancellationToken ct)
    {
        var userRepo = (UserInfoRepository)_unitOfWork.GetRepository<UserInfo>();
        var userInfo = await userRepo.GetUserIncludeFullBasket(studentId, ct);
        if (userInfo == null)
        {
            throw new Exception("Пользователь не найден"); 
        }

        var orderProduct = userInfo.Basket.BasketProducts.FirstOrDefault(x => x.Id == basketProductId);
        if (orderProduct == null)
        {
            throw new Exception("Товар не найден");
        }

        if (orderProduct.Count <= 0)
        {
            throw new Exception("Количество товара в корзине не может быть уменьшено, т. к. оно уже равно нулю");
        }

        if (orderProduct.Count == 1)
        {
            userInfo.Basket.BasketProducts.Remove(orderProduct);
        }
        else
        {
            orderProduct.Count--;
        }

        await _unitOfWork.SaveChangesAsync(ct);
    }
}