namespace TaskManagementSystem.DAL.Models;

public class Category :BaseSettingsModel
{
    public virtual ICollection<Tasks> Tasks { get; set; }= new List<Tasks>();
}
