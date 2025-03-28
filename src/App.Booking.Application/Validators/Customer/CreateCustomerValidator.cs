using FluentValidation;
using Sygno.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.Validators.Customer
{
	public class CreateCustomerValidator : AbstractValidator<CreateCustomerModel>
	{
		public CreateCustomerValidator()
		{
			RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50);
			RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().Length(8);
		}
	}
}
