using AdreaniExam.DataTransferObjects.Factories.Dtos;
using AdreaniExam.DataTransferObjects.Factories.Mappers;
using AdreaniExam.DataTransferObjects.ReadDtos;
using AdreaniExam.Models.Entities;

namespace AdreaniExam.DataTransferObjects.Factories.Factories
{
    public class AddressRequestDtoFactory
    {
        private readonly AddressRequestDtoMapper mapper = new AddressRequestDtoMapper();

        public IBaseAddressRequestDto BuildEntityToBaseDto(IAddressRequest entity)
        {
            var dto = mapper.CreateDtoBase<BaseAddressRequestDto>(entity);
            return dto;
        }

        public IAddressRequestMessageDto BuildAddressRequestMessageDto(IAddressRequest entity)
        {
            var dto = mapper.CreateDtoBase<AddressRequestMessageDto>(entity);
            return mapper.MapAdressRequestMessageDto(entity, dto);
        }
    }
}
