using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sygno.Booking.Domain.Entities.Booking;

namespace Sygno.Booking.Persistence.Configuration
{
	public class BookingConfiguration
	{
		public BookingConfiguration(EntityTypeBuilder<BookingEntity> entitybuilder)
		{
			entitybuilder.HasKey(x => x.BookingId);
			entitybuilder.Property(x => x.RegisterDate).IsRequired();
			entitybuilder.Property(x => x.Code).IsRequired();
			entitybuilder.Property(x => x.Type).IsRequired();
			entitybuilder.Property(x => x.UserId).IsRequired();
			entitybuilder.Property(x => x.CustomerId).IsRequired();

			entitybuilder.HasOne(x => x.User)
				.WithMany(x => x.Bookings)
				.HasForeignKey(x => x.UserId);

			entitybuilder.HasOne(x => x.Customers)
				.WithMany(x => x.Bookings)
				.HasForeignKey(x => x.CustomerId);
		}
	}
}
