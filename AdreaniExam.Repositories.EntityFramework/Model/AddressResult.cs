using AdreaniExam.Models.Entities;

namespace AdreaniExam.Repositories.EntityFramework.Model
{
    public class AddressResult : IAddressResult
    {
        public int Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public State State { get; set; }
        public bool IsActive { get; set; }
        public int AddressRequestId { get; set; }
        public AddressRequest AddressRequest { get; set; }
    }
}
