using AdreaniExam.DataTransferObjects.Factories.Dtos;
using AdreaniExam.Models.Entities;

namespace AdreaniExam.DataTransferObjects.Factories.Mappers
{
    class AddressResultDtoMapper : MapperEntityBase<IAddressResult, BaseAddressResultDto>
    {
        protected override void MapEntityToDtoBase<T>(IAddressResult entity, T dto)
        {
            dto.Latitud = entity.Latitude;
            dto.Longitud = entity.Longitude;
        }

        public void MapAddressResultDto(AddressResultDto dto, IAddressResult entity, string state)
        {
            dto.Id = entity.Id;
            dto.Estado = state;
        }

        public T MapAddressRequestResultDto<T>(T dto, int addressRequestId, double longitude, double latitude) where T : AddressRequestResultDto
        {
            dto.AddressRequestId = addressRequestId;
            dto.Latitud = latitude;
            dto.Longitud = longitude;

            return dto;
        }
    }
}
