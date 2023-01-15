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
            FirstName = "Тест",
            LastName = "Тестовый",
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
            }
        });

        return Guid.Parse(user.Id);
    }
    
    private async Task<Guid> InitDefaultAdminAsync()
    {
        var admin = new User
        {
            Email = "testAdmin@urfu.me",
            Group = "admins",
            FirstName = "Админ",
            LastName = "ЭтойКачалки",
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

        var defaultEvent = new Event
        {
            Coins = 1.5,
            Description = "аовАвоаловпапорыдпр воылаоплды 2323 апырпраылопрлы",
            Name = "Тестовое мероприятие",
            EventType = EventType.Entertainment,
            IsFinished = true,
            StartDateTime = new DateTime(2022, 12, 1, 12, 0, 0, DateTimeKind.Local),
            EndDateTime = new DateTime(2022, 12, 1, 14, 0, 0, DateTimeKind.Local),
            Users = (ICollection<UserInfo>)users,
            Organizers = (ICollection<AdminInfo>)admins
        };
        await repo.AddAsync(defaultEvent);
    }
    
    private async Task InitProducts()
    {
        var repo = _unitOfWork.GetRepository<StoreProduct>();
        var product1 = new StoreProduct
        {
            Name = "Кружка",
            Description = "Ну кружка и кружка, чо бухтеть то",
            Price = 5,
            TotalQuantity = 100
        };
        var product2 = new StoreProduct
        {
            Name = "Павербанк",
            Description = "На 10 зарядок айфона должно хватить",
            Price = 15,
            TotalQuantity = 56
        };
        var product3 = new StoreProduct
        {
            Name = "Стикерпак",
            Description = "Стикерпак хуй пойми с чем",
            Price = 2,
            TotalQuantity = 404
        };
        var product4 = new ClothesProduct
        {
            Name = "Толстовка",
            Description = "Ртф чемпион хули",
            Price = 40,
            TotalQuantity = 33,
            Image = "qwe/wqeqer/tyy.png",
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

        await repo.AddAsync(product1);
        _unitOfWork.SaveChanges();
        await repo.AddAsync(product2);
        _unitOfWork.SaveChanges();
        await repo.AddAsync(product3);
        _unitOfWork.SaveChanges();
        await repo.AddAsync(product4);
    }
}