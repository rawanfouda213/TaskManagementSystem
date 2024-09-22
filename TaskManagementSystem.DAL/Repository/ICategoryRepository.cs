namespace TaskManagementSystem.DAL.Repository;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(Guid id);
    Task AddAsync(Category category);
    Task Update(Category category);
    Task DeleteAsync(Guid id);
}
