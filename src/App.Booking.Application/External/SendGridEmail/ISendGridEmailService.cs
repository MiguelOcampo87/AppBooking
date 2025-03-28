using Sygno.Booking.Domain.Models.SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.External.SendGridEmail
{
    public interface ISendGridEmailService
    {
		Task<bool> Execute(SendGridRequestModel model);

	}
}
