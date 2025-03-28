using Microsoft.Extensions.DependencyInjection;

namespace Sygno.Booking.Common
{
	public static class DependencyInjectionService
	{
		public static IServiceCollection AddCommon(this IServiceCollection services)
		{
			return services;
		}
	}
}
