using TaskManagement.Core.Interfaces.Database;
using TaskManagement.Core.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagement.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TaskManagementDbContext _context;
    private bool disposed = false;

    public UnitOfWork(TaskManagementDbContext context)
    {
        _context = context;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public IRepository<T> AsyncRepository<T>() where T : class
    {
        return new Repository<T>(_context);
    }

    private async Task Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                await _context.DisposeAsync();
            }
        }
        disposed = true;
    }

    public async Task Dispose()
    {
        await Dispose(true);
        //Requests that the common language runtime not call the finalizer for the specified object.
        GC.SuppressFinalize(this);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
