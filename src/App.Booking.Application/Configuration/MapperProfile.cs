using AutoMapper;
using Sygno.Booking.Application.DataBase.Booking.Commands.CreateBooking;
using Sygno.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Sygno.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Sygno.Booking.Application.DataBase.Customer.Queries.GetAllCustomers;
using Sygno.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Sygno.Booking.Application.DataBase.Customer.Queries.GetCustomerbyId;
using Sygno.Booking.Application.DataBase.User.Commands.CreateUser;
using Sygno.Booking.Application.DataBase.User.Commands.UpdateUser;
using Sygno.Booking.Application.DataBase.User.Queries.GetAllUser;
using Sygno.Booking.Application.DataBase.User.Queries.GetUserById;
using Sygno.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Sygno.Booking.Domain.Entities.Booking;
using Sygno.Booking.Domain.Entities.Customer;
using Sygno.Booking.Domain.Entities.User;

namespace Sygno.Booking.Application.Configuration
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			#region User
			CreateMap<UserEntity, CreateUserModel>().ReverseMap();
			CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
			CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
			CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
			CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();
			#endregion

			#region Customer
			CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
			CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
			CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
			CreateMap<CustomerEntity, GetCustomerbyIdModel>().ReverseMap(); 
			CreateMap<CustomerEntity, GetCustomerByDocumentNumberModel>().ReverseMap();
			#endregion

			#region Booking
			CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();			
			#endregion
		}
	}
}
