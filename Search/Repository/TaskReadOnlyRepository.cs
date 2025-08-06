using Microsoft.EntityFrameworkCore;
using Search.Entity;
using Search.Repository.ToDo.API.Repository;
using Search.UseCase.GetTasks;

namespace Search.Repository
{
    public class TaskReadOnlyRepository : IReadOnlyRepository
    {
        private readonly TaskDbContext _taskDbContext;

        public TaskReadOnlyRepository(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }

        public async Task<IList<TaskEntity>> GetTasks(GetTasksQuery request)
        {
            var query = _taskDbContext.Set<TaskEntity>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Title))
                query = query.Where(t => t.Title.Contains(request.Title));

            if (!string.IsNullOrWhiteSpace(request.Category))
                query = query.Where(t => t.Category == request.Category);

            if (!string.IsNullOrWhiteSpace(request.SubCategory))
                query = query.Where(t => t.SubCategory == request.SubCategory);

            if (request.Status.HasValue)
                query = query.Where(t => t.Status == request.Status.Value);

            return await query.ToListAsync();
        }
    }
}
