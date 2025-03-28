using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.DataBase.Customer.Queries.GetCustomerbyId
{
	public class GetCustomerbyIdModel
    {
		public int CustomerId { get; set; }
		public string FullName { get; set; }
		public string DocumentNumber { get; set; }
	}
}
