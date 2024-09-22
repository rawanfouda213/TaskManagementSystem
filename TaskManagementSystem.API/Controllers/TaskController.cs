using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace TaskManagementSystem.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;
        private readonly IUnitOfWork _UnitOfWork;
        public TaskController(IUnitOfWork _UnitOfWork, ApplicationDBContext _Context)
        {
            this._UnitOfWork = _UnitOfWork;
            this._Context = _Context;
        }
        [Authorize]
        [HttpGet("GetTasks")]
        public async Task<ActionResult<IEnumerable<TasksDto>>> GetTasks()
        {
            try
            {
                var tasks = await _UnitOfWork.Task.GetAllAsync();

                if (tasks.Any())
                    return Ok(tasks);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpGet("GetTask/{taskId}")]
        public async Task<ActionResult<TasksDto>> GetTaskById(Guid taskId)
        {
            try
            {
                TasksDto taskDto = await _UnitOfWork.Task.GetByIdAsync(taskId);

                if (taskDto != null)
                {
                    return Ok(taskDto);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("AddTask")]
        public async Task<ActionResult<TasksDto>> AddTask(TasksDto newTaskDto)
        {
            Tasks newTask = new Tasks
            {
                Title = newTaskDto.Title,
                Description = newTaskDto.Description,
                DueDate = newTaskDto.DueDate,
                IsCompleted = newTaskDto.IsCompleted
            };

            await _UnitOfWork.Task.AddAsync(newTask);
            await _UnitOfWork.SaveChanges();

            return Ok(newTaskDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("EditTask/{id}")]
        public async Task<ActionResult<TasksDto>> EditTask(Guid id, TasksDto updatedTasksDto)
        {
            try
            {
                Tasks? task = await _UnitOfWork.Task.GetByIdAsync(id);

                if (task == null)
                {
                    return NotFound();
                }

                task.Title = updatedTasksDto.Title;
                task.Description = updatedTasksDto.Description;
                task.DueDate = updatedTasksDto.DueDate;
                task.IsCompleted = updatedTasksDto.IsCompleted;

                await _UnitOfWork.Task.Update(task);
                await _UnitOfWork.SaveChanges();

                return Ok(updatedTasksDto); 
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [Authorize(Roles ="Admin")]
        [HttpDelete("DeleteTask/{id}")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            try
            {
                Tasks? task = await _UnitOfWork.Task.GetByIdAsync(id);

                if (task == null)
                {
                    return NotFound();
                }

                await _UnitOfWork.Task.DeleteAsync(id);
                await _UnitOfWork.SaveChanges(); 

                return Ok(task);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("search")]
        public IActionResult SearchTasks(string searchTerm)
        {
            var tasks = _Context.Tasks
                                .Where(t => t.Title.Contains(searchTerm) || t.Description.Contains(searchTerm))
                                .ToList();
            return Ok(tasks);
        }

    }
}
