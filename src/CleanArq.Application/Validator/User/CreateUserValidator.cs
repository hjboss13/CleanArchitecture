using CleanArq.Application.DataBase.User.Commands.CreateUser;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.Validator.User
{
    public class CreateUserValidator :  AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
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
