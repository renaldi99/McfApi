using System;
using McfApi.DTOs;
using McfApi.Exceptions;
using McfApi.Models;
using McfApi.Repositories;

namespace McfApi.Services
{
    public class StorageLocService : IStorageLocService
    {
        private readonly IStorageLocRepository _repository;
        private readonly IPersistence _persistence;

        public StorageLocService(IStorageLocRepository repository, IPersistence persistence)
        {
            _repository = repository;
            _persistence = persistence;
        }

        public async Task<int> CreateLocation(StorageLocDto entity)
        {
            try
            {
                var data = new StorageLocationModel
                {
                    location_name = entity.location_name
                };
                var result = await _repository.SaveAsync(data);
                var response = await _persistence.SaveChangesAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<StorageLocationModel>> GetListLocation()
        {
            var result = await _repository.FindAllAsync();

            return result;
        }

        public async Task<int> UpdateLocation(StorageLocDto entity)
        {
            try
            {
                var currentLocation = await _repository.FindByIdAsync(entity.location_id);
                if (currentLocation == null)
                {
                    throw new NotFoundException("Not Found Data");
                }

                currentLocation.location_name = entity.location_name;

                var result = _repository.Update(currentLocation);
                var response = await _persistence.SaveChangesAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

