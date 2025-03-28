using Microsoft.EntityFrameworkCore;
using Sygno.Booking.Domain.Entities.Booking;
using Sygno.Booking.Domain.Entities.Customer;
using Sygno.Booking.Domain.Entities.User;

namespace Sygno.Booking.Application.DataBase
{
	public interface IDataBaseService
	{
		DbSet<UserEntity> User { get; set; }
		DbSet<CustomerEntity> Customer { get; set; }
		DbSet<BookingEntity> Booking { get; set; }

		Task<bool> SaveAsync();
	}
}
