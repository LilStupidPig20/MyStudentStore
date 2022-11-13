using Microsoft.Extensions.Configuration;
using RTF.Core.Models.IdentityModels.Configuration;

namespace RTF.Core.Infrastructure;

public class EmailConfigProvider : IEmailConfigProvider
{
    private readonly IConfiguration _configuration;
    private EmailConfiguration? _instance;

    public EmailConfigProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public EmailConfiguration GetConfiguration()
    {
        if (_instance != null && !String.IsNullOrEmpty(_instance.From))
        {
            return _instance;
        }

        var config = _configuration.GetSection("EmailConfiguration");
        _instance = new EmailConfiguration
        {
            From = config["From"],
            Password = config["Password"],
            Port = Convert.ToInt32(config["Port"]),
            SmtpServer = config["SmtpServer"],
            UserName = config["UserName"]
        };
        return _instance;
    }
}