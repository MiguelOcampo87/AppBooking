using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.DataBase.Customer.Queries.GetCustomerbyId
{
    public interface IGetCustomerbyIdQuery
    {
		Task<GetCustomerbyIdModel> Execute(int customerId);

	}
}
