using MailKit.Net.Smtp;
using MimeKit;
using RFT.Services.DtoModels;
using RFT.Services.ServiceInterfaces;
using RTF.Core.Infrastructure;
using RTF.Core.Models.IdentityModels.Configuration;

namespace RFT.Services.Services;

public class EmailService : IEmailService
{
    private readonly IEmailConfigProvider _emailConfigProvider;
    private EmailConfiguration _emailConfiguration;

    public EmailService(IEmailConfigProvider emailConfigProvider)
    {
        _emailConfigProvider = emailConfigProvider;
    }

    public async Task SendEmailAsync(Message message)
    {
        _emailConfiguration = _emailConfigProvider.GetConfiguration();
        var mailMessage = CreateEmailMessage(message);
        await SendAsync(mailMessage);
    }
    
    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_emailConfiguration.UserName, _emailConfiguration.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = $"<h2 style='color:red;'>{message.Content}</h2>" };

        emailMessage.Body = bodyBuilder.ToMessageBody();
        return emailMessage;
    }

    private async void Send(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfiguration.UserName, _emailConfiguration.Password);

            await client.SendAsync(mailMessage);
        }
        catch
        {
            //log an error message or throw an exception, or both.
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }

    private async Task SendAsync(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfiguration.UserName, _emailConfiguration.Password);

            await client.SendAsync(mailMessage);
        }
        catch
        {
            //log an error message or throw an exception, or both.
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}