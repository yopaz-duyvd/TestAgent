using Microsoft.EntityFrameworkCore.Storage;
using TruyenVerse.Application.Interfaces;

namespace TruyenVerse.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TruyenVerseDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(TruyenVerseDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction ??= await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction is not null)
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
            else
            {
                await _context.SaveChangesAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction is null)
            {
                return;
            }

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
