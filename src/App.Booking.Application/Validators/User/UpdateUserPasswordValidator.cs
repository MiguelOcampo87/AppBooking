using FluentValidation;
using Sygno.Booking.Application.DataBase.User.Commands.UpdateUser;
using Sygno.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.Validators.User
{
    public class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordModel>
	{
        public UpdateUserPasswordValidator()
		{
			RuleFor(x => x.UserId).NotNull().GreaterThan(0);
			RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(10);
		}
	}
}
