using System;
using McfApi.DTOs;
using McfApi.Models;
using McfApi.Repositories;

namespace McfApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPersistence _persistence;

        public UserService(IUserRepository repository, IPersistence persistence)
        {
            _repository = repository;
            _persistence = persistence;
        }

        public async Task<int> CreateUser(UserDto entity)
        {
            UserModel data = new UserModel
            {
                user_name = entity.user_name,
                password = entity.password,
                is_active = true,
            };

            var result = await _repository.SaveAsync(data);
            var response = await _persistence.SaveChangesAsync();
            return response;
        }

        public async Task<UserModel> GetUserById(int user_id)
        {
            var data = await _repository.FindByIdAsync(user_id);

            return data;
        }

        public async Task<UserModel> ProcessLoginUser(string user_name, string password)
        {
            var data = await _repository.FindByUsernameAndPasswordAsync(user_name, password);

            return data;
        }
    }
}

