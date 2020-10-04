using AdreaniExam.DataTransferObjects.BaseDtos;

namespace AdreaniExam.DataTransferObjects.ReadDtos
{
    public interface IAddressResultDto : IBaseAddressResultDto
    {
        int Id { get; }
        string Estado { get; }
    }
}
