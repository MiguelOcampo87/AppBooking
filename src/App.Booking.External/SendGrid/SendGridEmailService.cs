using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sygno.Booking.Application.External.SendGridEmail;
using Sygno.Booking.Domain.Models.SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sygno.Booking.External.SendGrid
{
    public class SendGridEmailService: ISendGridEmailService
	{
        private readonly IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
		}

        public async Task<bool> Execute(SendGridRequestModel model)
        {
            string apiKey = _configuration["SendGridEmailKey"];
            string apiUrl = "https://api.sendgrid.com/v3/mail/send";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
			client.DefaultRequestHeaders.Add("Accept", $"application/json");

            string emailContent = JsonConvert.SerializeObject(model);

            var response = await client.PostAsync(apiUrl, new StringContent(emailContent, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return true;

            return false;
		}
	}
}
