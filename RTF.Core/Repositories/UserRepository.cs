using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class UserRepository : IRepository<User>, IDisposable
{
    private readonly StorageContext _context;

    public UserRepository(StorageContext context)
    {
        _context = context;
    }

    public Task<IList<User>> GetAllAsync()
    {
        return Task.FromResult<IList<User>>(_context.Users.ToList());
    }

    private bool _disposed;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}