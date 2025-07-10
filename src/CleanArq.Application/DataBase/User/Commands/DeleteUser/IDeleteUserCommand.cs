using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.DataBase.User.Commands.DeleteUser
{
    public interface IDeleteUserCommand
    {
        Task<bool> Execute(int itemId);
    }
}
