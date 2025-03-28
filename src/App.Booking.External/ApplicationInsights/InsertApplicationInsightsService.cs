using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Sygno.Booking.Application.External.ApplicationInsights;
using Sygno.Booking.Domain.Models.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.External.ApplicationInsights
{
    public class InsertApplicationInsightsService : IInsertApplicationInsightsService
    {
        private readonly IConfiguration _configuration;
        public InsertApplicationInsightsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Execute(InsertApplicationInsightsModel metric)
        {
            if (metric == null) 
                throw new ArgumentNullException(nameof(metric));

            TelemetryConfiguration config = new TelemetryConfiguration();
            config.ConnectionString = _configuration["ApplicationInsightsConnectionString"];
            var properties = new Dictionary<string, string>{
                { "Id", metric.Id },
                { "Content", metric.Content },
                { "Detail", metric.Detail },

            };

            var _telemetryClient = new TelemetryClient(config);
            _telemetryClient.TrackTrace(metric.Type, SeverityLevel.Information, properties);

            return true;
        }
    }
}
