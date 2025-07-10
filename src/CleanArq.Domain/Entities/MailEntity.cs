using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Domain.Entities
{
    public class MailEntity
    {
        public int MailId { get; set; }
        public string Email { get; set; }
        public ICollection<AccountEntity> Accounts { get; set; }
    }
}
