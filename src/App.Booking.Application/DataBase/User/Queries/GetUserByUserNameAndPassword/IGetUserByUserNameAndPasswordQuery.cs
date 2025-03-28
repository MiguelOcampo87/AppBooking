﻿namespace Sygno.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword
{
	public interface IGetUserByUserNameAndPasswordQuery
	{
		Task<GetUserByUserNameAndPasswordModel> Execute(string userName,
			string password);

	}
}
