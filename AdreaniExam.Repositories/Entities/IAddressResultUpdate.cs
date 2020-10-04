using AdreaniExam.Models;
using AdreaniExam.Models.Entities;

namespace AdreaniExam.Repositories.Entities
{
    public interface IAddressResultUpdate : IIntIdEntity
    {
        double? Latitude { get; }
        double? Longitude { get; }
        State State { get; }
    }
}
