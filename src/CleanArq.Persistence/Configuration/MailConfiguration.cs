using CleanArq.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Persistence.Configuration
{
    public class MailConfiguration
    {
        public MailConfiguration(EntityTypeBuilder<MailEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.MailId);
            entityTypeBuilder.Property(x => x.Email).IsRequired();

            entityTypeBuilder.HasMany(x => x.Accounts).WithOne(x => x.Mail).HasForeignKey(x => x.MailId);
        }
    }
}
