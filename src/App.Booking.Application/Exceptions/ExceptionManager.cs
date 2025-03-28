using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sygno.Booking.Application.External.ApplicationInsights;
using Sygno.Booking.Application.Features;
using Sygno.Booking.Common.Constants;
using Sygno.Booking.Domain.Models.ApplicationInsights;

namespace Sygno.Booking.Application.Exceptions
{
    public class ExceptionManager: IExceptionFilter
    {
        private readonly IInsertApplicationInsightsService _insertApplicationInsightsService;
        public ExceptionManager(IInsertApplicationInsightsService insertApplicationInsightsService) 
        {
            _insertApplicationInsightsService = insertApplicationInsightsService;
        }

        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(ResponseApiService.Response(
                StatusCodes.Status500InternalServerError, null, context.Exception.Message));

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var metric = new InsertApplicationInsightsModel(
                ApplicationInsightsConstants.METRIC_TYPE_ERROR,
                context.Exception.Message,
                context.Exception.ToString()
                );

            _insertApplicationInsightsService.Execute(metric);

		}
    }
}
