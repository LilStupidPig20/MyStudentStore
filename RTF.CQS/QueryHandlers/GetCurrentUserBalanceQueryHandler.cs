using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ApplicationServices;
using RTF.CQS.Commands;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class GetCurrentUserBalanceQueryHandler : QueryHandler<GetCurrentUserBalanceQuery, double>
{
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IStudentBalanceService _balanceService;

    public GetCurrentUserBalanceQueryHandler(ICurrentUserProvider currentUserProvider, IStudentBalanceService balanceService)
    {
        _currentUserProvider = currentUserProvider;
        _balanceService = balanceService;
    }

    public override async Task<double> Handle(GetCurrentUserBalanceQuery request, CancellationToken ct)
    {
        var currentUserId = (await _currentUserProvider.GetCurrentUserAsync()).Id;
        var currentBalance = await _balanceService.GetUserBalance(Guid.Parse(currentUserId));
        return currentBalance;
    }
}