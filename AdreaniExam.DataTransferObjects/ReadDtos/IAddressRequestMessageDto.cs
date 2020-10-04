namespace AdreaniExam.DataTransferObjects.ReadDtos
{
    public interface IAddressRequestMessageDto : IBaseAddressRequestDto
    {
        string Street { get; }
        int Number { get; }
        string City { get; }
        string ZipCode { get; }
        string Province { get; }
        string Country { get; }
    }
}
