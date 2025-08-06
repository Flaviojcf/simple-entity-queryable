using Search.Entity;
using Search.UseCase.GetTasks;

namespace Search.Repository
{
    public interface IReadOnlyRepository
    {
        Task<IList<TaskEntity>> GetTasks(GetTasksQuery getTasksQuery);
        Task<IList<TaskEntity>> GetTasksWithPagination(GetTasksWithPaginationQuery getTasksWithPaginationQuery);

    }
}
