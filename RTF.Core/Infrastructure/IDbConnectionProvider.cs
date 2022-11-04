using Microsoft.EntityFrameworkCore;
using RTF.Core.Repositories;

namespace RTF.Core.Infrastructure;

public interface IDbConnectionProvider
{
    ConnectionContext GetDbConnection();
}