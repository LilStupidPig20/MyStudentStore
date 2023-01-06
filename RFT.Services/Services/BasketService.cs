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

    public async Task<Basket> GetStudentBasket(Guid studentId)
    {
        var repo = _unitOfWork.GetRepository<UserInfo>();
        var userInfo = await repo.FindOneBy(x => x.Id == studentId);
        if (userInfo != null)
        {
            var basket = userInfo.Basket;
            return basket;
        };

        throw new Exception("Пользователь не найден");
    }

    public async Task AddProductToBasket(OrderProductDto orderProductDto, Guid studentId, CancellationToken ct)
    {
        var userRepo = _unitOfWork.GetRepository<UserInfo>();
        var userInfo = await userRepo.FindOneBy(x => x.Id == studentId);
        if (userInfo == null)
        {
            throw new Exception("Пользователь не найден"); 
        }

        var basketRepo = _unitOfWork.GetRepository<Basket>();
        var basket = await basketRepo.FindOneBy(x => x.User == userInfo);

        var productsRepo = _unitOfWork.GetRepository<StoreProduct>();
        var product = await productsRepo.GetAsync(orderProductDto.ProductId);
        var priceOfAdded = product.Price * orderProductDto.Count;
        if (basket == null)
        {
            throw new Exception("Не найдена сущность корзины для текущего пользователя");
        }

        if (basket.OrderProducts == null)
        {
            basket.OrderProducts = new List<OrderProduct>
            {
                new()
                {
                    Count = orderProductDto.Count,
                    Product = product,
                    Price = priceOfAdded,
                    Size = orderProductDto.Size
                }
            };
        }
        else
        {
            basket.OrderProducts.Add(new OrderProduct
            {
                Count = orderProductDto.Count,
                Product = product,
                Price = priceOfAdded,
                Size = orderProductDto.Size
            });
        }

        basket.TotalPrice += priceOfAdded;
        await basketRepo.UpdateAsync(basket);

        await _unitOfWork.SaveChangesAsync(ct);
    }

    public async Task RemoveProductFromBasket(OrderProductDto orderProductDto, Guid studentId, CancellationToken ct)
    {
        var userRepo = _unitOfWork.GetRepository<UserInfo>();
        var userInfo = await userRepo.FindOneBy(x => x.Id == studentId);
        if (userInfo == null)
        {
            throw new Exception("Пользователь не найден"); 
        };
        var basket = userInfo.Basket;
        OrderProduct? orderProduct;
        if (orderProductDto.Size != null)
        {
            orderProduct = basket.OrderProducts.FirstOrDefault(x =>
                x.Id == orderProductDto.ProductId && orderProductDto.Size == x.Size);
        }
        else
        {
            orderProduct = basket.OrderProducts.FirstOrDefault(x =>
                x.Id == orderProductDto.ProductId);
        }

        if (orderProduct != null)
        {
            userInfo.Basket.OrderProducts.Remove(orderProduct);

            userInfo.Basket.TotalPrice -= orderProduct.Price * orderProduct.Count;
        }

        await _unitOfWork.SaveChangesAsync(ct);
    }

    public async Task IncrementProductCount(Guid productId, Guid studentId, CancellationToken ct)
    {
        var userRepo = _unitOfWork.GetRepository<UserInfo>();
        var userInfo = await userRepo.FindOneBy(x => x.Id == studentId);
        if (userInfo == null)
        {
            throw new Exception("Пользователь не найден"); 
        };

        var orderProduct = userInfo.Basket.OrderProducts.FirstOrDefault(x => x.Id == productId);
        if (orderProduct == null)
        {
            throw new Exception("Товар не найден");
        }

        orderProduct.Count++;
        orderProduct.Price += orderProduct.Product.Price;

        userInfo.Basket.TotalPrice += orderProduct.Product.Price;
        
        await _unitOfWork.SaveChangesAsync(ct);
    }

    public async Task DecrementProductCount(Guid productId, Guid studentId, CancellationToken ct)
    {
        var userRepo = _unitOfWork.GetRepository<UserInfo>();
        var userInfo = await userRepo.FindOneBy(x => x.Id == studentId);
        if (userInfo == null)
        {
            throw new Exception("Пользователь не найден"); 
        };

        var orderProduct = userInfo.Basket.OrderProducts.FirstOrDefault(x => x.Id == productId);
        if (orderProduct == null)
        {
            throw new Exception("Товар не найден");
        }

        if (orderProduct.Count <= 0)
        {
            throw new Exception("Количество товара в корзине не может быть уменьшено, т. к. оно уже равно нулю");
        }

        orderProduct.Count--;
        orderProduct.Price -= orderProduct.Product.Price;
        
        userInfo.Basket.TotalPrice -= orderProduct.Product.Price;
        
        await _unitOfWork.SaveChangesAsync(ct);
    }
}