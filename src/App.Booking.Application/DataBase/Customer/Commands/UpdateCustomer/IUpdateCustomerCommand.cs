namespace Sygno.Booking.Application.DataBase.Customer.Commands.UpdateCustomer
{
	public interface IUpdateCustomerCommand
	{
		Task<UpdateCustomerModel> Execute(UpdateCustomerModel model);

	}
}
