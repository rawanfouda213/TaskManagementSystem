namespace TaskManagementSystem.DAL.Repository;
public interface ITaskRepository : IGenericRepository<Tasks>
{
    Task<IEnumerable<Tasks>> GetAllAsync();
    Task<Tasks> GetByIdAsync(Guid id);
    Task AddAsync(Tasks task);
    Task Update(Tasks task);
    Task DeleteAsync(Guid id);
}
