using RFT.Services.ServiceInterfaces;
using RTF.CQS.Abstractions;
using RTF.CQS.ApplicationServices;
using RTF.CQS.Commands;

namespace RTF.CQS.CommandHandlers;

public class GetCurrentUserBalanceHandler : CommandHandler<GetCurrentUserBalanceCommand, double>
{
    private readonly ICurrentUserProvider _currentUserProvider;
    private readonly IStudentBalanceService _balanceService;

    public GetCurrentUserBalanceHandler(ICurrentUserProvider currentUserProvider, IStudentBalanceService balanceService)
    {
        _currentUserProvider = currentUserProvider;
        _balanceService = balanceService;
    }

    public override async Task<double> HandleWithResult(GetCurrentUserBalanceCommand request, CancellationToken ct)
    {
        var currentUserId = (await _currentUserProvider.GetCurrentUserAsync()).Id;
        var currentBalance = await _balanceService.GetUserBalance(Guid.Parse(currentUserId));
        return currentBalance;
    }
}