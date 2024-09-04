using System;
namespace McfApi.Repositories
{
	public interface IPersistence
	{
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}

