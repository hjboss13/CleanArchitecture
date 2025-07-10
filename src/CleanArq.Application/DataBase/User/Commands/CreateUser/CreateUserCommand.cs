using AutoMapper;
using CleanArq.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.DataBase.User.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDataBaseService dataBaseService;
        private readonly IMapper mapper;

        public CreateUserCommand(IDataBaseService dataBaseService ,IMapper mapper) 
        {
            this.dataBaseService = dataBaseService;
            this.mapper = mapper;
        }

        public async Task<bool> Execute(CreateUserModel model)
        {
            var entity = mapper.Map<UserEntity>(model);
            await dataBaseService.tbUser.AddAsync(entity);
            return await dataBaseService.SaveAsync();
        }
    }
}
