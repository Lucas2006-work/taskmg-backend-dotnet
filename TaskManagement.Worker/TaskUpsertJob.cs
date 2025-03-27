using Hangfire;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Repositories;

namespace TaskManagement.Worker
{
    public class TaskUpsertJob
    {
        private readonly ITaskRepository _taskRepository;

        public TaskUpsertJob(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [AutomaticRetry(Attempts = 3)]
        public void UpsertTask()
        {
            var newTask = new TaskEntity
            {
                Title = "Automated Task",
                Description = "This task was created by Hangfire job",
                IsCompleted = false
            };

            _taskRepository.Add(newTask);
        }
    }
}
