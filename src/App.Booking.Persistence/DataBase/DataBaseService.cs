using Microsoft.EntityFrameworkCore;
using Sygno.Booking.Application.DataBase;
using Sygno.Booking.Domain.Entities.Booking;
using Sygno.Booking.Domain.Entities.Customer;
using Sygno.Booking.Domain.Entities.User;
using Sygno.Booking.Persistence.Configuration;

namespace Sygno.Booking.Persistence.DataBase
{
	public class DataBaseService : DbContext, IDataBaseService
	{
		public DataBaseService(DbContextOptions options) : base(options)
		{

		}

		public DbSet<UserEntity> User { get; set; }
		public DbSet<CustomerEntity> Customer { get; set; }
		public DbSet<BookingEntity> Booking { get; set; }

		public async Task<bool> SaveAsync()
		{
			return await SaveChangesAsync() > 0;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			EntityConfiguration(modelBuilder);
		}

		private void EntityConfiguration(ModelBuilder modelbuilder)
		{
			new UserConfiguration(modelbuilder.Entity<UserEntity>());
			new CustomerConfiguration(modelbuilder.Entity<CustomerEntity>());
			new BookingConfiguration(modelbuilder.Entity<BookingEntity>());
		}
	}
}
