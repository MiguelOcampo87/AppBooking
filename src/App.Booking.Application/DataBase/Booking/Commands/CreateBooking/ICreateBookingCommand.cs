using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.DataBase.Booking.Commands.CreateBooking
{
    public interface ICreateBookingCommand
    {
		Task<CreateBookingModel> Execute(CreateBookingModel model);

	}
}
