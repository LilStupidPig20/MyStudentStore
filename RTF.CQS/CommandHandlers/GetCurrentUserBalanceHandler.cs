using Microsoft.AspNetCore.Identity;
using RFT.Services.ServiceInterfaces;
using RTF.Core.Models.IdentityModels;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;

namespace RTF.CQS.CommandHandlers;

public class GetCurrentUserBalanceHandler : CommandHandler<GetCurrentUserBalance, double>
{
    private readonly UserManager<User> _userManager;
    private readonly IStudentBalanceService _balanceService;

    public GetCurrentUserBalanceHandler(UserManager<User> userManager, IStudentBalanceService balanceService)
    {
        _userManager = userManager;
        _balanceService = balanceService;
    }

    public override async Task<double> HandleWithResult(GetCurrentUserBalance request, CancellationToken ct)
    {
        //TODO вынести в какой-нибудь UserProvider.GetCurrent?
        var currentUserId = (await _userManager.GetUserAsync(request.CurrentUserClaims)).Id;
        var currentBalance = await _balanceService.GetUserBalance(Guid.Parse(currentUserId));
        return currentBalance;
    }
}