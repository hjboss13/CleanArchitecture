using AutoMapper;
using CleanArq.Application.DataBase.User.Commands.UpdateUser;
using CleanArq.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.DataBase.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDataBaseService dataBaseService;
        private readonly IMapper mapper;

        public DeleteUserCommand(IDataBaseService dataBaseService, IMapper mapper) 
        {
            this.dataBaseService = dataBaseService;
            this.mapper = mapper;
        }

        public async Task<bool> Execute(int itemId)
        {
            var entity = await dataBaseService.tbUser.FirstOrDefaultAsync(x => x.Id == itemId);

            if (entity == null)
                return false;

            dataBaseService.tbUser.Remove(entity);
            return await dataBaseService.SaveAsync();
        }
    }
}
