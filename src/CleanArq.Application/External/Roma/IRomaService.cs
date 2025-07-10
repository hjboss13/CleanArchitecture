using CleanArq.Domain.Models.Roma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.External.Roma
{
    public interface IRomaService
    {
        Task<List<Category>> Execute(int buil);
    }
}
