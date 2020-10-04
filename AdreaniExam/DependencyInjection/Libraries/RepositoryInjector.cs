using AdreaniExam.Repositories.EntityFramework.Repositories;
using AdreaniExam.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AdreaniExam.DependencyInjection.Libraries
{
    class RepositoryInjector : BaseInjector
    {
        public RepositoryInjector(IServiceCollection services) : base(services)
        {
        }

        public override void RegisterDependencies()
        {
            RegisterInstancePerRequest<IAddressRequestRepository, AddressRequestRepository>();

            RegisterInstancePerRequest<IAddressResultReadOnlyRepository, AddressResultRepository>();
            RegisterInstancePerRequest<IAddressResultRepository, AddressResultRepository>();
        }
    }
}
