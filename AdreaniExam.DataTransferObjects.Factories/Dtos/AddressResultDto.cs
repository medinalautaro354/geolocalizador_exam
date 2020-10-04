using AdreaniExam.DataTransferObjects.BaseDtos;
using AdreaniExam.DataTransferObjects.ReadDtos;

namespace AdreaniExam.DataTransferObjects.Factories.Dtos
{
    class BaseAddressResultDto : IBaseAddressResultDto
    {
        public double? Longitud { get; set; }

        public double? Latitud { get; set; }
    }

    class AddressResultDto : BaseAddressResultDto, IAddressResultDto
    {
        public int Id { get; set; }
        public string Estado { get; set; }
    }

    class AddressRequestResultDto : BaseAddressResultDto, IAddressRequestResultDto
    {
        public int AddressRequestId { get; set; }
    }
}
