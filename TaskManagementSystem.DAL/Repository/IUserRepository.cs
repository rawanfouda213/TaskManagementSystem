namespace TaskManagementSystem.DAL.Repository;

public interface IUserRepository : IGenericRepository<User>
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(Guid id);
    Task AddAsync(User user);
    Task Update(User user);
    Task DeleteAsync(Guid id);

}
