using AutoMapper;
using CleanArq.Application.Configuration;
using CleanArq.Application.DataBase.User.Commands.CreateUser;
using CleanArq.Application.DataBase.User.Commands.DeleteUser;
using CleanArq.Application.DataBase.User.Commands.UpdateUser;
using CleanArq.Application.DataBase.User.Queries.GetAllUser;
using CleanArq.Application.DataBase.User.Queries.GetByIdUser;
using CleanArq.Application.DataBase.User.Queries.LoginUser;
using CleanArq.Application.Validator.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArq.Application
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config => {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetByIdUserQuery, GetByIdUserQuery>();
            services.AddTransient<ILoginUserQuery, LoginUserQuery>();

            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
            services.AddScoped<IValidator<LoginUserModel>, LoginUserValidator>();

            return services;
        }
    }
}
