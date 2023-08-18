using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }
        Task CreateTransactionAsync(CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
        Task RollbackAsync(CancellationToken cancellationToken);
    }
}
