namespace Taller.CodeChallenge.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task InsertEntity(T obj);
        Task<bool> DeleteById(Guid id);        
    }
}
