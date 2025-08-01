﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Domain.Entities
{
    public class CategoryEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<AccountEntity> Accounts { get; set; }
    }
}
