using Microsoft.AspNetCore.Identity;
using RFT.Services.ServiceInterfaces;
using RTF.AdminServices.DtoModels;
using RTF.AdminServices.Interfaces;
using RTF.Core.Models;
using RTF.Core.Models.Enums;
using RTF.Core.Models.IdentityModels;
using RTF.Core.Repositories;

namespace RFT.Services.Helpers;

public interface IDataInitializer
{
    Task InitDataAsync();
}

public class DataInitializer : IDataInitializer
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;
    private readonly IUserInfoService _userInfoService;
    private readonly IAdminInfoService _adminInfoService;

    public DataInitializer(IUnitOfWork unitOfWork,
        UserManager<User> userManager,
        IUserInfoService userInfoService,
        IAdminInfoService adminInfoService)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _userInfoService = userInfoService;
        _adminInfoService = adminInfoService;
    }

    public async Task InitDataAsync()
    {
        var userId = await InitDefaultUserAsync();
        var adminId = await InitDefaultAdminAsync();
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        await InitEvents(userId, adminId);
        await InitProducts();
        _unitOfWork.SaveChanges();
    }

    private async Task<Guid> InitDefaultUserAsync()
    {
        var user = new User
        {
            Email = "testuser@urfu.me",
            Group = "РИ-490003",
            FirstName = "Иван",
            LastName = "Иванов",
            PasswordHash = "P@ssw0rd",
            UserName = "testuser@urfu.me"
        };

        await _userManager.CreateAsync(user, "P@ssw0rd");
        await _userManager.AddToRoleAsync(user, "student");

        var usersRepo = (UserInfoRepository)_unitOfWork.GetRepository<UserInfo>();
        usersRepo.Table.Add(new UserInfo
        {
            Id = Guid.Parse(user.Id),
            Email = user.Email,
            Group = user.Group,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Balance = 100,
            Basket = new Basket
            {
                BasketProducts = new List<BasketProduct>()
            },
            QrCodeId = Guid.NewGuid()
        });

        return Guid.Parse(user.Id);
    }
    
    private async Task<Guid> InitDefaultAdminAsync()
    {
        var admin = new User
        {
            Email = "testAdmin@urfu.me",
            Group = "admins",
            FirstName = "Корякин",
            LastName = "Борис",
            PasswordHash = "Admin000!",
            UserName = "testAdmin@urfu.me"
        };

        await _userManager.CreateAsync(admin, "Admin000!");
        await _userManager.AddToRoleAsync(admin, "admin");

        await _adminInfoService.CreateAdminInfoAsync(new AdminInfoDto
        {
            Id = Guid.Parse(admin.Id),
            Email = admin.Email,
            Group = admin.Group,
            FirstName = admin.FirstName,
            LastName = admin.LastName
        }, CancellationToken.None);
        await _unitOfWork.SaveChangesAsync(CancellationToken.None);
        
        return Guid.Parse(admin.Id);
    }

    private async Task InitEvents(Guid userId, Guid adminId)
    {
        var repo = _unitOfWork.GetRepository<Event>();
        var userRepo = _unitOfWork.GetRepository<UserInfo>();
        var users = await userRepo.FindBy(x => x.Id == userId);

        var adminsRepo = _unitOfWork.GetRepository<AdminInfo>();
        var admins = await adminsRepo.FindBy(x => x.Id == adminId);

        var event1 = new Event
        {
            Coins = 10,
            Description = "Разработческий командный хакатон, организованный УЦСБ",
            Name = "Хакатон",
            EventType = EventType.Academic,
            IsFinished = true,
            StartDateTime = new DateTime(2023, 01, 12, 12, 0, 0, DateTimeKind.Local),
            EndDateTime = new DateTime(2023, 01, 12, 20, 0, 0, DateTimeKind.Local),
            Users = (ICollection<UserInfo>)users,
            Organizers = (ICollection<AdminInfo>)admins
        };
        await repo.AddAsync(event1);
        _unitOfWork.SaveChanges();
        
        var event2 = new Event
        {
            Coins = 4.5,
            Description = "Первое мероприятие в учебном году. Позволяет новоприбывшим втянуться в студенческую жизнь и познакомиться с наставниками",
            Name = "Неделя первокурсника",
            EventType = EventType.Entertainment,
            IsFinished = true,
            StartDateTime = new DateTime(2022, 09, 01, 12, 0, 0, DateTimeKind.Local),
            EndDateTime = new DateTime(2022, 09, 01, 14, 0, 0, DateTimeKind.Local),
            Users = (ICollection<UserInfo>)users,
            Organizers = (ICollection<AdminInfo>)admins
        };
        await repo.AddAsync(event2);
        _unitOfWork.SaveChanges();
        
        var event3 = new Event
        {
            Coins = 6,
            Description = "Мероприятие, где ты можешь послушать стихотворения либо сам прочитать перед публикой",
            Name = "Литературный вечер",
            EventType = EventType.Entertainment,
            IsFinished = true,
            StartDateTime = new DateTime(2023, 01, 25, 19, 0, 0, DateTimeKind.Local),
            EndDateTime = new DateTime(2023, 01, 25, 21, 0, 0, DateTimeKind.Local),
            Users = (ICollection<UserInfo>)users,
            Organizers = (ICollection<AdminInfo>)admins
        };
        await repo.AddAsync(event3);
        _unitOfWork.SaveChanges();
    }
    
    private async Task InitProducts()
    {
        var repo = _unitOfWork.GetRepository<StoreProduct>();
        var product1 = new StoreProduct
        {
            Name = "Кружка",
            Description = "Черная кружка 200мл",
            Price = 5,
            TotalQuantity = 100,
            Image = "/productImages/rtfCup.jpg"
        };
        var product2 = new StoreProduct
        {
            Name = "Павербанк",
            Description = "Черный повербанк на 10000 мАч",
            Price = 15,
            TotalQuantity = 56,
            Image = "/productImages/rtfPower.jpeg"
        };
        var product3 = new StoreProduct
        {
            Name = "Ручка",
            Description = "Оранжевая ручка Naumen",
            Price = 2,
            TotalQuantity = 404,
            Image = "/productImages/rtfPen.png"
        };
        var product4 = new ClothesProduct
        {
            Name = "Худи",
            Description = "Черное худи с капюшоном РТФ Чемпион",
            Price = 30,
            TotalQuantity = 33,
            Image = "/productImages/rtfHoodi.jpg",
            ClothesInfos = new List<ClothesInfo>
            {
                new()
                {
                    Count = 11,
                    Size = Size.SSize
                },
                new()
                {
                    Count = 10,
                    Size = Size.MSize
                },
                new()
                {
                    Count = 12,
                    Size = Size.LSize
                }
            }
        };
        var product5 = new StoreProduct
        {
            Name = "Рюкзак",
            Description = "Серый рюкзак Xiaomi",
            Price = 50,
            TotalQuantity = 10,
            Image = "/productImages/rtfBackpack.jpg"
        };
        var product6 = new StoreProduct
        {
            Name = "Ежедневник",
            Description = "Черный ежедневник UDV",
            Price = 5,
            TotalQuantity = 54,
            Image = "/productImages/rtfDiary.jpg"
        };

        await repo.AddAsync(product1);
        _unitOfWork.SaveChanges();
        await repo.AddAsync(product2);
        _unitOfWork.SaveChanges();
        await repo.AddAsync(product3);
        _unitOfWork.SaveChanges();
        await repo.AddAsync(product4);
        _unitOfWork.SaveChanges();
        await repo.AddAsync(product5);
        _unitOfWork.SaveChanges();
        await repo.AddAsync(product6);
        _unitOfWork.SaveChanges();
    }
}