using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RTF.Core.Models.IdentityModels;
using RTF.CQS.Commands;
using RTF.CQS.ModelsFromUI.ResponseModels;

namespace RTF.WebApp.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : Controller
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator, IdentityContext identityContext)
    {
        _mediator = mediator;
        //TODO хз куда еще вынести
        identityContext.Database.EnsureCreated();
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("register")]
    public async Task<IActionResult> Register(RegistrationCommand command)
    {
        if (!ModelState.IsValid)
        {
            return new BadRequestObjectResult(command);
        }

        await _mediator.Send(command);
        return new OkResult();
    }

    // [HttpGet]
    // [Route("confirmEmail")]
    // public async Task<IActionResult> ConfirmEmail(string token, string email)
    // {
    //     var user = await _userManager.FindByEmailAsync(email);
    //     if (user == null)
    //         return new NotFoundObjectResult("Not found user with entered email");
    //
    //     var result = await _userManager.ConfirmEmailAsync(user, token);
    //     return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
    // }

    // [HttpGet]
    // public IActionResult SuccessRegistration()
    // {
    // }

    // [HttpGet]
    // [Route("login")]
    // public IActionResult Login(string returnUrl = null)
    // {
    //     ViewData["ReturnUrl"] = returnUrl;
    //     return Ok(ViewData);
    // }

    [HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginCommand command)
    {
        var result = await _mediator.Send(command);
        return result;
    }

    // [HttpPost]
    // [Route("logout")]
    // public async Task<IActionResult> Logout()
    // {
    //     await _signInManager.SignOutAsync();
    //
    //     return new RedirectResult("account/login");
    // }

    // [HttpGet]
    // public IActionResult ForgotPassword()
    // {
    // }

    // [HttpPost]
    // [Route("forgotPassword")]
    // public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
    // {
    //     if (!ModelState.IsValid)
    //         return new BadRequestObjectResult(forgotPasswordModel);
    //
    //     var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
    //     if (user == null)
    //         return new NotFoundResult();
    //
    //     var token = await _userManager.GeneratePasswordResetTokenAsync(user);
    //     var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);
    //
    //     var message = new Message(new List<(string name, string address)>{ (user.Email, user.Email) }, "Reset password token", callback);
    //     await _emailService.SendEmailAsync(message);
    //
    //     return Ok(forgotPasswordModel);
    // }

    // public IActionResult ForgotPasswordConfirmation()
    // {
    // }

    // [HttpGet]
    // [Route("resetPassword")]
    // public IActionResult ResetPassword(string token, string email)
    // {
    //     var model = new ResetPasswordModel { Token = token, Email = email };
    //     return Ok(model);
    // }
    //
    // [HttpPost]
    // [Route("resetPassword")]
    // public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
    // {
    //     if (!ModelState.IsValid)
    //         return new BadRequestObjectResult(resetPasswordModel);
    //
    //     var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
    //     if (user == null)
    //         return new BadRequestObjectResult(resetPasswordModel);
    //
    //     var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
    //     if (!resetPassResult.Succeeded)
    //     {
    //         foreach (var error in resetPassResult.Errors)
    //         {
    //             ModelState.TryAddModelError(error.Code, error.Description);
    //         }
    //
    //         return new ViewResult();
    //     }
    //
    //     return new RedirectResult("account/login");
    // }

    // [HttpGet]
    // public IActionResult ResetPasswordConfirmation()
    // {
    //     return View();
    // }

    // private IActionResult RedirectToLocal(string returnUrl)
    // {
    //     if (Url.IsLocalUrl(returnUrl))
    //     {
    //         return new RedirectResult(returnUrl);
    //     }
    //
    //     return new RedirectResult("account/login");
    // }

    // [HttpGet]
    // public IActionResult Error()
    // {
    //     return View();
    // }
}