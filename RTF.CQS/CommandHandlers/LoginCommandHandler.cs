using System.Net;
using Microsoft.AspNetCore.Identity;
using RTF.Core.Models.IdentityModels;
using RTF.CQS.Abstractions;
using RTF.CQS.Commands;
using RTF.CQS.Exceptions;
using RTF.CQS.ModelsFromUI.ResponseModels;
using RTF.Infrastructure.Helpers;

namespace RTF.CQS.CommandHandlers;

public class LoginCommandHandler : CommandHandler<LoginCommand, LoginResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenGenerator _tokenGenerator;

    public LoginCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, ITokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenGenerator = tokenGenerator;
    }

    public override async Task<LoginResponse> HandleWithResult(LoginCommand request, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new RestException(HttpStatusCode.Unauthorized, "Неверный логин/пароль");
        }

        var result = await _signInManager.PasswordSignInAsync(
            request.Email, request.Password, request.RememberMe, false);

        if (!result.Succeeded)
        {
            throw new RestException(HttpStatusCode.Unauthorized, "Неверный логин/пароль");
        }

        var roles = await _userManager.GetRolesAsync(user);
        return new LoginResponse
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Group = user.Group,
            Token = _tokenGenerator.GenerateToken(user, roles),                       
            UserName = user.UserName,
            Role = roles.FirstOrDefault()
        };
    }
}