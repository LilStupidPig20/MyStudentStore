using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class UserInfoRepository : Repository<UserInfo>
{
    public UserInfoRepository(ConnectionContext context) : base(context)
    {
    }
}