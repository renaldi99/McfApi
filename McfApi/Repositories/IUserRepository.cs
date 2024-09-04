using System;
using McfApi.Models;

namespace McfApi.Repositories
{
	public interface IUserRepository : IGenericRepository<UserModel>
	{
		Task<UserModel> FindByUsernameAndPasswordAsync(string user_name, string password);
	}
}

