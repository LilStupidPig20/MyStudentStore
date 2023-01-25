using RFT.Services.ServiceInterfaces;
using RTF.Core.Models;
using RTF.Core.Models.Enums;
using RTF.Core.Repositories;

namespace RFT.Services.Services;

public class OrdersService : IOrdersService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdersService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateOrder(IReadOnlyList<Guid> basketProductsIds, Guid userId, CancellationToken ct)
    {
        var userWithBasket = await GetUserInfo(userId, ct);

        var basketPositionsToOrder = userWithBasket.Basket.BasketProducts
            .Where(x => basketProductsIds.Contains(x.Id))
            .ToList();
        var totalPrice = basketPositionsToOrder
            .Select(x => x.Product.Price * x.Count)
            .Sum();

        if (userWithBasket.Balance < totalPrice)
        {
            throw new ArgumentException("Недостаточно средств");
        }

        await AddNewOrder(userWithBasket, basketPositionsToOrder, totalPrice);

        ReduceProductsCountInStore(userWithBasket, basketPositionsToOrder);

        userWithBasket.Balance -= totalPrice;
        await _unitOfWork.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<Order>> GetStudentOrders(Guid userId, CancellationToken ct)
    {
        var ordersRepo = (OrderRepository)_unitOfWork.GetRepository<Order>();
        var orders = await ordersRepo.GetUserOrders(userId, ct);
        return orders;
    }

    public async Task CancelOrder(Guid orderId, string? cancellationComment, CancellationToken ct)
    {
        var orderRepo = (OrderRepository)_unitOfWork.GetRepository<Order>();
        var order = await orderRepo.GetFullOrder(orderId, ct);
        if (order == null)
        {
            throw new ArgumentException("Заказ не найден");
        }

        order.Status = OrderStatus.Cancelled;
        order.CancellationComment = cancellationComment;
        IncreaseProductsCountInStore(order.OrderProducts.ToList());
        order.Student.Balance += order.TotalPrice;

        await _unitOfWork.SaveChangesAsync(ct);
    }

    private async Task<UserInfo> GetUserInfo(Guid id, CancellationToken ct)
    {
        var userInfoRepo = (UserInfoRepository)_unitOfWork.GetRepository<UserInfo>();
        var userWithBasket = await userInfoRepo.GetUserIncludeFullBasket(id, ct);
        if (userWithBasket == null)
        {
            throw new ArgumentException("Пользователь не найден");
        }

        return userWithBasket;
    }

    private async Task AddNewOrder(UserInfo user, List<BasketProduct> basketProducts, double totalPrice)
    {
        var ordersRepo = _unitOfWork.GetRepository<Order>();
        await ordersRepo.AddAsync(new Order
        {
            Status = OrderStatus.Accepted,
            Student = user,
            PurchaseTime = DateTime.Now,
            OrderProducts = basketProducts.Select(x => new OrderProduct
            {
                Count = x.Count,
                Price = x.Product.Price * x.Count,
                Product = x.Product,
                Size = x.Size
            }).ToList(),
            TotalPrice = totalPrice
        });
    }

    private void ReduceProductsCountInStore(UserInfo userInfo, List<BasketProduct> basketProducts)
    {
        foreach (var basketProduct in basketProducts)
        {
            userInfo.Basket.BasketProducts.Remove(basketProduct);

            if (basketProduct.Product is ClothesProduct clothesProduct)
            {
                var clothesInfo = clothesProduct.ClothesInfos.FirstOrDefault(x => x.Size == basketProduct.Size);
                if (clothesInfo != null)
                {
                    clothesInfo.Count -= basketProduct.Count;
                }
            }
            
            basketProduct.Product.TotalQuantity -= basketProduct.Count;
        }
    }
    
    private void IncreaseProductsCountInStore(List<OrderProduct> orderProducts)
    {
        foreach (var orderProduct in orderProducts)
        {
            if (orderProduct.Product is ClothesProduct clothesProduct)
            {
                var clothesInfo = clothesProduct.ClothesInfos.FirstOrDefault(x => x.Size == orderProduct.Size);
                if (clothesInfo != null)
                {
                    clothesInfo.Count += orderProduct.Count;
                }
            }
            
            orderProduct.Product.TotalQuantity += orderProduct.Count;
        }
    }
}