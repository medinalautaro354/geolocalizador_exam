namespace AdreaniExam.Models.Entities
{
    public enum State
    {
        Procesando, Terminado
    }
    public interface IAddressResult : IIntIdEntity, ISoftDeleteEntity
    {
        int AddressRequestId { get; }
        double? Latitude { get; }
        double? Longitude { get; }
        State State { get; }
    }
}
