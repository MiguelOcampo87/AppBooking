namespace Sygno.Booking.Application.DataBase.Customer.Queries.GetAllCustomers
{
	public interface IGetAllCustomerQuery
	{
		Task<List<GetAllCustomerModel>> Execute();

	}
}
