﻿using RFT.Services.DtoModels;
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
        var userInfoRepo = _unitOfWork.GetRepository<UserInfo>();

        await userInfoRepo.AddAsync(new UserInfo
        {
            Id = userInfoDto.Id,
            Email = userInfoDto.Email,
            Group = userInfoDto.Group,
            FirstName = userInfoDto.FirstName,
            LastName = userInfoDto.LastName,
            Balance = 0,
            Basket = new Basket
            {
                BasketProducts = new List<BasketProduct>()
            },
            QrCodeId = Guid.NewGuid()
        });
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<Guid> GetStudentQrGuid(Guid studentId)
    {
        var userInfoRepo = _unitOfWork.GetRepository<UserInfo>();
        var userInfo = await userInfoRepo.GetAsync(studentId);
        return userInfo.QrCodeId;
    }
}