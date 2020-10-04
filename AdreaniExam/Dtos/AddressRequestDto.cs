using AdreaniExam.DataTransferObjects.AddDtos;

namespace AdreaniExam.Dtos
{
    public class AddAddressRequestDto : IAddAddressRequestDto
    {
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
    }
}
