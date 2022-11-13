using RTF.Core.Models.IdentityModels.Configuration;

namespace RTF.Core.Infrastructure;

public interface IEmailConfigProvider
{
    EmailConfiguration GetConfiguration();
}