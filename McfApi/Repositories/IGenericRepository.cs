using System;
using System.Linq.Expressions;

namespace McfApi.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> SaveAsync(T entity);
        Task<List<T>> FindAllAsync();
        Task<T> FindByIdAsync(int id);
        Task<T> Delete(T entity);
        T Update(T entity);
        T Attach(T entity);
    }
}

