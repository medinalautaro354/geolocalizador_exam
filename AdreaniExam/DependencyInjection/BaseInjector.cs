using Microsoft.Extensions.DependencyInjection;
using System;

namespace AdreaniExam.DependencyInjection
{
    abstract class BaseInjector
    {
        private readonly IServiceCollection _services;
        protected BaseInjector(IServiceCollection services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public abstract void RegisterDependencies();

        protected void RegisterInstancePerRequest<T>() where T : class
        {
            _services.AddScoped<T>();
        }

        protected void RegisterInstancePerRequest<T, U>() where T : class where U : class, T
        {
            _services.AddScoped<T, U>();
        }

        protected void RegisterSingleton<T>() where T : class
        {
            _services.AddSingleton<T>();
        }

        protected void RegisterSingleton<T>(T instance) where T : class
        {
            _services.AddSingleton(instance);
        }

        protected void RegisterSingleton<T, U>() where T : class where U : class, T
        {
            _services.AddSingleton<T, U>();
        }

        protected void RegisterSingleton<T, U>(U instance) where T : class where U : class, T
        {
            _services.AddSingleton<T>(instance);
        }
    }
}
