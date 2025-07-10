using CleanArq.Application.DataBase.User.Commands.CreateUser;
using CleanArq.Application.DataBase.User.Commands.UpdateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.Validator.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id).NotNull()
                .NotEmpty();
            RuleFor(x => x.UserName).NotNull()
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty()
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
