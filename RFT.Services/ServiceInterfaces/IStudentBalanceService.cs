namespace RFT.Services.ServiceInterfaces;

public interface IStudentBalanceService
{
    /// <summary>
    /// Добавление новой записи в таблицу, связанной с id юзера
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddNewRecord(Guid userId, CancellationToken cancellationToken);

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