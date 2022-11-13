using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class StudentBalanceRepository : Repository<StudentBalance>
{
    public StudentBalanceRepository(ConnectionContext context) : base(context)
    {
    }

    public async Task<StudentBalance> GetBalanceByUserId(Guid userId)
    {
        var record = _table.FirstOrDefault(x => x.UserId == userId);
        if (record == null)
        {
            throw new Exception($"У пользователя с переданным id {userId} отсутствует запись в таблице баланса");
        }

        return record;
    }
}