using Sygno.Booking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygno.Booking.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(
            int statusCode, object Data = null, string message = null)
        {
            bool succes = false;

            if (statusCode >= 200 && statusCode < 300)
                succes = true;

            var result = new BaseResponseModel
            {
                StatusCode = statusCode,
                Success = succes,
                Message = message,
                Data = Data
            };

            return result;
        }
    }
}
