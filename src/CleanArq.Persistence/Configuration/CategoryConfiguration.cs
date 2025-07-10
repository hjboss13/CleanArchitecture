using CleanArq.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Persistence.Configuration
{
    public class CategoryConfiguration
    {
        public CategoryConfiguration(EntityTypeBuilder<CategoryEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.CategoryId);
            entityTypeBuilder.Property(x => x.CategoryName).IsRequired();

            entityTypeBuilder.HasMany(x => x.Accounts).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            
        }
    }
}
