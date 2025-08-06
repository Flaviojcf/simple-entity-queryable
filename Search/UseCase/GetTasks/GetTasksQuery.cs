using MediatR;
using Search.Dto;
using Search.Enum;

namespace Search.UseCase.GetTasks
{
    public class GetTasksQuery : IRequest<IList<GetTaskResponse>>
    {
        public string? Title { get; set; } = string.Empty;
        public string? Category { get; set; } = string.Empty;
        public string? SubCategory { get; set; } = string.Empty;
        public Status? Status { get; set; }
    }
}
