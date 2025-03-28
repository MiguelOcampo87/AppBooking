using Microsoft.EntityFrameworkCore;

namespace Sygno.Booking.Application.DataBase.Customer.Commands.DeleteCustomer
{
	public class DeleteCustomerCommand : IDeleteCustomerCommand
	{
		private readonly IDataBaseService _dataBaseService;

		public DeleteCustomerCommand(IDataBaseService databaseService)
		{
			_dataBaseService = databaseService;
		}

		public async Task<bool> Execute(int customerId)
		{
			var entity = await _dataBaseService.Customer
				.FirstOrDefaultAsync(x => x.CustomerId == customerId);

			if (entity == null)
				return false;

			_dataBaseService.Customer.Remove(entity);
			return await _dataBaseService.SaveAsync();
		}
	}
}
