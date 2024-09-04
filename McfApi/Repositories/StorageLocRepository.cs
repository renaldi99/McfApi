using System;
using McfApi.Context;
using McfApi.Models;
using Microsoft.EntityFrameworkCore;

namespace McfApi.Repositories
{
	public class StorageLocRepository : IStorageLocRepository
	{
        private readonly EfCoreContext _context;

        public StorageLocRepository(EfCoreContext context)
        {
            _context = context;
        }

        public StorageLocationModel Attach(StorageLocationModel entity)
        {
            var result = _context.Set<StorageLocationModel>().Attach(entity);
            return result.Entity;
        }

        public async Task<StorageLocationModel> Delete(StorageLocationModel entity)
        {
            var result = _context.Set<StorageLocationModel>().Remove(entity);
            return result.Entity;
        }

        public async Task<List<StorageLocationModel>> FindAllAsync()
        {
            var result = await _context.Set<StorageLocationModel>().ToListAsync();
            return result;
        }

        public async Task<StorageLocationModel> FindByIdAsync(int id)
        {
            var result = await _context.Set<StorageLocationModel>().FindAsync(id);
            return result;
        }

        public async Task<StorageLocationModel> SaveAsync(StorageLocationModel entity)
        {
            var result = await _context.Set<StorageLocationModel>().AddAsync(entity);
            return result.Entity;
        }

        public StorageLocationModel Update(StorageLocationModel entity)
        {
            Attach(entity);
            var result = _context.Set<StorageLocationModel>().Update(entity);
            return result.Entity;
        }
    }
}

