using System;
using McfApi.DTOs;
using McfApi.Models;

namespace McfApi.Services
{
	public interface IStorageLocService
	{
        Task<int> CreateLocation(StorageLocDto entity);
        Task<int> UpdateLocation(StorageLocDto entity);
        Task<IEnumerable<StorageLocationModel>> GetListLocation();
    }
}

