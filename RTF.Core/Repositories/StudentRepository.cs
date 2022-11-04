using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class StudentRepository : Repository<Student>
{
    private readonly ConnectionContext _context;

    public StudentRepository(ConnectionContext context) : base(context)
    {
        _context = context;
    }
}