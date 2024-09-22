using System.Threading.Tasks;

namespace TaskManagementSystem.DAL.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDBContext _dbContext;
    public TaskRepository(ApplicationDBContext _dbContext)
    {
        this._dbContext = _dbContext;
    }
    public async Task<IEnumerable<Tasks>> GetAllAsync() => await _dbContext.Tasks.ToListAsync();
    public async Task<Tasks> GetByIdAsync(Guid id) => await _dbContext.Tasks.FindAsync(id);
    public async Task AddAsync(Tasks task) => await _dbContext.AddAsync(task);
    public async Task Update(Tasks task) =>  _dbContext.Update(task);
    public async Task DeleteAsync(Guid id)
    {
        Tasks tasks = await GetByIdAsync(id);
        if (tasks != null)
        {
            _dbContext.Tasks.Remove(tasks);
            await _dbContext.SaveChangesAsync(); 
        }

    }

}
