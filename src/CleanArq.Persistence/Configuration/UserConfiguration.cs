using CleanArq.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityTypeBuilder) 
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.UserName).IsRequired();
            entityTypeBuilder.Property(x => x.Password).IsRequired();
            entityTypeBuilder.Property(x => x.FullName).IsRequired();
        }
    }
}
