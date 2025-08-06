using MediatR;
using Search.Dto;
using Search.Repository;
using Search.UseCase.GetTasks;

namespace Search.UseCase.GetTasksWithPagination
{
    public class GetTasksWithPaginationQueryHandler : IRequestHandler<GetTasksWithPaginationQuery, IList<GetTaskResponse>>
    {
        private readonly IReadOnlyRepository _taskRepository;

        public GetTasksWithPaginationQueryHandler(IReadOnlyRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IList<GetTaskResponse>> Handle(GetTasksWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var response = await _taskRepository.GetTasksWithPagination(request);

            return response.Select(task => new GetTaskResponse
            {
                Id = task.Id,
                Title = task.Title,
                Category = task.Category,
                SubCategory = task.SubCategory,
                Status = task.Status,
                CreatedAt = task.CreatedAt,
            }).ToList();
        }
    }
}
