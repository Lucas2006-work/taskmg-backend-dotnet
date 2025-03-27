using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(TaskEntity task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public TaskEntity GetById(Guid id)
        {
            return _context.Tasks.Find(id);
        }

        public void Delete(TaskEntity task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}