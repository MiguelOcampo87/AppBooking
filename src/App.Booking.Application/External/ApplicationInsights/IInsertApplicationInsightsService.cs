using Sygno.Booking.Domain.Models.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.External.ApplicationInsights
{
    public interface IInsertApplicationInsightsService
    {
        bool Execute(InsertApplicationInsightsModel metric);
    }
}
