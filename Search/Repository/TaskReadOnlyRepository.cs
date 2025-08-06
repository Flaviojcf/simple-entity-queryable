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

            query = query.OrderBy(t => t.CreatedAt);

            if (!string.IsNullOrWhiteSpace(request.Title))
                query = query.Where(t => t.Title.Contains(request.Title));

            if (!string.IsNullOrWhiteSpace(request.Category))
                query = query.Where(t => t.Category == request.Category);

            if (!string.IsNullOrWhiteSpace(request.SubCategory))
                query = query.Where(t => t.SubCategory == request.SubCategory);

            if (request.Status.HasValue)
                query = query.Where(t => t.Status == request.Status.Value);

            query = query.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);

            return await query.ToListAsync();
        }

        public async Task<IList<TaskEntity>> GetTasksWithPagination(GetTasksWithPaginationQuery getTasksWithPaginationQuery)
        {
            var query = _taskDbContext.Task.AsQueryable();

            query = query.OrderBy(t => t.CreatedAt);

            return await query
                .Skip((getTasksWithPaginationQuery.Page - 1) * getTasksWithPaginationQuery.PageSize)
                .Take(getTasksWithPaginationQuery.PageSize)
                .ToListAsync();
        }
    }
}
