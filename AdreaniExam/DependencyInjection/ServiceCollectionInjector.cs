using AdreaniExam.DependencyInjection.Libraries;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AdreaniExam.DependencyInjection
{
    class ServiceCollectionInjector
    {
        private readonly IServiceCollection _services;

        public ServiceCollectionInjector(IServiceCollection services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public void ResolveServices()
        {
            InjectDependencies();
        }

        private void InjectDependencies()
        {
            new InteractorInjector(_services).RegisterDependencies();
            new RepositoryInjector(_services).RegisterDependencies();
            new DataTransferObjectsFactoryInjector(_services).RegisterDependencies();
        }
    }
}
