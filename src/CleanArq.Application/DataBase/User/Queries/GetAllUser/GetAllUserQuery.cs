using AutoMapper;
using CleanArq.Application.DataBase.User.Commands.UpdateUser;
using CleanArq.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.DataBase.User.Queries.GetAllUser
{
    public class GetAllUserQuery : IGetAllUserQuery
    {
        private readonly IDataBaseService dataBaseService;
        private readonly IMapper mapper;

        public GetAllUserQuery(IDataBaseService dataBaseService, IMapper mapper) 
        {
            this.dataBaseService = dataBaseService;
            this.mapper = mapper;
        }

        public async Task<List<AllUserModel>> Execute()
        {
            var listEntity = await dataBaseService.tbUser.ToListAsync();
            return mapper.Map<List<AllUserModel>>(listEntity);
        }
    }
}
