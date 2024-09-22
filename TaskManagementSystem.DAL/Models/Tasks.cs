namespace TaskManagementSystem.DAL.Models;

public class Tasks :BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    [ForeignKey("Category")]
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }=new Category();
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = new User();
}
