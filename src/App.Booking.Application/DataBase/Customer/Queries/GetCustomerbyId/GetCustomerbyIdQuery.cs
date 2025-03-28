using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.DataBase.Customer.Queries.GetCustomerbyId
{
    public class GetCustomerbyIdQuery: IGetCustomerbyIdQuery
	{
		private readonly IDataBaseService _dataBaseService;
		private readonly IMapper _mapper;

		public GetCustomerbyIdQuery(IDataBaseService dataBaseService,
			IMapper mapper)
		{
			_dataBaseService = dataBaseService;
			_mapper = mapper;
		}

		public async Task<GetCustomerbyIdModel> Execute(int customerId)
		{
			var entity = await _dataBaseService.Customer
				.FirstOrDefaultAsync(x => x.CustomerId == customerId);

			return _mapper.Map<GetCustomerbyIdModel>(entity);
		}

	}
}
