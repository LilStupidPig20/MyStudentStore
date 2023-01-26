using RTF.Mobile.Infrastructure.Abstractions.Interfaces;
using RTF.Mobile.Infrastructure.Abstractions.Models;
using RTF.Mobile.Utils.MockServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MockApiService))]
namespace RTF.Mobile.Utils.MockServices
{
    public class MockApiService : IApiService
    {
        private static Guid UserQrId = Guid.Parse("f6c28050-3b41-4b61-9ec4-18f70e46bfd4");

        private static List<EventDto> allEvents = new List<EventDto>()
            {
                new EventDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Неделя первокурсника",
                    Points = 6,
                    EndTime = new DateTime(2022, 9, 8, 14, 40, 0),
                    StartTime = new DateTime(2022, 9, 8, 13, 10, 0),
                    EventType = EventType.Social,
                    OrganizersNames = new List<string>()
                    {
                        "Корякин Игорь",
                        "Ковтонюк Полина",
                    },
                },
                new EventDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Караоке",
                    Desciption = "Приходи на караоке со своими друзьями. Будем петь  самые известные хиты. \r\nБудет весело!\r\nРегистрация проходит традиционно по QR-коду, ищи его в своем личном кабинете.",
                    Points = 2,
                    EndTime = new DateTime(2022, 9, 11, 18, 40, 0),
                    StartTime = new DateTime(2022, 9, 11, 16, 40, 0),
                    EventType = EventType.Social,
                    OrganizersNames = new List<string>()
                    {
                        "Корякин Игорь",
                        "Ковтонюк Полина",
                    },
                },
                new EventDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Хакатон",
                    Desciption = "Форум для разработчиков, во время которого специалисты из разных областей разработки программного обеспечения (программисты, дизайнеры, менеджеры) сообща решают какую-либо проблему на время.",
                    Points = 5,
                    EndTime = new DateTime(2022, 11, 12, 10, 30, 0),
                    StartTime = new DateTime(2022, 11, 12, 18, 30, 0),
                    EventType = EventType.Educational,
                    OrganizersNames = new List<string>()
                    {
                        "Корякин Игорь",
                        "Ковтонюк Полина",
                    },
                },
                new EventDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Литературный вечер",
                    Points = 5,
                    EndTime = new DateTime(2023, 10, 1, 18, 30, 0),
                    StartTime = new DateTime(2023, 11, 1, 20, 30, 0),
                    EventType = EventType.Social,
                    OrganizersNames = new List<string>()
                    {
                        "Корякин Игорь",
                        "Ковтонюк Полина",
                    },
                },
                new EventDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Хакатон",
                    Points = 5,
                    EndTime = new DateTime(2023, 1, 15, 10, 30, 0),
                    StartTime = new DateTime(2023, 1, 15, 18, 30, 0),
                    EventType = EventType.Educational,
                    OrganizersNames = new List<string>()
                    {
                        "Корякин Игорь",
                        "Ковтонюк Полина",
                    },
                },
                new EventDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Спортивное мероприятие",
                    Points = 10,
                    EndTime = new DateTime(2023, 1, 15, 10, 30, 0),
                    StartTime = new DateTime(2023, 1, 15, 15, 40, 0),
                    EventType = EventType.Educational,
                    OrganizersNames = new List<string>()
                    {
                        "Корякин Игорь",
                        "Ковтонюк Полина",
                    },
                },
                new EventDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Кино вечер",
                    Points = 3,
                    EndTime = new DateTime(2023, 1, 25, 18, 30, 0),
                    StartTime = new DateTime(2023, 1, 25, 20, 40, 0),
                    EventType = EventType.Social,
                    OrganizersNames = new List<string>()
                    {
                        "Корякин Игорь",
                        "Ковтонюк Полина",
                    },
                },
                new EventDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Презентация проектов",
                    Desciption = "Традиционная зимняя презентация проектов!",
                    Points = 7,
                    EndTime = new DateTime(2023, 1, 25, 9, 0, 0),
                    StartTime = new DateTime(2023, 1, 25, 13, 30, 0),
                    EventType = EventType.Educational,
                    OrganizersNames = new List<string>()
                    {
                        "Корякин Игорь",
                        "Ковтонюк Полина",
                    },
                },
            };

        private static List<FullShopItemInfoDto> shopItemsInfo = new List<FullShopItemInfoDto>
        {
            CreateMockShopItem(
                "Стикерпак 1",
                10,
                "Набор стикеров от РТФ",
                "Resources.item1.png",
                Enumerable.Empty<SizeType>()),
            CreateMockShopItem(
                "Худи РТФ",
                150,
                "Толстовка черного цвета из мягкой ткани",
                "Resources.item2.png",
                new List<SizeType>
                {
                    SizeType.XS,
                    SizeType.S,
                    SizeType.M,
                    SizeType.XL,
                }),
            CreateMockShopItem(
                "Стикерпак 2",
                8,
                "Набор стикеров от РТФ",
                "Resources.item1.png",
                Enumerable.Empty<SizeType>()
                ),
            CreateMockShopItem(
                "Кружка РТФ",
                70,
                "Фарфоровая кружка на 300 мл",
                "Resources.item3.png",
                Enumerable.Empty<SizeType>()
                ),
            CreateMockShopItem(
                "Стикерпак 3",
                15,
                "Набор стикеров от РТФ",
                "Resources.item1.png",
                Enumerable.Empty<SizeType>()
                ),
            CreateMockShopItem(
                "Худи РТФ-Чемпион",
                160,
                "Толстовка черного цвета из мягкой ткани с надписью РТФ-Чемпион",
                "Resources.item2.png",
                new List<SizeType>
                {
                    SizeType.S,
                    SizeType.M,
                    SizeType.L,
                    SizeType.XL,
                }
                ),
            CreateMockShopItem(
                "Стикерпак 4",
                8,
                "Набор стикеров от РТФ",
                "Resources.item1.png",
                Enumerable.Empty<SizeType>()
                ),
        };

        private static List<UserDto> users = new List<UserDto>()
        {
            new UserDto()
            {
                Id = UserQrId,
                LastName = "Комиссаров",
                Name = "Алексей",
            }
        };

        private static List<EventDto> userEvents = allEvents.Take(5).ToList();

        private static List<BasketProductDto> basketProducts = new List<BasketProductDto>();

        private static int userBalance = userEvents.Sum(ev => ev.Points) + 137;

        private static List<OrderDto> orders = GetDefaultOrders();


        private static IEnumerable<ShopItemDto> shopItems = GetShopItems();

        private IUserStorage userStorage;

        public static Guid CurrentlyOpenedItemId { get; set; }

        public static Guid CurrentlyOpenedEventId { get; set; }

        public MockApiService()
        {
            this.userStorage = DependencyService.Get<IUserStorage>();
        }

        public Task<BasketDto> GetBasketAsync(CancellationToken cancellationToken = default)
        {
            var totalPrice = basketProducts.Sum(bp => bp.Count * bp.ProductPrice);
            return Task.FromResult(new BasketDto()
            {
                TotalPrice = totalPrice,
                BasketProducts = basketProducts,
            });
        }

        public Task<IEnumerable<EventDto>> GetEventsAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(userEvents.OrderBy(ev => ev.StartTime) as IEnumerable<EventDto>);
        }


        public Task<IEnumerable<ShopItemDto>> GetShopItems(CancellationToken cancellationToken)
        {
            return Task.FromResult(shopItems);
        }

        public Task<Guid> GetUserQrIdAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(UserQrId);
        }

        public Task<LoginResponseDto> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken = default)
        {
            var result = new LoginResponseDto("Алексей", "Комиссаров", "РИ-490023", "skaladra", "token", "admin");
            userStorage.SaveSettings(new UserSettings(result.FirstName, result.LastName, result.Group, result.UserName, result.Token, result.Role));
            return Task.FromResult(result);
        }

        public Task RegisterAsync(RegisterDto registerDto, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        private static FullShopItemInfoDto CreateMockShopItem(string name, int price, string description, string fileName, IEnumerable<SizeType> sizeTypes)
        {
            var fileHelper = new FileHelper();
            var streamFunc = new Func<Stream>(() => fileHelper.GetStreamFromFile(fileName));
            var shopItem = new FullShopItemInfoDto()
            {
                Id = Guid.NewGuid(),
                Name = name,
                NotAvailable = false,
                Description = description,
                Price = price,
                ImageSource = ImageSource.FromStream(streamFunc),
                AvailableSizes = sizeTypes,
            };
            return shopItem;
        }

        public Task AddItemToBasketAsync(NewBasketItemDto newBasketItemDto, CancellationToken cancellationToken = default)
        {
            var item = shopItemsInfo.FirstOrDefault(i => i.Id == newBasketItemDto.ProductId);
            var existingBasketProduct = basketProducts.FirstOrDefault(bp => bp.StoreProductId == item.Id);
            if (existingBasketProduct != null)
            {
                existingBasketProduct.Count++;
                return Task.CompletedTask;
            }
            basketProducts.Add(new BasketProductDto()
            {
                Name = item.Name,
                Description = item.Description,
                BasketProductId = Guid.NewGuid(),
                Count = 1,
                ImageSource = item.ImageSource,
                ProductPrice = item.Price,
                StoreProductId = item.Id,
                SizeType = newBasketItemDto.Size,
            });
            return Task.CompletedTask;
        }

        public Task RemoveItemFromBasketAsync(NewBasketItemDto basketItemDto, CancellationToken cancellationToken)
        {
            var existingBasketProduct = basketProducts.FirstOrDefault(bp => bp.BasketProductId == basketItemDto.ProductId);
            if (existingBasketProduct != null)
            {
                basketProducts.Remove(existingBasketProduct);
            }
            return Task.CompletedTask;
        }

        public Task IncrementProductCountAsync(NewBasketItemDto basketItemDto, CancellationToken cancellationToken = default)
        {
            var existingBasketProduct = basketProducts.FirstOrDefault(bp => bp.BasketProductId == basketItemDto.ProductId);
            if (existingBasketProduct != null)
            {
                existingBasketProduct.Count++;
            }
            return Task.CompletedTask;
        }

        public Task DecrementProductCountAsync(NewBasketItemDto basketItemDto, CancellationToken cancellationToken = default)
        {
            var existingBasketProduct = basketProducts.FirstOrDefault(bp => bp.BasketProductId == basketItemDto.ProductId);
            if (existingBasketProduct != null)
            {
                existingBasketProduct.Count--;
            }
            return Task.CompletedTask;
        }

        private static List<OrderDto> GetDefaultOrders()
        {
            var orders = new List<OrderDto>();
            var product = shopItemsInfo.FirstOrDefault();
            if (product == null)
            {
                return orders;
            }
            var order = new OrderDto()
            {
                Id = Guid.NewGuid(),
                Status = OrderStatus.Accepted,
                OrderProducts = new List<BasketProductDto> {
                   new BasketProductDto()
                   {
                       BasketProductId = Guid.NewGuid(),
                       StoreProductId = product.Id,
                       Description = product.Description,
                       Count = 1,
                       ImageSource = product.ImageSource,
                       Name = product.Name,
                       ProductPrice = product.Price,
                   }
                }
            };
            orders.Add(order);
            return orders;
        }

        private static List<ShopItemDto> GetShopItems()
        {
            return shopItemsInfo
                .Select(item => new ShopItemDto
                {
                    Id  = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    NotAvailable = item.NotAvailable,
                    AvailableSizeTypes = item.AvailableSizes,
                    ImageSource = item.ImageSource,
                })
                .ToList();
        }

        public Task<FullShopItemInfoDto> GetShopItemInfoDto(Guid id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(shopItemsInfo.FirstOrDefault(item => item.Id == id));
        }

        public Task<int> GetCurrentUserBalanceAsync()
        {
            return Task.FromResult(userBalance);
        }

        public Task MakeOrder(IEnumerable<Guid> ProductsIds)
        {
            var orderProducts = new List<BasketProductDto>();
            foreach (var productId in ProductsIds)
            {
                var product = basketProducts.FirstOrDefault(bp => bp.BasketProductId == productId);
                if (product != null)
                {
                    orderProducts.Add(product);
                    basketProducts.Remove(product);
                }
            }
            var totalCount = orderProducts.Sum(p => p.Count * p.ProductPrice);
            userBalance -= totalCount;
            orders.Add(new OrderDto()
            {
                Id = Guid.NewGuid(),
                OrderProducts = orderProducts,
                Status = OrderStatus.InProgress,
            });
            return Task.CompletedTask;
        }

        public Task<List<OrderDto>> GetOrdersAsync()
        {
            return Task.FromResult(orders);
        }

        public Task CancelOrderAsync(Guid orderId)
        {
            var order = orders.FirstOrDefault(o => o.Id == orderId);
            order.Status = OrderStatus.Cancelled;
            userBalance += order.OrderProducts.Sum(bp => bp.Count * bp.ProductPrice);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<EventShortInfoDto>> GetEventsByDateIntervalAsync(DateTime start, DateTime end)
        {
            return Task.FromResult(allEvents
                .Where(ev => ev.StartTime > start && ev.EndTime < end)
                .Select(ev => new EventShortInfoDto()
                {
                    Id = ev.Id,
                    EndTime = ev.EndTime,
                    StartTime = ev.StartTime,
                    EventType = ev.EventType,
                    Name = ev.Name,
                }));
        }

        public Task<EventDto> GetFullInfoAboutEvent(Guid id)
        {
            return Task.FromResult(allEvents.FirstOrDefault(ev => ev.Id == id));
        }

        public Task<UserDto> GetUserInfoAsync(Guid id)
        {
            return Task.FromResult(users.FirstOrDefault(us => us.Id == id));
        }

        public Task AddUserToEvent(Guid userId, Guid eventId)
        {
            var @event = allEvents.FirstOrDefault(ev => ev.Id == eventId);
            if (!userEvents.Contains(@event))
            {
                userEvents.Add(@event);
                userBalance += @event.Points;
            }
            return Task.CompletedTask;
        }
    }
}
