using FluentValidation;
using Sygno.Booking.Application.DataBase.Booking.Commands.CreateBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.Validators.Booking
{
	public class CreateBookingValidator : AbstractValidator<CreateBookingModel>
	{
		public CreateBookingValidator()
		{
			RuleFor(x => x.Code).NotNull().NotEmpty().Length(8);
			RuleFor(x => x.Type).NotNull().NotEmpty().MaximumLength(50);
			RuleFor(x => x.CustomerId).NotNull().GreaterThan(0);
			RuleFor(x => x.UserId).NotNull().GreaterThan(0);
		}
	}
}
