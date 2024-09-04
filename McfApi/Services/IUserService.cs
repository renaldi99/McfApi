using System;
using McfApi.DTOs;
using McfApi.Models;

namespace McfApi.Services
{
	public interface IUserService
	{
        Task<int> CreateUser(UserDto entity);
        Task<UserModel> GetUserById(int user_id);
        Task<UserModel> ProcessLoginUser(string user_name, string password);
    }
}

