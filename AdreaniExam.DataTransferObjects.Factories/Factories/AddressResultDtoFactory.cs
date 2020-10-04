using AdreaniExam.DataTransferObjects.Factories.Dtos;
using AdreaniExam.DataTransferObjects.Factories.Mappers;
using AdreaniExam.DataTransferObjects.ReadDtos;
using AdreaniExam.Models.Entities;

namespace AdreaniExam.DataTransferObjects.Factories.Factories
{
    public class AddressResultDtoFactory
    {
        private readonly AddressResultDtoMapper mapper = new AddressResultDtoMapper();

        public IAddressResultDto BuilEntityToDto(IAddressResult entity, string state)
        {
            var dto = mapper.CreateDtoBase<AddressResultDto>(entity);
            mapper.MapAddressResultDto(dto, entity, state);

            return dto;
        }

        public IAddressRequestResultDto BuildToAddressRequestResultDto(int addressRequestId, double longitude, double latitude)
        {
            var dto = mapper.MapAddressRequestResultDto(new AddressRequestResultDto(), addressRequestId, longitude, latitude);

            return dto;
        }
    }
}
