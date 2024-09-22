namespace TaskManagementSystem.PL.DTOs;

public class CategoryDto
{
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public virtual ICollection<TasksDto> Tasks { get; set; } = new List<TasksDto>();
}
