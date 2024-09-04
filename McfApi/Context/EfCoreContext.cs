using System;
using McfApi.Models;
using Microsoft.EntityFrameworkCore;

namespace McfApi.Context
{
	public class EfCoreContext : DbContext
	{
        public EfCoreContext()
        {
        }

        public EfCoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BPKBModel> BPKBModels{ get; set; }
		public DbSet<StorageLocationModel> StorageLocationModels { get; set; }
		public DbSet<UserModel> UserModels { get; set; }


    }
}

