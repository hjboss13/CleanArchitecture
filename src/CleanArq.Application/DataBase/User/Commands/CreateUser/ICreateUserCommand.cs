using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.DataBase.User.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        Task<bool> Execute(CreateUserModel model);
    }
}
