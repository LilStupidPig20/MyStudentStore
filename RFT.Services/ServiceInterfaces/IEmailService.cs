using RFT.Services.DtoModels;

namespace RFT.Services.ServiceInterfaces;

public interface IEmailService
{
    Task SendEmailAsync(Message message);
}