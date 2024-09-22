namespace TaskManagementSystem.DAL.Repository;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task Update(T entity);
    Task DeleteAsync(Guid id);
}

