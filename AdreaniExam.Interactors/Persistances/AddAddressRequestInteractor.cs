using AdreaniExam.DataTransferObjects.AddDtos;
using AdreaniExam.DataTransferObjects.Factories.Factories;
using AdreaniExam.DataTransferObjects.ReadDtos;
using AdreaniExam.Models.Entities;
using AdreaniExam.Repositories.Entities;
using AdreaniExam.Repositories.Repositories;
using System;
using System.Threading.Tasks;

namespace AdreaniExam.Interactors.Persistances
{
    public partial class AddAddressRequestInteractor
    {
        public class AddressRequestAdd : IAddressRequestAdd
        {
            public string Street { get; set; }
            public int Number { get; set; }
            public string City { get; set; }
            public string ZipCode { get; set; }
            public string Province { get; set; }
            public string Country { get; set; }

            public AddressRequestAdd(IAddAddressRequestDto dto)
            {
                Street = dto.Calle;
                Number = dto.Numero;
                City = dto.Ciudad;
                ZipCode = dto.CodigoPostal;
                Province = dto.Provincia;
                Country = dto.Pais;
            }
        }
    }

    public partial class AddAddressRequestInteractor
    {
        private readonly IAddressRequestRepository repository;
        private readonly AddressRequestDtoFactory factory;
        private readonly AddAddressResultInteractor addAddressResultInteractor;
        private readonly RabbitMQInteractor rabbitMQInteractor;

        public AddAddressRequestInteractor(IAddressRequestRepository repository, AddressRequestDtoFactory factory, AddAddressResultInteractor addAddressResultInteractor, RabbitMQInteractor rabbitMQInteractor)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            this.addAddressResultInteractor = addAddressResultInteractor ?? throw new ArgumentNullException(nameof(addAddressResultInteractor));
            this.rabbitMQInteractor = rabbitMQInteractor ?? throw new ArgumentNullException(nameof(rabbitMQInteractor));
        }

        public async Task<IBaseAddressRequestDto> Add(IAddAddressRequestDto dto)
        {
            var entity = await repository.Add(new AddressRequestAdd(dto));

            await addAddressResultInteractor.Add(entity.Id);

            rabbitMQInteractor.PublishMessage(factory.BuildAddressRequestMessageDto(entity), "AddressRequests");

            return factory.BuildEntityToBaseDto(entity);
        }
    }
}
