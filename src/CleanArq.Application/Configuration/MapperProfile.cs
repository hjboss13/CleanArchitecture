using AutoMapper;
using CleanArq.Application.DataBase.User.Commands.CreateUser;
using CleanArq.Application.DataBase.User.Commands.UpdateUser;
using CleanArq.Application.DataBase.User.Queries.GetAllUser;
using CleanArq.Application.DataBase.User.Queries.GetByIdUser;
using CleanArq.Application.DataBase.User.Queries.LoginUser;
using CleanArq.Domain.Entities;

namespace CleanArq.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        { 
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, AllUserModel>().ReverseMap();
            CreateMap<UserEntity, ByIdUserModel>().ReverseMap();
            CreateMap<UserEntity, LoginUserModel>().ReverseMap();
        }
    }
}
