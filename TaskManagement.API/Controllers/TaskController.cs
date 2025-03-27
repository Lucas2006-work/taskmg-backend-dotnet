using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Services;
using Microsoft.Extensions.Logging;

namespace TaskManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger, TaskService taskService)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet("test")]
        public IActionResult TestEndpoint()
        {
            _logger.LogInformation("Test endpoint accessed");
            return Ok("Test endpoint working");
        }

        // GET: api/task
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        // POST: api/task
        [HttpPost]
        public IActionResult AddTask([FromBody] AddTaskRequest request)
        {
            if (request == null)
                return BadRequest("Invalid data.");

            var task = _taskService.AddTask(request.Title, request.Description);
            return CreatedAtAction(nameof(GetAllTasks), new { id = task.Id }, task);
        }

        // DELETE: api/task/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            _logger.LogInformation("DELETE received");
            var success = _taskService.DeleteTask(id);
            _logger.LogInformation("" + success);
            if (success)
                return Ok("Successed");
            return NotFound("Task not found.");
        }
    }

    public class AddTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}