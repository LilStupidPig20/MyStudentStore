using RFT.Services.ServiceInterfaces;
using RTF.Core.Infrastructure;
using RTF.Core.Models;
using RTF.Core.Repositories;

namespace RFT.Services.Services;

public class StudentBalanceService : IStudentBalanceService
{
    private readonly IDbConnectionProvider _dbConnectionProvider;

    public StudentBalanceService(IDbConnectionProvider dbConnectionProvider)
    {
        _dbConnectionProvider = dbConnectionProvider;
    }

    public async Task AddNewRecord(Guid userId)
    {
        await using var conn = _dbConnectionProvider.GetDbConnection();
        var repository = new StudentBalanceRepository(conn);
        await repository.AddAsync(new StudentBalance
        {
            UserId = userId,
            Balance = 0
        });
        await conn.SaveChangesAsync();
    }

    public async Task<double> GetUserBalance(Guid userId)
    {
        await using var conn = _dbConnectionProvider.GetDbConnection();
        var repository = new StudentBalanceRepository(conn);
        var balance = await repository.GetBalanceByUserId(userId);
        return balance.Balance;
    }

    public Task<double> IncreaseUserBalance(long userId, double coins)
    {
        throw new NotImplementedException();
    }
}