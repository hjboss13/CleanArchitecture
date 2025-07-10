using CleanArq.Application.DataBase;
using CleanArq.Domain.Entities;
using CleanArq.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Persistence.DataBase
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options) : base(options) 
        { 
            
        }

        public DbSet<AccountEntity> Account { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<MailEntity> Mail { get; set; }
        public DbSet<UserEntity> tbUser { get; set; }

        public async Task<bool> SaveAsync()
        { 
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new AccountConfiguration(modelBuilder.Entity<AccountEntity>());
            new CategoryConfiguration(modelBuilder.Entity<CategoryEntity>());
            new MailConfiguration(modelBuilder.Entity<MailEntity>());
            new UserConfiguration(modelBuilder.Entity<UserEntity>());
        }
    }
}
