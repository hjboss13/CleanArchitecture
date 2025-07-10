using CleanArq.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<AccountEntity> Account { get; set; }
        DbSet<CategoryEntity> Category { get; set; }
        DbSet<MailEntity> Mail { get; set; }
        DbSet<UserEntity> tbUser { get; set; }
        Task<bool> SaveAsync();
    }
}
