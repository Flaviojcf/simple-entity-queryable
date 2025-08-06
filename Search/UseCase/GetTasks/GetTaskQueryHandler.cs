using MediatR;
using Search.Dto;
using Search.Repository;

namespace Search.UseCase.GetTasks
{
    public class GetTaskQueryHandler : IRequestHandler<GetTasksQuery, IList<GetTaskResponse>>
    {
        private readonly IReadOnlyRepository _taskRepository;

        public GetTaskQueryHandler(IReadOnlyRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IList<GetTaskResponse>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            var response = await _taskRepository.GetTasks(request);

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
