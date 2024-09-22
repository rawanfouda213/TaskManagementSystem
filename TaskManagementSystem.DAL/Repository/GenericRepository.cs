namespace TaskManagementSystem.DAL.Repository;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDBContext _dbContext;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(ApplicationDBContext _dbContext, DbSet<T> _dbSet)
    {
        this._dbContext = _dbContext;
        this._dbSet = _dbSet;
    }
    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public async Task Update(T entity) => _dbSet.Update(entity);
    public async Task DeleteAsync(Guid id)
    {
        T entity = await GetByIdAsync(id);
        _dbSet.Remove(entity);
    }



}
