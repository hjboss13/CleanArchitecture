using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Domain.Entities
{
    public class AccountEntity
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public byte Active { get; set; }
        public int CategoryId { get; set; }
        public int MailId { get; set; }
        public CategoryEntity Category { get; set; }
        public MailEntity Mail { get; set; }

    }
}
