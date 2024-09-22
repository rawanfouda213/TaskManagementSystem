namespace TaskManagementSystem.DAL.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDBContext _dbContext;
    public UserRepository(ApplicationDBContext _dbContext)
    {
        this._dbContext = _dbContext;
    }
    public async Task<IEnumerable<User>> GetAllAsync() => await _dbContext.User.ToListAsync();
    public async Task<User> GetByIdAsync(Guid id) => await _dbContext.User.FindAsync(id);
    public async Task AddAsync(User user) => await _dbContext.AddAsync(user);
    public async Task Update(User user) => _dbContext.Update(user);
    public async Task DeleteAsync(Guid id)
    {
        User user = await GetByIdAsync(id);
        _dbContext.User.Remove(user);
    }
}
