using AdreaniExam.DataTransferObjects.Factories.Dtos;
using AdreaniExam.Models.Entities;

namespace AdreaniExam.DataTransferObjects.Factories.Mappers
{
    class AddressRequestDtoMapper : MapperEntityBase<IAddressRequest, BaseAddressRequestDto>
    {
        protected override void MapEntityToDtoBase<T>(IAddressRequest entity, T dto)
        {
            dto.Id = entity.Id;
        }

        public T MapAdressRequestMessageDto<T>(IAddressRequest entity, T dto) where T : AddressRequestMessageDto
        {
            dto.City = entity.City;
            dto.Country = entity.Country;
            dto.Number = entity.Number;
            dto.Province = entity.Province;
            dto.Street = entity.Street;
            dto.ZipCode = entity.ZipCode;

            return dto;
        }
    }
}
