namespace AdreaniExam.Models
{
    public interface IIdEntity<T> where T : struct
    {
        T Id { get; }
    }

    public interface IIntIdEntity : IIdEntity<int> { }

    public interface ISoftDeleteEntity
    {
        bool IsActive { get; set; }
    }
}
