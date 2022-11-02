using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RTF.Core.Infrastructure;

public interface IDbProvider
{
    string GetDbConnectionString();
}