using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.DataBase.Booking.Queries.GetBookingsByType
{
	public class GetBookingsByTypeModel
    {
		public DateTime RegisterDate { get; set; }
		public string Code { get; set; }
		public string Type { get; set; }
		public string CustomerFullName { get; set; }
		public string CustomerDocumentNumber { get; set; }
	}
}
