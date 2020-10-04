using AdreaniExam.Interactors.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdreaniExam.StartupExtensions
{
    public static class RabbitMQConfigurationExtension
    {
        public static IServiceCollection RabbitMQConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            var rabbitConfiguration = new RabbitMQConfiguration();

            Configuration.GetSection("RabbitMQConfiguration").Bind(rabbitConfiguration);

            services.AddSingleton(rabbitConfiguration);

            return services;
        }
    }
}
