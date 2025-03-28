using AutoMapper;
using Sygno.Booking.Domain.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.DataBase.Booking.Commands.CreateBooking
{
	public class CreateBookingCommand: ICreateBookingCommand
	{
		private readonly IDataBaseService _dataBaseService;
		private readonly IMapper _mapper;

		public CreateBookingCommand(IDataBaseService dataBaseService,
			IMapper mapper)
		{
			_dataBaseService = dataBaseService;
			_mapper = mapper;
		}

		public async Task<CreateBookingModel> Execute(CreateBookingModel model)
		{
			var entity = _mapper.Map<BookingEntity>(model);
			entity.RegisterDate = DateTime.Now;
			await _dataBaseService.Booking.AddAsync(entity);
			await _dataBaseService.SaveAsync();

			return model;
		}
	}
}
