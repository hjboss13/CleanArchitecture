using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.DataBase.User.Queries.GetByIdUser
{
    public class GetByIdUserQuery : IGetByIdUserQuery
    {
        private readonly IDataBaseService dataBaseService;
        private readonly IMapper mapper;

        public GetByIdUserQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            this.dataBaseService = dataBaseService;
            this.mapper = mapper;
        }

        public async Task<ByIdUserModel> Execute(int itemId)
        {
            var entity = await dataBaseService.tbUser.FirstOrDefaultAsync(x => x.Id == itemId);
            return mapper.Map<ByIdUserModel>(entity);
        }
    }
}
