using System;
using McfApi.Repositories;
using McfApi.Services;

namespace McfApi.Extensions
{
	public static class ServiceExtensions
	{
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            #region
            services.AddScoped<IPersistence, Persistence>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBPKBService, BPKBService>();
            services.AddScoped<IBPKBRepository, BPKBRepository>();
            services.AddScoped<IStorageLocRepository, StorageLocRepository>();
            services.AddScoped<IStorageLocService, StorageLocService>();

            #endregion
        }
    }
}

