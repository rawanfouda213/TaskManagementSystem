using TaskManagementSystem.DAL.Repository;

namespace TaskManagementSystem.DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    ITaskRepository Task { get; set; }
    IUserRepository User { get; set; }
    ICategoryRepository Category { get; set; }
    Task<int> SaveChanges();
}
