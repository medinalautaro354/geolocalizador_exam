using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace AdreaniExam.Middlewares{
    static class CorsMiddlewareExtensions
    {
        public static readonly HashSet<string> AllowedOrigins = new HashSet<string>() { "*" };
        private const string CorsPolicyName = "App";

        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder builder)
        {
            builder.UseCors(CorsPolicyName);
            return builder;
        }

        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            void CorsPolicy(CorsPolicyBuilder g) => g
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .SetIsOriginAllowed(f => true);

            services.AddCors(f =>
            {
                f.AddPolicy(CorsPolicyName, CorsPolicy);
            });

            return services;
        }
    }
}