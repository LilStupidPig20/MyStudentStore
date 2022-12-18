using RFT.Services.ServiceInterfaces;
using RTF.Core.Infrastructure;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RFT.Services.Services;

public class StudentBalanceService : IStudentBalanceService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentBalanceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<double> GetUserBalance(Guid userId)
    {
        var repository = _unitOfWork.GetRepository<UserInfo>();
        var userInfo = await repository.FindOneBy(x => x.Id == userId);
        if (userInfo == null)
        {
            throw new ArgumentNullException($"Пользователь с переданным идентификатором {userId} не найден");
        }
        
        return userInfo.Balance;
    }

    public Task<double> IncreaseUserBalance(long userId, double coins)
    {
        throw new NotImplementedException();
    }
}