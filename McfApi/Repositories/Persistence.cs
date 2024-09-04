using System;
using McfApi.Context;

namespace McfApi.Repositories
{
    public class Persistence : IPersistence
    {
        private readonly EfCoreContext _context;

        public Persistence(EfCoreContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            int affected = await _context.SaveChangesAsync();
            return affected;
        }
    }
}

