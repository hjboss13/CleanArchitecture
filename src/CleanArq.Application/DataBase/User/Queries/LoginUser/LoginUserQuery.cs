using AutoMapper;
using CleanArq.Application.DataBase.User.Queries.GetByIdUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.DataBase.User.Queries.LoginUser
{
    public class LoginUserQuery : ILoginUserQuery
    {
        private readonly IDataBaseService dataBaseService;
        private readonly IMapper mapper;

        public LoginUserQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            this.dataBaseService = dataBaseService;
            this.mapper = mapper;
        }

        public async Task<LoginUserModel> Execute(string userName, string pswd)
        {
            var entity = await dataBaseService.tbUser.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == pswd);
            return mapper.Map<LoginUserModel>(entity);
        }
    }
}
