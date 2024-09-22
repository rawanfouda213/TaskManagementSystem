namespace TaskManagementSystem.DAL.Context;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext()
    {
    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
    : base(options)
    {
    }

    public virtual DbSet<Category> Category { get; set; }
    public virtual DbSet<Page> Page { get; set; }
    public virtual DbSet<Role> Role { get; set; }
    public virtual DbSet<RolePermission> RolePermission { get; set; }
    public virtual DbSet<Tasks> Tasks { get; set; }
    public virtual DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User and Tasks relationship
        modelBuilder.Entity<User>()
            .HasMany(u => u.Tasks)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);

        // Tasks and Category relationship
        modelBuilder.Entity<Tasks>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CategoryId);

        // Role and User relationship
        modelBuilder.Entity<User>()
            .HasOne(r => r.Role)
            .WithMany()
            .HasForeignKey(r => r.RoleId);

        // Role and RolePermission relationship
        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.Permissions)
            .HasForeignKey(rp => rp.RoleId);

        // Page and RolePermission relationship
        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Page)
            .WithMany(p => p.Permissions)
            .HasForeignKey(rp => rp.PageId);
    }

}
