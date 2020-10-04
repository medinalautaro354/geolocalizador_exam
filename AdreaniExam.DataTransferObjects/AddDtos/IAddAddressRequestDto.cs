namespace AdreaniExam.DataTransferObjects.AddDtos
{
    public interface IAddAddressRequestDto
    {
        string Calle { get; }
        int Numero { get; }
        string Ciudad { get; }
        string CodigoPostal  { get; }
        string Provincia { get; }
        string Pais { get; }
    }
}
