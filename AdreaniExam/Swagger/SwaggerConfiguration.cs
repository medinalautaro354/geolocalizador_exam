using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdreaniExam.Swagger
{
    class SwaggerServicesConfiguration
    {
        public void ServiceConfiguration(IServiceCollection services, string appName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = appName + " API", Version = "v1" });
            });
        }
    }
}
