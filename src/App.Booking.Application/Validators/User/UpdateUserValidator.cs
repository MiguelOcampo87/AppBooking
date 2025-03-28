using FluentValidation;
using Sygno.Booking.Application.DataBase.User.Commands.CreateUser;
using Sygno.Booking.Application.DataBase.User.Commands.UpdateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserModel>
	{
        public UpdateUserValidator()
		{
			RuleFor(x => x.UserId).NotNull().GreaterThan(0);
			RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(50);
			RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(50);
			RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(50);
			RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(10);
		}
	}
}
