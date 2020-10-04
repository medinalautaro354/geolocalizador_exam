using System.Threading.Tasks;

namespace AdreaniExam.Repositories.Repositories
{
    public interface IRepositoryReadOnly<T>
    {
        Task<T> GetById(int id);
        Task<bool> Exists(int id);
    }
    public interface IRepository<T, TAdd>
    {
        Task<T> Add(TAdd add);
    }
    public interface IRepositoryUpdate<T, TAdd, TUpdate> : IRepository<T, TAdd>
    {
        Task<T> Update(TUpdate update);
    }
}
