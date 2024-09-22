namespace TaskManagementSystem.DAL.Models;

public class Page : BaseSettingsModel
{
    public string RouterLink { get; set; }
    public virtual ICollection<RolePermission> Permissions { get; set; } = new List<RolePermission>();
}
