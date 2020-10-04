using AdreaniExam.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdreaniExam.StartupExtensions
{
    static class SwaggerExtension
    {
        public static IServiceCollection SwaggerServiceConfiguration(this IServiceCollection services, string appName)
        {
            var swagger = new SwaggerServicesConfiguration();
            swagger.ServiceConfiguration(services, appName);

            return services;
        }

        public static IApplicationBuilder SwaggerAppConfiguration(this IApplicationBuilder app, IWebHostEnvironment environment, string appName)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", appName);
            });

            return app;
        }

    }
}
