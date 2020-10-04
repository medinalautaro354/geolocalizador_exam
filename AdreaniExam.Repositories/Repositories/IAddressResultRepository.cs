using AdreaniExam.Models.Entities;
using AdreaniExam.Repositories.Entities;
using System.Threading.Tasks;

namespace AdreaniExam.Repositories.Repositories
{
    public interface IAddressResultRepository : IRepositoryUpdate<IAddressResult, IAddressResultAdd, IAddressResultUpdate>, IAddressResultReadOnlyRepository { }
    public interface IAddressResultReadOnlyRepository
    {
        Task<IAddressResult> GetByAddressRequestId(int addressRequestId);
    }
}
