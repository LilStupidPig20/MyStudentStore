using RFT.Services.DtoModels;
using RFT.Services.ServiceInterfaces;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RFT.Services.Services;

public class UserInfoService : IUserInfoService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserInfoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateUserInfoAsync(UserInfoDto userInfoDto, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.GetRepository<UserInfo>();
        await repo.AddAsync(new UserInfo
        {
            Id = userInfoDto.Id,
            Email = userInfoDto.Email,
            Group = userInfoDto.Group,
            FirstName = userInfoDto.FirstName,
            LastName = userInfoDto.LastName,
            Balance = 0
        });
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}