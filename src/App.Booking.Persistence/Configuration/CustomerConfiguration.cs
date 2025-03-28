using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sygno.Booking.Domain.Entities.Customer;

namespace Sygno.Booking.Persistence.Configuration
{
	public class CustomerConfiguration
	{
		public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entitybuilder)
		{
			entitybuilder.HasKey(x => x.CustomerId);
			entitybuilder.Property(x => x.FullName).IsRequired();
			entitybuilder.Property(x => x.DocumentNumber).IsRequired();

			entitybuilder.HasMany(x => x.Bookings)
				.WithOne(x => x.Customers)
				.HasForeignKey(x => x.CustomerId);
		}
	}
}
