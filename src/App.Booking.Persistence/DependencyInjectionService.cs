using Azure.Core;
using Azure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.AlwaysEncrypted.AzureKeyVaultProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sygno.Booking.Application.DataBase;
using Sygno.Booking.Persistence.DataBase;

namespace Sygno.Booking.Persistence
{
	public static class DependencyInjectionService
	{
		public static IServiceCollection AddPersistence(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<DataBaseService>(options =>
			options.UseSqlServer(configuration["SQLConnectionString"]));

			services.AddScoped<IDataBaseService, DataBaseService>();

			if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
			{
				string tenantId = Environment.GetEnvironmentVariable("tenantId") ?? string.Empty;
				string clientId = Environment.GetEnvironmentVariable("clientId") ?? string.Empty;
				string clientSecret = Environment.GetEnvironmentVariable("clientSecret") ?? string.Empty;

				var tokenCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);

				var azurekeyVaultProvider = new SqlColumnEncryptionAzureKeyVaultProvider(tokenCredentials);

				SqlConnection.RegisterColumnEncryptionKeyStoreProviders(new Dictionary<string,
					SqlColumnEncryptionKeyStoreProvider>(1, StringComparer.OrdinalIgnoreCase)
				{
					{ SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, azurekeyVaultProvider}
				});
			}
			else
			{
				var azurekeyVaultProvider = new SqlColumnEncryptionAzureKeyVaultProvider(new ManagedIdentityCredential());

				SqlConnection.RegisterColumnEncryptionKeyStoreProviders(new Dictionary<string,
					SqlColumnEncryptionKeyStoreProvider>(1, StringComparer.OrdinalIgnoreCase)
				{
					{ SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, azurekeyVaultProvider}
				});
			}

			return services;
		}
	}
}
