namespace Sygno.Booking.Application.DataBase.User.Queries.GetAllUser
{
	public interface IGetAllUserQuery
	{
		Task<List<GetAllUserModel>> Execute();

	}
}
