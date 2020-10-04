using AdreaniExam.DataTransferObjects.Factories.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace AdreaniExam.DependencyInjection.Libraries
{
    class DataTransferObjectsFactoryInjector : BaseInjector
    {
        public DataTransferObjectsFactoryInjector(IServiceCollection services) : base(services)
        {
        }

        public override void RegisterDependencies()
        {
            RegisterInstancePerRequest<AddressRequestDtoFactory>();
            RegisterInstancePerRequest<AddressResultDtoFactory>();
        }
    }
}
