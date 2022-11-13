using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RTF.Core.Infrastructure;

public class NpgsqlProvider : IDbProvider
{
    private readonly IConfiguration _configuration;

    public NpgsqlProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetDbConnectionString()
    {
        var connections = _configuration.GetSection("ConnectionStrings");
        var pgConnection = connections["NpgsqlConnection"];
        if (string.IsNullOrEmpty(pgConnection))
            throw new Exception("Не задан ConnectionString для провайдера NpgSql");
        return pgConnection;
    }

    public string GetIdentityConnectionString()
    {
        var connections = _configuration.GetSection("ConnectionStrings");
        var pgConnection = connections["IdentityDataBaseConnection"];
        if (string.IsNullOrEmpty(pgConnection))
            throw new Exception("Не задан ConnectionString для базы Identity");
        return pgConnection;
    }
}