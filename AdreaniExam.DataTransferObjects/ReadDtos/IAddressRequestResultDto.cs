using AdreaniExam.DataTransferObjects.BaseDtos;

namespace AdreaniExam.DataTransferObjects.ReadDtos
{
    public interface IAddressRequestResultDto : IBaseAddressResultDto
    {
        int AddressRequestId { get; }
    }
}
