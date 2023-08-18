using EntityFrameworkTest.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EntityFrameworkTest.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        /// <summary>
        /// used for rolling back a transaction or executing the transaction
        /// </summary>
        private IDbContextTransaction? _objTran;
        public DbContext DbContext { get; }

        public UnitOfWork(DbContext dbcontext)
        {
            DbContext = dbcontext;
        }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _objTran!.CommitAsync(cancellationToken);
        }

        public async Task CreateTransactionAsync(CancellationToken cancellationToken)
        {
            _objTran = await DbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public Task RollbackAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected virtual async void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    await DbContext.DisposeAsync();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
