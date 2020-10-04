namespace AdreaniExam.Repositories.Entities
{
    public interface IAddressRequestAdd
    {
        string Street { get; }
        int Number { get; }
        string City { get; }
        string ZipCode { get; }
        string Province { get; }
        string Country { get; }
    }
}
