using System;
using McfApi.Context;
using McfApi.Models;
using Microsoft.EntityFrameworkCore;

namespace McfApi.Repositories
{
    public class BPKBRepository : IBPKBRepository
    {
        private readonly EfCoreContext _context;

        public BPKBRepository(EfCoreContext context)
        {
            _context = context;
        }

        public BPKBModel Attach(BPKBModel entity)
        {
            var result = _context.Set<BPKBModel>().Attach(entity);
            return result.Entity;
        }

        public async Task<BPKBModel> Delete(BPKBModel entity)
        {
            var result = _context.Set<BPKBModel>().Remove(entity);
            return result.Entity;
        }

        public async Task<List<BPKBModel>> FindAllAsync()
        {
            var result = await _context.Set<BPKBModel>().ToListAsync();
            return result;
        }

        public async Task<BPKBModel> FindByIdAsync(int id)
        {
            var result = await _context.Set<BPKBModel>().FindAsync(id);
            return result;
        }

        public async Task<BPKBModel> SaveAsync(BPKBModel entity)
        {
            var result = await _context.Set<BPKBModel>().AddAsync(entity);
            return result.Entity;
        }

        public BPKBModel Update(BPKBModel entity)
        {
            Attach(entity);
            var result = _context.Set<BPKBModel>().Update(entity);
            return result.Entity;
        }
    }
}

