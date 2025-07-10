using AutoMapper;
using CleanArq.Application.DataBase.User.Commands.CreateUser;
using CleanArq.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.DataBase.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IDataBaseService dataBaseService;
        private readonly IMapper mapper;

        public UpdateUserCommand(IDataBaseService dataBaseService, IMapper mapper) 
        {
            this.dataBaseService = dataBaseService;
            this.mapper = mapper;
        }

        public async Task<bool> Execute(UpdateUserModel model)
        {
            var entity = await dataBaseService.tbUser.FirstOrDefaultAsync(x => x.Id == model.Id);
            
            if (entity == null) 
                return false;

            entity.UserName = model.UserName;
            entity.Password = model.Password;
            entity.FullName = model.FullName;

            dataBaseService.tbUser.Update(entity);
            return await dataBaseService.SaveAsync();
        }
    }
}
