using AdreaniExam.DataTransferObjects.Factories.Factories;
using AdreaniExam.DataTransferObjects.ReadDtos;
using AdreaniExam.Repositories.Repositories;
using System;
using System.Threading.Tasks;

namespace AdreaniExam.Interactors
{
    public class AddressResultInteractor
    {
        private readonly IAddressResultReadOnlyRepository repository;
        private readonly AddressResultDtoFactory factory;

        public AddressResultInteractor(IAddressResultReadOnlyRepository repository, AddressResultDtoFactory factory)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task<IAddressResultDto> GetByAddressRequestId(int addressRequestId)
        {
            var result = await repository.GetByAddressRequestId(addressRequestId);

            if(result != null)
            {
                return factory.BuilEntityToDto(result, result.State.ToString().ToUpper());
            }

            return null;
        }
    }
}
