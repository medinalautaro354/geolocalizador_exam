using AdreaniExam.DataTransferObjects.ReadDtos;

namespace AdreaniExam.DataTransferObjects.Factories.Dtos
{
    class BaseAddressRequestDto : IBaseAddressRequestDto
    {
        public int Id { get; set; }
    }

    class AddressRequestMessageDto : BaseAddressRequestDto, IAddressRequestMessageDto
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
    }
}
