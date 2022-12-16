using RFT.Services.DtoModels;
using RTF.Core.Models;

namespace RFT.Services.ServiceInterfaces;

public interface IUserInfoService
{
    Task CreateUserInfoAsync(UserInfoDto userInfoDto, CancellationToken cancellationToken);
}