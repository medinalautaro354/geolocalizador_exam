namespace AdreaniExam.Models.Entities
{
    public interface IAddressRequest : IIntIdEntity, ISoftDeleteEntity
    {
        string Street { get; }
        int Number { get; }
        string City { get; }
        string ZipCode { get; }
        string Province { get; }
        string Country { get; }
    }
}
