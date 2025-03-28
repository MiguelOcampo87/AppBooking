using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sygno.Booking.Application.External.ApplicationInsights;
using Sygno.Booking.Application.External.GetTokenJwt;
using Sygno.Booking.Application.External.SendGridEmail;
using Sygno.Booking.External.ApplicationInsights;
using Sygno.Booking.External.GetTokenJwt;
using Sygno.Booking.External.SendGrid;
using System.Text;

namespace Sygno.Booking.External
{
	public static class DependencyInjectionService
	{
		public static IServiceCollection AddExternal(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddSingleton<ISendGridEmailService, SendGridEmailService>();
			services.AddSingleton<IGetTokenJwtService, GetTokenJwtService>();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
			{
				option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKeyJwt2"])),
					ValidIssuer = configuration["IssuerJwt"],
					ValidAudience = configuration["AudienceJwt"]
				};
			});

			services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
			{
				ConnectionString = configuration["ApplicationInsightsConnectionString"]
			});

			services.AddSingleton<IInsertApplicationInsightsService, InsertApplicationInsightsService>();

			return services;
		}
	}
}
