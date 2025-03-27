using TaskManagement.Domain.Entities;
using System.Collections.Generic;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITaskRepository
    {
        void Add(TaskEntity task);
        IEnumerable<TaskEntity> GetAll();
        TaskEntity GetById(Guid id);
        void Delete(TaskEntity task);
    }
}