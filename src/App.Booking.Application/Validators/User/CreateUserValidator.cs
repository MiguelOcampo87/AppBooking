using FluentValidation;
using Microsoft.Identity.Client;
using Sygno.Booking.Application.DataBase.User.Commands.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.Validators.User
{
    public class CreateUserValidator: AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(50);
			RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(50);
			RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(50);
			RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("La contraseña es obligatoria").MaximumLength(10).Matches(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$").WithMessage("La contrasñea debe tener al menos 8 caracteres, una mayuscula, un numero y un simbolo"); ;
		}
	}
}
