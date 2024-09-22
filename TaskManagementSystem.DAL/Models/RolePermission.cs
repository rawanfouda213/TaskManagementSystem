namespace TaskManagementSystem.DAL.Models;

public class RolePermission :BaseModel
{
    public bool IsView { get; set; }
    public bool IsAdd { get; set; }
    public bool IsEdit { get; set; }
    public bool IsDelete { get; set; }

    [ForeignKey("Role")]
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; } = new Role();

    [ForeignKey("Page")]
    public Guid PageId { get; set; }
    public virtual Page Page { get; set; } = new Page();
}
