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
    /// Добавить пользователю коины
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="coins"></param>
    /// <returns>Кол-во коинов юзера с учетом добавленных</returns>
    Task<double> IncreaseUserBalance(long userId, double coins); 
}