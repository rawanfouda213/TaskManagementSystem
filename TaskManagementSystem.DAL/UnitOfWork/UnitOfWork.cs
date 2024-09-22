using TaskManagementSystem.DAL.Repository;

namespace TaskManagementSystem.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _dbContext;
    public ITaskRepository Task { get; set; }
    public IUserRepository User { get; set; }
    public ICategoryRepository Category { get; set; }
    public UnitOfWork(ApplicationDBContext _dbContext , ITaskRepository Task , IUserRepository User, ICategoryRepository Category)
    {
     this._dbContext = _dbContext;
     this.Task = Task;
     this.User = User;
    }
    public async Task<int> SaveChanges()=> await _dbContext.SaveChangesAsync();
    public void Dispose()=> _dbContext.Dispose();
   
}
