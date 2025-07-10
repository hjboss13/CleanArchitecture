using CleanArq.Application.DataBase.User.Commands.CreateUser;
using CleanArq.Application.DataBase.User.Queries.LoginUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.Validator.User
{
    public class LoginUserValidator : AbstractValidator<LoginUserModel>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserName).NotNull()
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty()
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
