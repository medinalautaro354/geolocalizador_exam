using AdreaniExam.DataTransferObjects.ReadDtos;
using AdreaniExam.Models.Entities;
using AdreaniExam.Repositories.Entities;
using AdreaniExam.Repositories.Repositories;
using System;
using System.Threading.Tasks;

namespace AdreaniExam.Interactors.Persistances
{
    public partial class UpdateAddressResultInteractor
    {
        public class AddressResultUpdate : IAddressResultUpdate
        {
            public double? Latitude { get; }

            public double? Longitude { get; }

            public State State { get; }

            public int Id { get; }

            public AddressResultUpdate(IAddressRequestResultDto dto, int addressResultId)
            {
                Latitude = dto.Latitud;
                Longitude = dto.Longitud;
                Id = addressResultId;
                State = State.Terminado;
            }
        }
    }

    public partial class UpdateAddressResultInteractor
    {
        private readonly IAddressResultRepository repository;

        public UpdateAddressResultInteractor(IAddressResultRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IAddressResult> Update(IAddressRequestResultDto dto)
        {
            var addressResult = await repository.GetByAddressRequestId(dto.AddressRequestId);

            var entity = await repository.Update(new AddressResultUpdate(dto, addressResult.Id));

            return entity;
        }
    }
}
