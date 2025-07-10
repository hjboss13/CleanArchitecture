using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.DataBase.User.Queries.LoginUser
{
    public interface ILoginUserQuery
    {
        Task<LoginUserModel> Execute(string userName, string pswd);
    }
}
