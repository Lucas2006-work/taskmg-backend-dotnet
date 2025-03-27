using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Domain.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // Add a new task
        public TaskEntity AddTask(string title, string description)
        {
            var task = new TaskEntity
            {
                Title = title,
                Description = description,
                CreatedAt = DateTime.Now
            };

            _taskRepository.Add(task);
            return task;
        }

        // Get all tasks
        public IEnumerable<TaskEntity> GetAllTasks()
        {
            return _taskRepository.GetAll().ToList();
        }

        // Delete a task
        public bool DeleteTask(Guid id)
        {
            var task = _taskRepository.GetById(id);
            if (task != null)
            {
                _taskRepository.Delete(task);
                return true;
            }
            return false;
        }
    }
}