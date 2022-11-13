using System.Net;
using Microsoft.AspNetCore.Identity;
using RFT.Services.ServiceInterfaces;
using RTF.Core.Models.IdentityModels;
using RTF.CQS.Abstractions;
using RTF.CQS.Exceptions;
using RTF.CQS.Queries;

namespace RTF.CQS.QueryHandlers;

public class RegistrationQueryHandler : QueryHandler<RegistrationQuery, bool>
{
    private readonly UserManager<User> _userManager;
    private readonly IStudentBalanceService _balanceService;

    public RegistrationQueryHandler(UserManager<User> userManager, IStudentBalanceService balanceService)
    {
        _userManager = userManager;
        _balanceService = balanceService;
    }

    public override async Task<bool> Handle(RegistrationQuery request, CancellationToken ct)
    {
        if (request.Email.Split('@').Last() != "urfu.me")
        {
            throw new ArgumentException("Домен почты должен быть \"urfu.me\"");
        }

        var user = new User
        {
            Email = request.Email,
            Group = request.Group,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = request.Password,
            UserName = request.Email
        };
    
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new RestException(HttpStatusCode.BadRequest, result.Errors);
        }
    
        //TODO разобраться с подтверждением почты
        // var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //
        // var message = new Message(new List<(string name, string address)>{ (user.Email, user.Email) }, "Confirmation email link", confirmationLink);
        // await _emailService.SendEmailAsync(message);
    
        await _userManager.AddToRoleAsync(user, "student");

        await _balanceService.AddNewRecord(Guid.Parse(user.Id));

        return true;
    }
}