using AdreaniExam.DependencyInjection;
using AdreaniExam.Interactor.RabbitMQConsumerService;
using AdreaniExam.Middlewares;
using AdreaniExam.StartupExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdreaniExam
{
    public class Startup
    {
        public const string AppName = "AdreaniExam";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton(services);

            services.ConfigureCors();

            services.ConfigureMcv();

            services.EFCoreConfiguration(new EFCoreConfiguration(Configuration.GetConnectionString("DefaultConnection")));

            services.RabbitMQConfiguration(Configuration);

            new ServiceCollectionInjector(services).ResolveServices();

            services.AddHostedService<ConsumerServices>();

            services.SwaggerServiceConfiguration(AppName);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCorsMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.SwaggerAppConfiguration(env, AppName);
        }
    }
}
