namespace TaskManagementSystem.DAL.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDBContext _dbContext;
    public CategoryRepository(ApplicationDBContext _dbContext)

    {
        this._dbContext = _dbContext;
    }
    public async Task<IEnumerable<Category>> GetAllAsync() => await _dbContext.Category.ToListAsync();
    public async Task<Category> GetByIdAsync(Guid id) => await _dbContext.Category.FindAsync(id);
    public async Task AddAsync(Category category) => await _dbContext.AddAsync(category);
    public async Task Update(Category category) => _dbContext.Update(category);
    public async Task DeleteAsync(Guid id)
    {
        Category category = await GetByIdAsync(id);
        _dbContext.Category.Remove(category);
    }
}
