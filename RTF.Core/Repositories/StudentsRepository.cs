using RTF.Core.Infrastructure;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class StudentsRepository : BaseRepository<User>
{
    public StudentsRepository(IDbProvider dbProvider) : base(dbProvider)
    {
    }
}