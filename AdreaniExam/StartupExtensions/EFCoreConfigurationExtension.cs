using AdreaniExam.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AdreaniExam.StartupExtensions
{
    public class EFCoreConfiguration
    {
        public readonly string connectionString;

        public EFCoreConfiguration(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
    }
    public static class EFCoreConfigurationExtension
    {
        public static IServiceCollection EFCoreConfiguration(this IServiceCollection services, EFCoreConfiguration configuration)
        {
            services.AddDbContext<AdreaniExamContext>(
                options => options.UseSqlServer(configuration.connectionString));

            return services;
        }
    }
}
