using RTF.Core.Models;

namespace RFT.Services.ServiceInterfaces;

public interface IStudentBalanceService
{
    /// <summary>
    /// Получает баланс пользователя по id пользователя
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<double> GetUserBalance(Guid userId);

    /// <summary>
    /// Добавить пользователю коины. Сохранения в базу не происходит
    /// </summary>
    /// <param name="userQr"></param>
    /// <param name="coins"></param>
    Task<UserInfo> FindUserByQrAndIncreaseBalance(Guid userQr, double coins); 
}