using System;
using System.Linq.Expressions;
using McfApi.Context;
using McfApi.Models;
using Microsoft.EntityFrameworkCore;

namespace McfApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EfCoreContext _context;

        public UserRepository(EfCoreContext context)
        {
            _context = context;
        }

        public UserModel Attach(UserModel entity)
        {
            var result = _context.Set<UserModel>().Attach(entity);
            return result.Entity;
        }

        public async Task<UserModel> Delete(UserModel entity)
        {
            var result = _context.Set<UserModel>().Remove(entity);
            return result.Entity;
        }

        public async Task<List<UserModel>> FindAllAsync()
        {
            var result = await _context.Set<UserModel>().ToListAsync();
            return result;
        }

        public async Task<UserModel> FindByIdAsync(int id)
        {
            var result = await _context.Set<UserModel>().FindAsync(id);
            return result;
        }

        public async Task<UserModel> FindByUsernameAndPasswordAsync(string user_name, string password)
        {
            var result = await _context.Set<UserModel>().Where(p => p.user_name == user_name && p.password == password).FirstOrDefaultAsync();
            return result;
        }

        public async Task<UserModel> SaveAsync(UserModel entity)
        {
            var result = await _context.Set<UserModel>().AddAsync(entity);
            return result.Entity;
        }

        public UserModel Update(UserModel entity)
        {
            Attach(entity);
            var result = _context.Set<UserModel>().Update(entity);
            return result.Entity;
        }
    }
}

