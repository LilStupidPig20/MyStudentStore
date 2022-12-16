using Microsoft.EntityFrameworkCore.Infrastructure;
using RTF.Core.Models;

namespace RTF.Core.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ConnectionContext _context;
    private bool _disposed;

    public UnitOfWork(ConnectionContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : DataModel
    {
        var customRepo = _context.GetService<IRepository<TEntity>>();
        return customRepo;
    }
    
    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    /// <param name="disposing">The disposing.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // dispose the db context.
                _context.Dispose();
            }
        }

        _disposed = true;
    }
}