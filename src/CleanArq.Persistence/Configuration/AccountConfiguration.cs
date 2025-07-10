using CleanArq.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Persistence.Configuration
{
    public class AccountConfiguration
    {
        public AccountConfiguration(EntityTypeBuilder<AccountEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.AccountId);
            entityTypeBuilder.Property(x => x.AccountName).IsRequired();
            entityTypeBuilder.Property(x => x.Password).IsRequired();
            entityTypeBuilder.Property(x => x.Active).IsRequired();
            entityTypeBuilder.Property(x => x.CategoryId).IsRequired();
            entityTypeBuilder.Property(x => x.MailId).IsRequired();

            entityTypeBuilder.HasOne(x => x.Category).WithMany(x => x.Accounts).HasForeignKey(x => x.CategoryId);
            entityTypeBuilder.HasOne(x => x.Mail).WithMany(x => x.Accounts).HasForeignKey(x => x.MailId);
        }
    }
}
