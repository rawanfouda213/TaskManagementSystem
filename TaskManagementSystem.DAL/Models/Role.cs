namespace TaskManagementSystem.DAL.Models;

public class Role :BaseSettingsModel
{
    public virtual ICollection<RolePermission> Permissions { get; set; } = new List<RolePermission>();
}
