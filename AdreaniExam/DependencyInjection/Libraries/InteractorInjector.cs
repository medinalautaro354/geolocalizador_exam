using AdreaniExam.Interactors;
using AdreaniExam.Interactors.Persistances;
using Microsoft.Extensions.DependencyInjection;

namespace AdreaniExam.DependencyInjection.Libraries
{
    class InteractorInjector : BaseInjector
    {
        public InteractorInjector(IServiceCollection services) : base(services)
        {
        }

        public override void RegisterDependencies()
        {
            RegisterPersistanceInteractors();
            RegisterInteractors();
        }

        private void RegisterPersistanceInteractors()
        {
            RegisterInstancePerRequest<AddAddressRequestInteractor>();
            RegisterInstancePerRequest<AddAddressResultInteractor>();
            RegisterInstancePerRequest<UpdateAddressResultInteractor>();
        }

        private void RegisterInteractors()
        {
            RegisterInstancePerRequest<AddressResultInteractor>();
            RegisterInstancePerRequest<RabbitMQInteractor>();
        }
    }
}
